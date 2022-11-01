#ifndef _FANCONTROLLER_H
#define _FANCONTROLLER_H

#include "common.h"

bool FanAEnable(bool, typeSTATUS*);
bool FanBEnable(bool, typeSTATUS*);
bool FanAPower(uint8_t, typeSTATUS*);
bool FanBPower(uint8_t, typeSTATUS*);

#endif /* _FANCONTROLLER_H */