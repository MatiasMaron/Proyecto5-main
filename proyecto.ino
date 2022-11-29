#include <Keyboard.h>
void setup() {
Serial.begin(9600);
pinMode(2,INPUT_PULLUP);
//Izquierda
pinMode(3,INPUT_PULLUP);
//Derecha
pinMode(4,INPUT_PULLUP);
//Abajo
pinMode(5,INPUT_PULLUP);
//Arriba

}

void loop() {

  if(digitalRead(5) == LOW){
  Keyboard.press('w');
  delay(50);
  }
 if(digitalRead(5) == HIGH){
  Keyboard.release('w');
 }

 
   if(digitalRead(4) == LOW){
  Keyboard.press('s');
  delay(50);
  }
 if(digitalRead(4) == HIGH){
  Keyboard.release('s');
 }
  
  
   if(digitalRead(3) == LOW){
  Keyboard.press('d');
  delay(50);
  }
 if(digitalRead(3) == HIGH){
  Keyboard.release('d');
 }

 
  if(digitalRead(2) == LOW){
  Keyboard.press('a');
  delay(50);
  }
 if(digitalRead(2) == HIGH){
  Keyboard.release('a');
 }
}
