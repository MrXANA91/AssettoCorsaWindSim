#include "common.h"
#include "functionManager.h"
#include "conv_ascii.h"
#include "fancontroller.h"

#define ComEndCar1 '\r'
#define ComEndCar2 '\n'

extern uint8_t flag_noreboot;

uint16_t    SetReponse(uint8_t, uint8_t*,uint16_t, typeSTATUS*);
int16_t     Fill1Car(  uint16_t, uint8_t, uint8_t*);
int16_t     Fill2ASCII(uint16_t, int8_t,  uint8_t*);
int16_t     Fill4ASCII(uint16_t, uint16_t,uint8_t*);
int16_t     Fill8ASCII(uint16_t, int32_t, uint8_t*);

uint16_t FunctionProceed(uint8_t* STRINGCHAR, uint8_t* SENDCHAR, int16_t MssgLength, typeSTATUS* STSbits) {
    uint16_t Fonction;
    if      (MssgLength < 0) Fonction = FctTooLong;
    else if (MssgLength < 5) Fonction = FctNoResponse;
    else{
            Fonction  = (uint16_t) (STRINGCHAR[1]<<8);
            Fonction |= (uint16_t) (STRINGCHAR[2]);
    }
    MssgLength = MssgLength-5;
    #define Mssg &STRINGCHAR[3]
    #define MssgPlusOne &STRINGCHAR[3+1]
    
    unsigned int    arg=0;
    int32_t     arg32=0;
    uint8_t     MssgCode=FunctionIsUnknown;

    switch (Fonction)
    {
        case FctFanAEnable:
            if (MssgLength < 1) {
                MssgCode = FanAEnableNoArgument;
            } else if (OneAsciiToHex(Mssg, &arg) == false) {
                MssgCode = FanAEnableNotAsciiArgument;
            } else {
                MssgCode = (FanAEnable(arg, STSbits) ? FanAEnableOK : FanAEnableIsKO);
            }
            break;
        case FctFanBEnable:
            if (MssgLength < 1) {
                MssgCode = FanBEnableNoArgument;
            } else if (OneAsciiToHex(Mssg, &arg) == false) {
                MssgCode = FanBEnableNotAsciiArgument;
            } else {
                MssgCode = (FanBEnable(arg, STSbits) ? FanBEnableOK : FanBEnableIsKO);
            }
            break;
        case FctFanAPower:
            if (MssgLength < 2) {
                MssgCode = FanAPowerNotEnoughArgument;
            } else if (TwoAsciiToHex(Mssg, &arg) == false) {
                MssgCode = FanAPowerNotAsciiArgument;
            } else if (FanAPower(arg, STSbits) == false) {
                MssgCode = FanAPowerWrongArgument;
            } else {
                MssgCode = FanAPowerOK;
            }
            break;
        case FctFanBPower:
            if (MssgLength < 2) {
                MssgCode = FanBPowerNotEnoughArgument;
            } else if (TwoAsciiToHex(Mssg, &arg) == false) {
                MssgCode = FanBPowerNotAsciiArgument;
            } else if (FanBPower(arg, STSbits) == false) {
                MssgCode = FanBPowerWrongArgument;
            } else {
                MssgCode = FanBPowerOK;
            }
            break;
        case FctFanAGetInfos:
            MssgCode = FanAGetInfosOK;
            break;
        case FctFanBGetInfos:
            MssgCode = FanBGetInfosOK;
            break;
        case FctGetVersion:
            MssgCode = GetVersionIsOK;
            arg = (uint16_t) (VERSION & 0xFFFF);
            break;
        case FctReset:
            if (MssgLength < 8)
                MssgCode = ResetIsKO;
            else if (EightAsciiToHex(Mssg, &arg32)==FALSE)
                MssgCode = ResetIsKO;
            else if (arg32 != 0x12345678)
                MssgCode = ResetIsKO;
            else {
                flag_noreboot = 0;
                MssgCode = ResetIsOK;
            }
            break;
        case FctTooLong     : MssgCode = MssgIsTooLong;     break;
        case FctNoResponse  : MssgCode = NoResponse;        break;
        default             : MssgCode = FunctionIsUnknown;  break;
    }

    return( SetReponse(MssgCode, SENDCHAR, arg, STSbits) );
}

uint16_t SetReponse(uint8_t NumeroReponse, uint8_t reponse[], uint16_t arg, typeSTATUS* STS) {
    reponse[0] = ResponseFirstCar;
    int16_t k = 1, error = 0;

    switch (NumeroReponse) {
        case FanAEnableOK:
            k += Fill1Car(FctFanAEnable, ToAscii(STS->FANA_enable), &reponse[k]);
            break;
        case FanBEnableOK:
            k += Fill1Car(FctFanBEnable, ToAscii(STS->FANB_enable), &reponse[k]);
            break;
        case FanAPowerOK:
            k += Fill2ASCII(FctFanAPower, (uint8_t)(STS->FANA_PWM), &reponse[k]);
            break;
        case FanBPowerOK:
            k += Fill2ASCII(FctFanBPower, (uint8_t)(STS->FANB_PWM), &reponse[k]);
            break;
        case FanAGetInfosOK:
            k += Fill4ASCII(FctFanAGetInfos, (uint16_t)(((STS->FANA_enable)<<8)|(STS->FANA_PWM)), &reponse[k]);
            break;
        case FanBGetInfosOK:
            k += Fill4ASCII(FctFanBGetInfos, (uint16_t)(((STS->FANB_enable)<<8)|(STS->FANB_PWM)), &reponse[k]);
            break;
        case GetVersionIsOK:
            k += Fill4ASCII(FctGetVersion, arg, &reponse[k]);
            break;
        case ResetIsOK:
            k += Fill8ASCII(FctReset, 0xFFFFFFFF, &reponse[k]);
            break;
    // --------------------------------------------------------------------
        default :                                   error++;    // ER10 (bug, reponse non codee)
        case SoftwareError :                        error++;    // ER0F (erreur pour debug)
        case FanBPowerWrongArgument :               error++;    // ER0E
        case FanBPowerNotAsciiArgument :            error++;    // ER0D
        case FanBPowerNotEnoughArgument :           error++;    // ER0C
        case FanAPowerWrongArgument :               error++;    // ER0B
        case FanAPowerNotAsciiArgument :            error++;    // ER0A
        case FanAPowerNotEnoughArgument :           error++;    // ER09
        case FanBEnableIsKO :                       error++;    // ER08
        case FanBEnableNotAsciiArgument :           error++;    // ER07
        case FanBEnableNoArgument :                 error++;    // ER06
        case FanAEnableIsKO :                       error++;    // ER05
        case FanAEnableNotAsciiArgument :           error++;    // ER04
        case FanAEnableNoArgument :                 error++;    // ER03
        case ResetIsKO  :                           error++;    // ER02
        case MssgIsTooLong :                        error++;    // ER01 (Message trop long)
        case FunctionIsUnknown :                                // ER00 (Fonction inconnue)
            
            reponse[1] = 'E';
            reponse[2] = 'R';
            IntTo2Ascii(error, &reponse[3]);
            k = 5;
            break;
        case NoResponse : k=1; break;
    }
    reponse[k++] = ComEndCar1;
    reponse[k++] = ComEndCar2;
    if (k<=3)
        k=0;
    return (k);
}

int16_t Fill1Car(uint16_t FctChars, uint8_t car, uint8_t reponse[])
{
    reponse[0]= (uint8_t) (FctChars>>8);
    reponse[1]= (uint8_t) (FctChars & 0x00FF);
    reponse[2]= (uint8_t) (car);
    return(3);
}

int16_t Fill2ASCII(uint16_t FctChars, int8_t arg, uint8_t reponse[])
{
    reponse[0]= (uint8_t) (FctChars>>8);
    reponse[1]= (uint8_t) (FctChars & 0x00FF);
    IntTo2Ascii(arg, &reponse[2]);
    return(4);
}

int16_t Fill4ASCII(uint16_t FctChars, uint16_t arg, uint8_t reponse[])
{
    reponse[0]= (uint8_t) (FctChars>>8);
    reponse[1]= (uint8_t) (FctChars & 0x00FF);
    UIntTo4Ascii(arg, &reponse[2]);
    return(6);
}

int16_t Fill8ASCII(uint16_t FctChars, int32_t arg32, uint8_t reponse[])
{
    reponse[0]= (uint8_t) (FctChars>>8);
    reponse[1]= (uint8_t) (FctChars & 0x00FF);
    LongTo8Ascii(arg32, &reponse[2]);
    return(10);
}