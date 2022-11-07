#include "common.h"
#include "communication.h"
#include "functionManager.h"
#include "fancontroller.h"
#include "conv_ascii.h"
#include "avr/wdt.h"

typeSTATUS STSbits;

uint8_t flag_noreboot;

uint8_t MAINBUFFER[STRINGCHARlength];
int16_t MAINBUFFERindex;
uint8_t SENDBUFFER[STRINGCHARlength];
int16_t SENDBUFFERindex;
uint8_t frame_started;
uint8_t frame_found;

void setup() {
  flag_noreboot = 1;

  FansInit(&STSbits);

  commInit();
}

void loop() {
  comm_get_usb_data();
  comm_process_usb_data();
  comm_flush_usb_data();

  if (flag_noreboot == 0) {
    wdt_enable(WDTO_15MS);
    while(1);
  }
}