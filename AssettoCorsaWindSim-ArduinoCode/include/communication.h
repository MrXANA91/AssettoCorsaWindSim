#ifndef _COMMUNICATION_H
#define _COMMUNICATION_H

#define StartCaractere '='
#define ComEndCar1 '\r'
#define ComEndCar2 '\n'

void comm_get_usb_data(void);
void comm_process_usb_data(void);
void comm_flush_usb_data(void);

#endif /* _COMMUNICATION_H */