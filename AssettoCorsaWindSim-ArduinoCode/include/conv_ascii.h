#ifndef CONV_ASCII_H
#define CONV_ASCII_H

#include "common.h"

extern "C" {

#define ToAscii(i) ((i)<10) ? ('0'+(i)) : (('A'-10)+(i))

    
    
    
    
// -- Prototypes --
void IntToDecAscii(int16_t, uint8_t*);
void LongToDecAscii(int32_t , uint8_t*);
void UIntToDecAscii(uint16_t, uint8_t*);
void IntTo4Ascii(int16_t, uint8_t*);
void UIntTo4Ascii(uint16_t, uint8_t*);
void LongTo8Ascii(int32_t, uint8_t*);
void IntTo2Ascii(int16_t, uint8_t*);

void ClearZeros(uint8_t*,int);

int OneAsciiToHex(uint8_t*, unsigned int*);
int TwoAsciiToHex(uint8_t*,unsigned int*);
int FourAsciiToHex(uint8_t*, unsigned int*);
int EightAsciiToHex(uint8_t*, int32_t*);

#ifndef FALSE
    #define FALSE   0
#endif
#ifndef TRUE
    #define TRUE    1
#endif

}

#endif /* CONV_ASCII_H */