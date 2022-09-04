class Human extends Monster {
  boolean death = false;
  Human() {
    x=4600;
    y=190;
    width=260;
    height=200;
    speedX=0;
    speedY=0;
    dmg = 10;
    hp =30;
  }
  void display() {
    Human.resize(width, height);
    if (death ==false) {
      image(Human, x, y);
    }
  }
  void draw() {
    damage();
      checkDeath();
    display();
    x += speedX;
    float d= dist(player.x, player.y, x, y);
    if (d<200) {
      speedX =-1;
    }
  }
  void damage() {

    d= dist(player.x, player.y, x +width/2, y);
    if (d<110 && death == false) {
      println("av");
      player.x =player.x +-60;
      player.hp = player.hp - dmg;
    }
  }
  boolean collision() {
    float distance = dist(x+ width/2, y +height/2, stick.x+50, stick.y-10);
    if (distance < 50 && atkPressed == true) {
            println("collision");
      return true;
    } else {
      return false;
    }
  }
  void checkDeath() {
    if (collision()) {
      hp = hp-stick.dmg;
      println("Dmg " + stick.dmg);
      x = x+70;

      if (hp<0) {
        death = true;
      }
    }
  }
}
