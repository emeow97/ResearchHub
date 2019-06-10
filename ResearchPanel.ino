
// define pins and other variables
const int latchPin = 12;
const int clockPin = 13;
const int dataPin  = 11;

// for time limit
unsigned long DELAY_TIME = 10000; // 10 sec
unsigned long delayStart = 0; // the time the delay started
int light = -1;
int states[8];

const String fields[20] = {"Artificial Intelligence", "Security & Privacy",
  "Computer Graphics, Vision, Animation, & Game Science", "Computing for Development",
  "Computational & Synthetic Biology", "Theory of Computation", 
  "Wireless & Sensor Systems", "Robotics",
  "Human Computer Interaction & Accessible Technology", "Augmented & Virtual Reality",
  "Machine Learning", "Data Management & Visualization", 
  "Computer Architecture", "Fabrication",
  "Data Science", "Systems & Networking",
  "Molecular Information Systems", "Natural Language Processing", 
  "Ubiquitous Computing", "Programming Languages & Software Engineering"};
  
//  0 zero = Artificial Intelligence
//  1 one = Security & Privacy
//  2 two = Computer Graphics, Vision, Animation, & Game Science
//  3 three = Computing for Development
//  4 four = Computational & Synthetic Biology
//  5 five = Theory of Computation
//  6 six = Wireless & Sensor Systems
//  7 seven = Robotics

// 8 zero one = Human Computer Interaction & Accessible Technology
// 9 zero two = Augmented & Virtual Reality
// 10 zero three = Machine Learning
// 11 one two = Data Management & Visualization
// 12 one three = Computer Architecture
// 13 two three = Fabrication

// 14 four five = Data Science
// 15 four six = Systems & Networking
// 16 four seven = Molecular Information Systems
// 17 five six = Natural Language Processing
// 18 five seven = Ubiquitous Computing
// 19 six seven = Programming Languages & Software Engineering

// setup the correct pins and initialize SPI library
void setup() {
  Serial.begin(9600);
  // start timer
  delayStart = millis();
  
  // setup pins
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin,  OUTPUT);
  pinMode(2,  INPUT);
  pinMode(3,  INPUT);
  pinMode(4,  INPUT);
  pinMode(5,  INPUT);
  pinMode(6,  INPUT);
  pinMode(7,  INPUT);
  pinMode(8,  INPUT);
  pinMode(9,  INPUT);
}

void loop() {
  for (int i = 0; i < 8; i ++) {
    states[i] = digitalRead(i + 2);
  }

  if ((millis() - delayStart) >= DELAY_TIME) {
    updateLight(20);
    delayStart = millis();
  }
  
  if (states[0] == HIGH) {
    if (states[1] == HIGH) { // zero one = Artificial Intelligence
      updateLight(8);
    } else if (states[2] == HIGH) { // zero two = Augmented & Virtual Reality
      updateLight(9);
    } else if (states[3] == HIGH) { // zero three = Computational & Synthetic Biology
      updateLight(10);
    } else { // zero = Computing for Development
      updateLight(0);
    }
    
  } else if (states[4] == HIGH) {
    if (states[5] == HIGH) { // four five = Security & Privacy
      updateLight(14);
    } else if (states[6] == HIGH) { // four six = Systems & Networking
      updateLight(15);
    } else if (states[7] == HIGH) { // four seven = Theory of Computation
      updateLight(16);
    } else { // four = Machine Learning
      updateLight(4);
    }
    
  } else if (states[1] == HIGH) {
    if (states[2] == HIGH) { // one two = Data Management & Visualization
      updateLight(11);
    } else if (states[3] == HIGH) { // one three = Computer Architecture
      updateLight(12);
    } else { // one = Data Science
      updateLight(1);
    }
    
  } else if (states[5] == HIGH) {
    if (states[6] == HIGH) { // five six = Natural Language Processing
      updateLight(17);
    } else if (states[7] == HIGH) { // five seven = Ubiquitous Computing
      updateLight(18);
    } else { // five = Molecular Information Systems
      updateLight(5);
    }
    
  } else if (states[2] == HIGH) {
    if (states[3] == HIGH) { // two three = Computer Graphics, Vision, Animation, & Game Science
      updateLight(13);
    } else { // two = Fabrication
      updateLight(2);
    }
    
  } else if (states[6] == HIGH) {
    if (states[7] == HIGH) { // six seven = Wireless & Sensor Systems
      updateLight(19);
    } else { // six = Programming Languages & Software Engineering
      updateLight(6);
    }
    
  } else if (states[3] == HIGH) { // three = Human Computer Interaction & Accessible Technology
    updateLight(3);
  } else if (states[7] == HIGH) { // seven = Robotics
    updateLight(7);
  }
}


void updateLight(int lighted) {
  delayStart = millis();
  // intern var's
  byte HBYTE = 0;
  byte MBYTE = 0;
  byte LBYTE = 0;
  int HByte = 0;
  int MByte = 0;
  int LByte = 0;

  if (lighted < 8) {
    LByte = 1 << (lighted);
  } else if (lighted < 16) {
    MByte = 1 << (lighted - 8);
  } else if (lighted < 20) {
    HByte = 1 << (lighted - 16);
  } 

  LBYTE = LByte;
  MBYTE = MByte;
  HBYTE = HByte;
  
  //IC Control
  //1. Latch down
  digitalWrite(latchPin, LOW);

  //2. Data_shiftout 2x8Bit 
  shiftOut(dataPin,clockPin, MSBFIRST, HBYTE);
  shiftOut(dataPin,clockPin, MSBFIRST, MBYTE);
  shiftOut(dataPin,clockPin, MSBFIRST, LBYTE);

  //3. Latch active
  digitalWrite(latchPin, HIGH);
  // print out field name
  if (lighted < 20 && light != lighted) {
    Serial.println(fields[lighted]);
    light = lighted;
  } else if (lighted == 20) {
    light = -1;
    Serial.println("none");
  }
}


