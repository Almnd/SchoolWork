class Panther extends Monster {
 boolean death = false;
 boolean faceRight = true;
 boolean faceLeft = false;
 Panther() {
 x=2900;
 y=225;
 width=250;
 height=130;
 speedX=0;
 speedY=0;
 dmg = 20;
 hp =20;
 }
 void displayR() {
 PantherR.resize(width, height);
 image(PantherR, x, y);
 }
 void displayL() {
 PantherL.resize(width, height);
 image(PantherL, x, y);
 }
 void draw() {
 damage();
 checkDeath();
 x +=speedX;
 //De 2 tal krabben går imellem er 100-300
 if (x <3000 && faceRight==true && death == false) {
 speedX=2;
 displayR();

 }
 if (x >3000 && death == false) {
 faceRight=false;
 faceLeft=true;
 displayL();
 speedX=-2;
 }
 if (faceLeft == true && death == false) {
 displayL();
 }
 if (x < 2700 && death == false) {
 faceRight=true;
 faceLeft=false;
 }
 }
 void damage() {

 d= dist(player.x,player.y,x +width/2,y);
 if(d<110 && death == false){
 println("av");
 player.x =player.x +-60;
 player.hp = player.hp - dmg;
 }
 }
 boolean collision( Panther panther , Stick stick) {
 float distance = dist(panther.x+ panther.width/2,
panther.y+panther.height/2, stick.x+80, stick.y-10);
 if (distance < 90 && atkPressed == true) {
 return true;
 } else {
 return false;
 }
}
void checkDeath() {
 if (collision(panther, stick)) {
 panther.hp = panther.hp-stick.dmg;
 println("Dmg " + stick.dmg);
 panther.x = panther.x+70;

 if(hp<0){
 death = true;
 }



 }
}
}
