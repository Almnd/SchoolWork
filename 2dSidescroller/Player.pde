class Player {
  boolean death1 = false;
  boolean death2 = false;
  boolean h0Display = true;
  boolean h1Display = true;
  boolean h2Display = true;
  int x, y, w, h, hp;
  float playerSpeedY = 0;
  Player() {
    x= 100;
    y=220;
    w=100;
    h=100;
    hp=30;
  }
  void display() {
    Player.resize(w, h);
    image(Player, x, y);
  }
  void draw() {

    movement();

    heart();
    y += playerSpeedY;
    if (y >= 220) {
      playerSpeedY =0;
      jumping = false;
    } else {
      playerSpeedY ++;
    }
    //If player reaches certain height, jumping = false
    if (y <= 180) {
      upPressed = false;
    }
  }
  void movement() {
    if (keyPressed) {
      if (rightPressed) {
        player.x=player.x+2;
      }
      if (leftPressed) {
        player.x=player.x-2;
      }
      if (upPressed) {
        playerSpeedY =-10;
        jumping = true;
      }
    }
  }
  void heart() {


    Heart[0].resize(40, 30);
    Heart[1].resize(40, 30);
    Heart[2].resize(40, 30);

    if (h0Display ==true) {
      image(Heart[0], player.x, 10);
    }
    if (h1Display ==true) {
      image(Heart[1], player.x+40, 10);
    }
    if (h2Display ==true) {
      image(Heart[2], player.x +80, 10);
    }

    if (player.hp < 21) {
      h2Display = false;
    }
    if (player.hp < 11) {
      h1Display = false;
    }
    if (player.hp < 1) {
      gameState = "RESET";
      h0Display = false;

      println("DEATH");
    }
  }
}
