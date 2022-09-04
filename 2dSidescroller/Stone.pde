class Stone {
 float x = 0.0;
 float y = 0.0;
 int width;
 float sy;
 float sx;
 int dmg;
 Stone() {
 x = monkey.x + 40;
 y = monkey.y + 30;
 width = 10;
 sy = 1;
 sx = 1;
 dmg = 10;
 }
 void draw() {

 float d = dist(player.x, player.y, monkey.x, monkey.y);
 collision();
 fill(255, 0, 0);
 ellipse(x, y, width, width);
 if(d< 250 ){
 sx = sx + 0.1;
 x = x - sx;
 if(x == player.w + 50){
 sx = 0;
 }
 }
 }
 boolean collision() {

 float distance = dist(player.x ,player.x + 50 , x, y);
 if (distance < 35) {

 player.hp -= 10;
 return true;
 } else {
 return false;
 }
}
}
