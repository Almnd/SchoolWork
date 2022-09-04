class ShadowMonster extends Monster {
 boolean death = false;
 ShadowMonster() {
 x=3600;
 y=210;
 width=150;
 height=110;
 speedX=0;
 speedY=0;
 dmg = 10;
 hp = 30;
 }

 void display(){
 ShadowMonster.resize(width,height);
 if(death ==false){
 image(ShadowMonster,x,y);
 }
 }
 void draw() {
 display();
 damage();
 checkDeath();
 x += speedX;
 float d= dist(player.x, player.y, x,y);
 if(d<200){
 speedX =-1;
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
 boolean collision( ShadowMonster shadowMonster , Stick stick) {
 float distance = dist(x+ width/2, y +height/2, stick.x+50, stick.y-10);
 if (distance < 50 && atkPressed == true) {
 return true;
 } else {
 return false;
 }
}
void checkDeath() {
 if (collision(shadowMonster, stick)) {
 hp = hp-stick.dmg;
 println("Dmg " + stick.dmg);
 x = x+70;

 if(hp<0){
 death = true;
 }
 }
}
}
