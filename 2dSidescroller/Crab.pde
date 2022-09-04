class Crab extends Monster {
 boolean crabHidden = true;
 boolean death = false;
 Crab() {
 x=300;
 y=285;
 width=70;
 height=50;
 speedX=0;
 speedY=0;
 dmg = 10;
 }
 void display() {
 Crab.resize(width, height);
 image(Crab, x, y);
 }
 void draw() {
 damage();
 checkDeath();
 if (crabHidden == true) {
 image(Sand, x, y+5);
 }
 d = dist(player.x, player.y+65, x, y);
 if (d<100) {
 crabHidden =false;
 }
 if (crabHidden == false && death == false) {
 display();
 //Crab movement
 x +=speedX;
 //De 2 tal krabben går imellem er 100-300
 if (x <500 && moveRight == true) {
 speedX=2;
 }
 if (x >500) {
 moveRight = false;
 speedX=-2;
 }
 if (x < 200) {
 moveRight = true;
 }
 }
 }
 void damage() {
 if (player.x == crab.x -10 && jumping == false && death == false) {
 player.x =player.x +-60;
 player.hp = player.hp - dmg;
 }
 if (player.x == crab.x+60 && jumping == false && death == false) {
 println("av2");
 player.x = player.x +60;
 player.hp = player.hp - dmg;
 }
 }
 void checkDeath() {
 if (player.x+30 >= x+10 && player.y+60 >=y-20 && player.x <=x+30 &&
player.y+50 <= y+10 && jumping == true) {
 death=true;

 }
 }
}
