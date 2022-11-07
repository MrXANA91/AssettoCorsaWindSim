#include "common.h"
#include "communication.h"
#include "functionManager.h"

extern typeSTATUS STSbits;

extern uint8_t MAINBUFFER[];
extern int16_t MAINBUFFERindex;
extern uint8_t SENDBUFFER[];
extern int16_t SENDBUFFERindex;
extern uint8_t frame_started;
extern uint8_t frame_found;

void commInit() {
    MAINBUFFERindex = 0;
    SENDBUFFERindex = 0;
    frame_found = 0;
    frame_started = 0;

    commHardwareInit();
}

void commHardwareInit() {
    Serial.begin(115200);
}

void comm_get_usb_data(void) {
    while (Serial.available() > 0) {
        uint8_t char_received = Serial.read();
        
        if (frame_started == 0) {
            if (char_received == StartCaractere) {
                MAINBUFFER[0] = char_received;
                MAINBUFFERindex = 1;
                frame_started = 1;
            }
        } else {
            if (frame_found == 0) {
                if (char_received == StartCaractere) {
                    MAINBUFFER[0] = char_received;
                    MAINBUFFERindex = 1;
                    frame_started = 1;
                } else if (char_received == ComEndCar1) {
                    MAINBUFFER[MAINBUFFERindex++] = ComEndCar1;
                    MAINBUFFER[MAINBUFFERindex++] = ComEndCar2;
                    frame_found = 1;
                    break;
                } else {
                    MAINBUFFER[MAINBUFFERindex] = char_received;
                    MAINBUFFERindex++;
                    if (MAINBUFFERindex >= STRINGCHARlength) {
                        MAINBUFFERindex = -1;
                        frame_found = 1;
                        break;
                    }
                }
            } else {

            }
        }
    }
}

void comm_process_usb_data(void) {
    if (frame_found == 1) {
        SENDBUFFERindex = FunctionProceed(MAINBUFFER, SENDBUFFER, MAINBUFFERindex, &STSbits);
        frame_found = 0;
        frame_started = 0;
    }
}

void comm_flush_usb_data(void) {
    int i;
    if (SENDBUFFERindex != 0) {
        for (i=0; i<SENDBUFFERindex ; i++) {
            Serial.write(SENDBUFFER[i]);
        }
        SENDBUFFERindex = 0;
    }
}