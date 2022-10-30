using System;
using System.IO.Ports;

namespace ArduinoWindController;
public class ArduinoSerialCom : IDisposable
{
    public enum ReturnCode {
        OK = 0,
        UnknownError,
        AnswerIsCorrupted,
        USB_NULL,
        USB_NOBYTERECEIVED,
        USB_RECEIVEERROR,


        FunctionIsUnknown = 0x100,
        MssgIsTooLong,
        ResetIsKO,
        SoftwareError
    };
    
    public string[] ComportList
    {
        get
        {
            string[] comportsList = SerialPort.GetPortNames();
            return comportsList;
        }
    }

    public bool IsConnected {
        get {
            if (_serialPort != null) {
                return _serialPort.IsOpen;
            }
            return false;
        }
    }

    private SerialPort _serialPort;

    public ArduinoSerialCom() {
        _serialPort = new SerialPort();
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
    }

    public void Disconnect() {
        if (_serialPort.IsOpen) {
            _serialPort.Close();
        }
    }

    public bool Connect(string comport, int baudrate) {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = baudrate;

        _serialPort.Open();
        if (_serialPort.IsOpen) {
            try {
                UInt16 ver = GetFWVersion();
                if (ver > 0)
                {
                    Console.WriteLine("Connected device firmware version : " + ver.ToString("X4") + " on " + comport);
                    return true;
                }
                else
                {
                    Disconnect();
                }
            } catch(Exception ex) {
                Console.WriteLine("Failed to connect : " + comport);
                Console.WriteLine(ex.ToString());
            }
        }

        return false;
    }

    public void Dispose() {
        Disconnect();

        if (_serialPort != null) {
            _serialPort.Dispose();
        }
    }

    // ENABLE :
    // - true : ventilator control active, turned on
    // - false : ventilator turned off
    public void SetVent1Enable(bool enabled) {
        
    }

    public void SetVent2Enable(bool enabled) {

    }

    // ANGLE :
    // From -180.00deg (0x0000, 0) to 180.00deg (0x8CA0, 36000)
    // 0.00deg is 0x4650, 18000
    public void SetVent1Angle(UInt16 angle) {

    }

    public void SetVent2Angle(UInt16 angle) {
        
    }

    // MAXSPEED :
    // From 10kmh (0x64, 100) to 500kmh (0x1388, 5000)
    public void SetVent1MaxSpeed(UInt16 maxSpeed) {

    }

    public void SetVent2MaxSpeed(UInt16 maxSpeed) {
        
    }

    // GAMMA :
    // From 0.001 (0x1, 1) to 9.999 (0x270F, 9999)
    public void SetVent1Gamma(UInt16 gamma) {
        
    }

    public void SetVent2Gamma(UInt16 gamma) {
        
    }
    
    public void SetBool(bool enabler)
    {
        Console.WriteLine(enabler ? "Bool Enable" : "Bool Disable");
        string msg_to_send = "=BE" + (enabler ? "1" : "0") + "\r";

        ReturnCode retval = SendReceiveUSB(_serialPort, msg_to_send.ToCharArray(), 5, out char[] result, 20, '\r');
        if (retval == ReturnCode.OK)
        {
            string tempstr = new(result);
            retval = ProcessAnswer(msg_to_send, tempstr, 1);
            if (retval == ReturnCode.OK)
            {
                return;
            }
        }

        Exception ex = new Exception("ReturnCode : "+retval.ToString()+" ; messageSent : " + msg_to_send + " ; messageReceived : " + (string)new(result));
        Console.WriteLine((enabler ? "Bool Enable" : "Bool Disable")+" - exception : " + ex.ToString());
        throw ex;
    }

    public void WriteValue(UInt16 value)
    {
        Console.WriteLine("WriteValue " + value);
        string msg_to_send = "=WR" + value.ToString("X4") + "\r";

        ReturnCode retval = SendReceiveUSB(_serialPort, msg_to_send.ToCharArray(), 8, out char[] result, 20, '\r');
        if (retval == ReturnCode.OK)
        {
            string tempstr = new(result);
            retval = ProcessAnswer(msg_to_send, tempstr, 0);
            if (retval == ReturnCode.OK)
            {
                return;
            }
        }

        Exception ex = new Exception("ReturnCode : "+retval.ToString()+" ; messageSent : " + msg_to_send + " ; messageReceived : " + (string)new(result));
        Console.WriteLine("WriteValue " + value + " - exception : " + ex.ToString());
        throw ex;
    }

    public UInt16 GetFWVersion()
    {
        string msg_to_send = "=R?\r";

        ReturnCode retval = SendReceiveUSB(_serialPort, msg_to_send.ToCharArray(), 4, out char[] result, 20, '\r');
        if (retval == ReturnCode.OK)
        {
            string tempstr = new(result);
            retval = ProcessAnswer(msg_to_send, tempstr, 0);
            int startIndexReceived = tempstr.IndexOf('>');
            if (retval == ReturnCode.OK)
            {
                string tempstr2 = tempstr.Substring(startIndexReceived + 3, 4);
                UInt16 ret_result = Convert.ToUInt16(tempstr2, 16);
                Console.WriteLine("GetFWVersion : " + ret_result);
                return ret_result;
            }
        }

        Exception ex = new Exception("ReturnCode : "+retval.ToString()+" ; messageSent : " + msg_to_send + " ; messageReceived : " + (string)new(result));
        Console.WriteLine("GetFWVersion - exception : " + ex.ToString());
        throw ex;
    }
    
    public void HWLC_SoftReset()
    {
        Console.WriteLine("SoftReset");
        string msg_to_send = "=W#12345678\r";

        ReturnCode retval = SendReceiveUSB(_serialPort, msg_to_send.ToCharArray(), 12, out char[] result, 20, '\r');
        if (retval == ReturnCode.OK)
        {
            string tempstr = new(result);
            retval = ProcessAnswer(msg_to_send, tempstr, 0);
            if (retval == ReturnCode.OK)
            {
                // Pas de vérif sur le 'FFFFFFFF' de ">W#FFFFFFFF\r" car vérif sur ">W#"
                // et il n'y a qu'un seul message qui commence par ">W#"
                return;
            }
        }

        Exception ex = new Exception("ReturnCode : "+retval.ToString()+" ; messageSent : " + msg_to_send + " ; messageReceived : " + (string)new(result));
        Console.WriteLine("SoftReset - exception : " + ex.ToString());
        throw ex;
    }

    private void SendUSB(SerialPort sp, char[] TxBuffer, UInt16 mssgTxLength) {
        if ((sp != null) && sp.IsOpen)
        {
            sp.Write(TxBuffer, 0, mssgTxLength);
        }
    }

    private bool ReceiveUSB(SerialPort sp, out char[] RxBuffer, UInt16 mssgRxMaxLength, out UInt16 counter)
    {
        RxBuffer = new char[mssgRxMaxLength];
        bool status = false;
        counter = 0;
        if ((sp != null) && sp.IsOpen)
        {
            counter = (UInt16)sp.Read(RxBuffer, 0, mssgRxMaxLength);
            if (counter > 0)
            {
                status = true;
            }
        }
        return status;
    }

    private ReturnCode SendReceiveUSB(SerialPort sp, char[] TxBuffer, UInt16 mssgTxLenght, out char[] RxBuffer, UInt16 mssgRxMaxLenght, char StopChar)
    {
        ReturnCode status = ReturnCode.USB_NULL;
        UInt16 i = 0;
        UInt16 BytesReceived = 0;
        RxBuffer = new char[mssgRxMaxLenght];

        if ((sp != null) && sp.IsOpen)
        {
            if (sp.BytesToRead != 0)
            {
                sp.DiscardInBuffer();
            }
            sp.Write(TxBuffer, 0, mssgTxLenght);

            do
            {
                char[] RxBufferTemp = new char[1];
                if (ReceiveUSB(sp, out RxBufferTemp, 1, out BytesReceived) == true)
                {
                    if (BytesReceived == 1)
                    {
                        RxBuffer[i] = RxBufferTemp[0];
                        status = ReturnCode.OK;
                    }
                    else
                    {
                        return ReturnCode.USB_NOBYTERECEIVED;
                    }
                }
                else
                {
                    return ReturnCode.USB_RECEIVEERROR;
                }
            } while ((RxBuffer[i] != StopChar) && (i++ < mssgRxMaxLenght));
        }

        return status;
    }
    private ReturnCode ProcessAnswer(string msg_sent, string msg_received, int offset_arg_size)
    {
        ReturnCode retval = ReturnCode.UnknownError;
        // --- Récupération de l'index du caractère de départ : '=' ---
        int startIndexSent = msg_sent.IndexOf('=');
        // TODO ReturnCode.WrongInputCommand
        if (startIndexSent == -1)
        {
            return ReturnCode.AnswerIsCorrupted;
        }
        // --- Récupération de l'index du caractère de départ : '>' ---
        int startIndexReceived = msg_received.IndexOf('>');
        if (startIndexReceived == -1)
        {
            return ReturnCode.AnswerIsCorrupted;
        }

        if (msg_sent.Substring(startIndexSent + 1, 2 + offset_arg_size) == msg_received.Substring(startIndexReceived + 1, 2 + offset_arg_size))
        {
            retval = ReturnCode.OK;
        }
        else if (msg_received.Substring(startIndexReceived + 1, 2) == "ER")
        {
            string error_code = "0x" + msg_received.Substring(startIndexReceived + 3, 2);

            int error = Convert.ToInt32(error_code, 16);
            retval = ReturnCode.FunctionIsUnknown + error;
        }
        else
        {
            retval = ReturnCode.AnswerIsCorrupted;
        }
        return retval;
    }
}