#ifndef _FUNCTION_MANAGER_H
#define _FUNCTION_MANAGER_H

#include "common.h"

uint16_t FunctionProceed(uint8_t*, uint8_t*, int16_t, typeSTATUS*);

#define ResponseFirstCar '>'

enum {
    NoResponse = 0,                 // No response
    FunctionIsUnknown,              // ER00
    MssgIsTooLong,                  // ER01
    GetVersionIsOK,
    ResetIsOK,
    ResetIsKO,                      // ER02
    FanAEnableOK,
    FanAEnableNoArgument,           // ER03
    FanAEnableNotAsciiArgument,     // ER04
    FanAEnableIsKO,                 // ER05
    FanBEnableOK,
    FanBEnableNoArgument,           // ER06
    FanBEnableNotAsciiArgument,     // ER07
    FanBEnableIsKO,                 // ER08
    FanAPowerOK,
    FanAPowerNotEnoughArgument,     // ER09
    FanAPowerNotAsciiArgument,      // ER0A
    FanAPowerWrongArgument,         // ER0B
    FanBPowerOK,
    FanBPowerNotEnoughArgument,     // ER0C
    FanBPowerNotAsciiArgument,      // ER0D
    FanBPowerWrongArgument,         // ER0E
    SoftwareError = 200             // ER0F
};                  // unknown error : ER10

#define FctNoResponse   0xFFFF
#define FctTooLong      0xFFFE

#define FctGetVersion   (('R'<<8)|'?')
#define FctReset        (('W'<<8)|'#')

#define FctFanAEnable   (('A'<<8)|'E')
#define FctFanBEnable   (('B'<<8)|'E')
#define FctFanAPower    (('A'<<8)|'P')
#define FctFanBPower    (('B'<<8)|'P')

#endif /* _FUNCTION_MANAGER_H */