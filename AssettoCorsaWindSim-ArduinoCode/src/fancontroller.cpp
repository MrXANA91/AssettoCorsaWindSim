#include "fancontroller.h"

bool FanAEnable(bool on_off, typeSTATUS* STS) {
    if (on_off == true) {
        STS->FANA_enable = 1;
        // ENABLE PWM
        return true;
    } else if (on_off == false) {
        STS->FANA_enable = 0;
        // DESABLE PWM
        return true;
    } else {
        return false;
    }
}

bool FanBEnable(bool on_off, typeSTATUS* STS) {
    if (on_off == true) {
        STS->FANB_enable = 1;
        // ENABLE PWM
        return true;
    } else if (on_off == false) {
        STS->FANB_enable = 0;
        // DESABLE PWM
        return true;
    } else {
        return false;
    }
}

bool FanAPower(uint8_t value, typeSTATUS* STS) {
    if (value>100) {
        return false;
    } else {
        STS->FANA_PWM = value;
        // Change PWM duty cycle
        return true;
    }
}

bool FanBPower(uint8_t value, typeSTATUS* STS) {
    if (value>100) {
        return false;
    } else {
        STS->FANB_PWM = value;
        // Change PWM duty cycle
        return true;
    }
}