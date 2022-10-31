#include "common.h"
#include "communication.h"
#include "functionManager.h"
#include "conv_ascii.h"

typeSTATUS STSbits;

uint8_t flag_noreboot;

uint8_t MAINBUFFER[STRINGCHARlength];
int16_t MAINBUFFERindex;
uint8_t SENDBUFFER[STRINGCHARlength];
int16_t SENDBUFFERindex;
uint8_t frame_started;
uint8_t frame_found;

void setup() {
  STSbits.FANA_enable = false;
  STSbits.FANB_enable = false;
  STSbits.FANA_PWM = 0;
  STSbits.FANB_PWM = 0;

  flag_noreboot = 1;

  MAINBUFFERindex = 0;
  SENDBUFFERindex = 0;
  frame_found = 0;
  frame_started = 0;

  Serial.begin(115200);
}

void loop() {
  comm_get_usb_data();
  comm_process_usb_data();
  comm_flush_usb_data();
}