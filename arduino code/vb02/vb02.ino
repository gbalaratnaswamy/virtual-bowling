// MPU 6050   --->   Arduino
//
//  VCC   ----->   3.3v
//  GND   ----->   GND
//  SCL   ----->   A5 pin
//  SDA   ----->   A4 pin*/
 
 
#include<Wire.h>
#include<SoftwareSerial.h>
SoftwareSerial mySerial(10,11);
int thresh =500;
const int MPU=0x68;  // I2C address of the MPU-6050
int16_t AcX,AcY,AcZ,Tmp,GyX,GyY,GyZ;  //previous values
int g,gp=0;  //input from gestures
int pax,pay,paz;
 
// value returned is in interval [-32768, 32767] so for normalize multiply GyX and others for gyro_normalizer_factor
// float gyro_normalizer_factor = 1.0f / 32768.0f;
 
void setup(){
  mySerial.begin(9600);
  Wire.begin();
  Wire.beginTransmission(MPU);
  Wire.write(0x6B);  // PWR_MGMT_1 register
  Wire.write(0);     // set to zero (wakes up the MPU-60  50)
  Wire.endTransmission(true);
  Serial.begin(9600);
  Wire.beginTransmission(MPU);
  Wire.write(0x3B);  // starting with register 0x3B (ACCEL_XOUT_H)
  Wire.endTransmission(false);
  Wire.requestFrom(MPU,6,true);  // request a total of 14 registers
  pax=Wire.read()<<8|Wire.read();  // 0x3B (ACCEL_XOUT_H) & 0x3C (ACCEL_XOUT_L)    
  pay=Wire.read()<<8|Wire.read();  // 0x3D (ACCEL_YOUT_H) & 0x3E (ACCEL_YOUT_L)
  paz=Wire.read()<<8|Wire.read();  // 0x3F (ACCEL_ZOUT_H) & 0x40 (ACCEL_ZOUT_L)
}
 
 
void loop(){
  g =gest();
  Wire.beginTransmission(MPU);
  Wire.write(0x3B);  // starting with register 0x3B (ACCEL_XOUT_H)
  Wire.endTransmission(false);
  Wire.requestFrom(MPU,6,true);  // request a total of 14 registers
  AcX=(Wire.read()<<8|Wire.read());*0.25+pax*0.75;  // 0x3B (ACCEL_XOUT_H) & 0x3C (ACCEL_XOUT_L)    
  AcY=(Wire.read()<<8|Wire.read());*0.25+pay*0.75;  // 0x3D (ACCEL_YOUT_H) & 0x3E (ACCEL_YOUT_L)
  AcZ=(Wire.read()<<8|Wire.read());*0.25+paz*0.75;  // 0x3F (ACCEL_ZOUT_H) & 0x40 (ACCEL_ZOUT_L)
 if(g==gp&&g==0){
  int a=map(AcX,-32768,32768,-180,180);
  mySerial.println(a);
  }
  else if(g!=gp&&g==0){
      for(int i=0;i<20;i++){
  mySerial.println("5000");
  }
  delay(500);
  gp=g;
    
  }
  else if (g!=gp&&g==1){
      for(int i=0;i<20;i++){
  mySerial.println("3000");
  }
  delay(500);
  gp=g;
    
  }
  else if(g==gp&&g==1){
  int a=abs(map(AcZ,-32768,32768,-2800,2800)-150);
  mySerial.println(a);
  }
  delay(50);
 pax=AcX;
 pay=AcY;
 paz=AcZ;
}
int gest(){
  if(analogRead(A0)>thresh){
    return 1;
  }
  else{
    return 0;
  }
}
/* Serial.print(";"); Serial.print(AcY); Serial.print(";"); Serial.print(AcZ); Serial.print(";");
  Serial.print(GyX); Serial.print(";"); Serial.print(GyY); Serial.print(";"); Serial.print(GyZ); Serial.println("");*/
