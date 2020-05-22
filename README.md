# virtual-bowling
The theme of this project is to create a device which will interlink our physical with digital world. 

In this we decided to make a such device which helps us in gaming so that you can feel that we are in gaming world. 
this project idea was actually taken form project form this site https://people.ece.cornell.edu/land/courses/ece4760/FinalProjects/f2014/mht52_pb477_dma234/mht52_pb477_dma234/ECE%204760.html
in which they done similar to ours but they do this all on a microcontroller ATMega1284 we done it on arduino and unity.
The aim of this project is to control game with hand moments and gestures so that we can get a better experience of gamming. In this project ball's direction and force is controlled by using had moments. It is done by using from mpu 6050 accelerometer for force and direction while flex sensors for gestures and Arduino for communicating with game with Bluetooth. 
this repo contains both Arduino code and unity game. by default, port was set to COM6 at 9600 baud rate you can change this in pin.cs located in assets folder 
sorry to say that this was just a demo type so code was not optimized well, and game was not designed with much graphics and with few game rules, but you can customize it as you want. Due to some factors we published it before taking it to full extent. 
making: 
firstly, we need glove to make this and fix flex sensor to it. then make voltage divider with flex sensor and a resistor in series. connect resistor end to gnd and flex end to vcc. connect A0 of Arduino middle junction of voltage divider and take few readings when you close and open finger and estimate rough threshold value which can finely classify closing and opening of finger. change thresh vale in Arduino code with this. 
next place accelerometer in stable position of glove such that z axis is perpendicular to your glove(palm). connections to accelerometer are given in Arduino code. 
now connect Arduino to pc with wire or Bluetooth as your wish. 
gameplay: 
first keep finger open to which sensor was attached then by rotating your hand you can set to which direction ball has to move and then close finger so that direction was fixed. While finger in closed position now try to place z perpendicular to ground and while moving your hand release finger so ball moves. 
