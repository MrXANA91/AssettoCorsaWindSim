#ifndef _COMMON_H
#define _COMMON_H

#include <Arduino.h>
#include "software_info.h"
#include "hardware_info.h"

#define STRINGCHARlength 200

typedef struct
{
    bool FANA_enable;
    bool FANB_enable;
    uint8_t FANA_PWM;
    uint8_t FANB_PWM;
} typeSTATUS;

#endif /* _COMMON_H */