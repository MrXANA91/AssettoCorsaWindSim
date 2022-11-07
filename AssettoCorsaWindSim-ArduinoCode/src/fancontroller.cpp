#include "fancontroller.h"

void FansInit(typeSTATUS* STS) {
    STS->FANA_enable = false;
    STS->FANB_enable = false;
    STS->FANA_PWM = 0;
    STS->FANB_PWM = 0;

    FansHardwareInit();
}

void FansHardwareInit() {
    pinMode(PIN_FAN_A, OUTPUT);
    pinMode(PIN_FAN_B, OUTPUT);
    analogWrite(PIN_FAN_A, 0);
    analogWrite(PIN_FAN_B, 0);
}

bool FanAEnable(bool on_off, typeSTATUS* STS) {
    if (on_off == true) {
        STS->FANA_enable = 1;
        analogWrite(PIN_FAN_A, STS->FANA_PWM);
        return true;
    } else if (on_off == false) {
        STS->FANA_enable = 0;
        analogWrite(PIN_FAN_A, 0);
        return true;
    } else {
        return false;
    }
}

bool FanBEnable(bool on_off, typeSTATUS* STS) {
    if (on_off == true) {
        STS->FANB_enable = 1;
        analogWrite(PIN_FAN_B, STS->FANB_PWM);
        return true;
    } else if (on_off == false) {
        STS->FANB_enable = 0;
        analogWrite(PIN_FAN_B, 0);
        return true;
    } else {
        return false;
    }
}

bool FanAPower(uint8_t value, typeSTATUS* STS) {
    STS->FANA_PWM = value;
    analogWrite(PIN_FAN_A, STS->FANA_PWM);
    return true;
}

bool FanBPower(uint8_t value, typeSTATUS* STS) {
    STS->FANB_PWM = value;
    analogWrite(PIN_FAN_B, STS->FANB_PWM);
    return true;
}