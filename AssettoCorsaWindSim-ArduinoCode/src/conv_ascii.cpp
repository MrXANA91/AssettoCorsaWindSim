#include "conv_ascii.h"
#include "ctype.h"

#define	NotCaseSensitive

//******************************************************************************
//*********************************** MACROS ***********************************
//******************************************************************************
#define AsciiToHex(H) (H >= 'A' ? (H-'A'+10) : (H - '0'))

#define DivByX(var, res, X) {       \
            while (var >= X) {      \
                var -= X;           \
                res += (X/10);      \
            }}

#define Div16By10(var16, res16) {               \
            DivByX(var16, res16,     10000U );  \
            DivByX(var16, res16,      1000U );  \
            DivByX(var16, res16,       100U );  \
            DivByX(var16, res16,        10U );  \
            }

#define Div32By10(var32, res32) {               \
            DivByX(var32, res32, 1000000000UL); \
            DivByX(var32, res32,  100000000UL); \
            DivByX(var32, res32,   10000000UL); \
            DivByX(var32, res32,    1000000UL); \
            DivByX(var32, res32,     100000UL); \
            DivByX(var32, res32,      10000U ); \
            DivByX(var32, res32,       1000U ); \
            DivByX(var32, res32,        100U ); \
            DivByX(var32, res32,         10U ); \
            }

//******************************************************************************
//************************************ CODE ************************************
//******************************************************************************

//------------------------------------------------------------------------------
//  -- IntToDecAscii --
//------------------------------------------------------------------------------
void IntToDecAscii(int16_t i, uint8_t* BCD)
{
    if (i<0) {
        BCD[0]='-';
        i = -i;
    }
    else
        BCD[0]=' ';

    uint16_t temp = (uint16_t) i;
	int k=5;
    while(k) {
        uint16_t result = 0;
        Div16By10(temp, result);
        BCD[k--] = '0'+ (uint8_t) temp;
        temp = result ;
    }
} //

//------------------------------------------------------------------------------
//  -- LongToDecAscii --
//------------------------------------------------------------------------------
//void LongToDecAscii(long int i, char* BCD)
void LongToDecAscii(int32_t i, uint8_t* BCD)
{
	if (i<0) {
		BCD[0]='-';
		i = -i;
	}
	else {
		BCD[0]=' ';
	}
    
    uint32_t temp = (uint32_t) i;
	int k = 10;
	while(k) {
        uint32_t result = 0;
        Div32By10(temp, result);
        BCD[k--] = '0'+ (uint8_t) temp;
        temp = result ;
	}
} //


//------------------------------------------------------------------------------
//  -- UIntToDecAscii --
//------------------------------------------------------------------------------
void UIntToDecAscii(uint16_t i, uint8_t* BCD)
{
    BCD[0]=' ';
    uint16_t temp = (uint16_t) i;
	int k=5;
    while(k) {
        uint16_t result = 0;
        Div16By10(temp, result);
        BCD[k--] = '0'+ (uint8_t) temp;
        temp = result ;
    }
} //

//------------------------------------------------------------------------------
//  -- IntTo4Ascii --
//------------------------------------------------------------------------------
void IntTo4Ascii(int16_t i, uint8_t* TXT)
{
	uint8_t c;
	int	k=4;

	while(k)
	{
		c = i&0xF;
		TXT[--k] = (c<10) ? ('0'+c) : (('A'-10)+c);
		i=i>>4;
	}
} //

//------------------------------------------------------------------------------
//  -- UIntTo4Ascii --
//------------------------------------------------------------------------------
void UIntTo4Ascii(uint16_t i, uint8_t* TXT)
{
	uint8_t c;
	int	k=4;

	while(k)
	{
		c = i&0xF;
		TXT[--k] = (c<10) ? ('0'+c) : (('A'-10)+c);
		i=i>>4;
	}
} //

//------------------------------------------------------------------------------
//  -- LongTo8Ascii --
//------------------------------------------------------------------------------
void LongTo8Ascii(int32_t i, uint8_t* TXT)
{
	uint8_t c;
	int	k=8;

	while(k)
	{
		c = i&0xF;
		TXT[--k] = (c<10) ? ('0'+c) : (('A'-10)+c);
		i=i>>4;
	}
}

//
//------------------------------------------------------------------------------
//  -- IntTo2Ascii --
//------------------------------------------------------------------------------
void IntTo2Ascii(int16_t i, uint8_t* TXT)
{
	uint8_t c;
	int	k=2;

	while(k)
	{
		c = i&0xF;
		TXT[--k] = (c<10) ? ('0'+c) : (('A'-10)+c);
		i=i>>4;
	}
} //

//------------------------------------------------------------------------------
//  -- ClearZeros --
//------------------------------------------------------------------------------
void ClearZeros(uint8_t* TXT, int TAILLE)
{
	int k=1;
	while((TAILLE--)&&k)
	{
		if (*TXT != ' ')
			if (*TXT != '+')
				if (*TXT != '-')
				{
					if (*TXT=='0')
						*TXT = ' ';
					else
						k=0;
				}
		TXT++;
	}
} //

//------------------------------------------------------------------------------
// * -- OneAsciiToHex --
//------------------------------------------------------------------------------
int OneAsciiToHex(uint8_t* STR, unsigned int* RES)
{
	#ifdef	NotCaseSensitive
		if (islower(STR[0])) {
			STR[0] -= 0x20;
		}
	#endif

	if ((isxdigit(STR[0])) == 0) {
		return(FALSE);
	}

	*RES  = AsciiToHex( STR[0] );
	return(TRUE);
} //


//------------------------------------------------------------------------------
// * -- TwoAsciiToHex --
//------------------------------------------------------------------------------
int TwoAsciiToHex(uint8_t* STR, unsigned int* RES)
{
	int i;

	#ifdef	NotCaseSensitive
		if (islower(STR[0])) {
			STR[0] -= 0x20;
		}
		if (islower(STR[1])) {
			STR[1] -= 0x20;
		}
	#endif

	i =2;
	i -= isxdigit(STR[0]);
	i -= isxdigit(STR[1]);
	if (i>0) {
		return(FALSE);
	}

	*RES  = AsciiToHex( STR[0] );
	*RES  = (*RES)<<4;
	*RES |= AsciiToHex( STR[1] );

	return(TRUE);
} //

//------------------------------------------------------------------------------
// * -- FourAsciiToHex --
//------------------------------------------------------------------------------
int FourAsciiToHex(uint8_t* STR, unsigned int* RES)
{
	int i=4;

	#ifdef	NotCaseSensitive
		while(i) {
			if (islower(STR[--i])) {
				STR[i] -= 0x20;
			}
		}
		i = 4;
	#endif

	i -= isxdigit(STR[0]);
	i -= isxdigit(STR[1]);
	i -= isxdigit(STR[2]);
	i -= isxdigit(STR[3]);
	if (i>0) {
		return(FALSE);
	}

	*RES  = AsciiToHex( STR[0] );
	*RES  = (*RES)<<4;
	*RES |= AsciiToHex( STR[1] );
	*RES  = (*RES)<<4;
	*RES |= AsciiToHex( STR[2] );
	*RES  = (*RES)<<4;
	*RES |= AsciiToHex( STR[3] );

	return(TRUE);
} //


//------------------------------------------------------------------------------
// * -- EightAsciiToHex --
//------------------------------------------------------------------------------
int EightAsciiToHex(uint8_t* STR, int32_t* RES)
{
	int i=8;

	#ifdef	NotCaseSensitive
		while(i) {
			if (islower(STR[--i])) {
				STR[i] -= 0x20;
			}
		}
		i = 8;
	#endif

    int k;
    for (k=0;k<8;k++) {
        i -= isxdigit(STR[k]);     
	}   
	if (i>0) {
		return(FALSE);
	}
   
  	*RES  = AsciiToHex( STR[0] );
    for ( i=1 ; i<8 ; i++)
    {
        *RES  = (*RES)<<4;
        *RES |= AsciiToHex( STR[i] );
    }
	return(TRUE);
} //

