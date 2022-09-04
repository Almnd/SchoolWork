class Rock {
  float x;
  float y;
  int w;
  float speedX;
  float speedY;
  int life = 255;
  boolean rocksVisible = false;
  boolean rockPickedUp = false;
  boolean rockEquipped = false;
  boolean thrown = false;
  Rock() {
    x=200;
    y=320;
    w=10;
  }
  void display() {
    fill(200);
    noStroke();
    ellipse(x, y, w, w);
  }
  void draw() {
    collision();
    display();
    // rocK
    y += speedY;
    if (y >= 325 && !rockPickedUp) {
      speedY =0;
      y = 325;
    } else if (!rockPickedUp) { //item falls to the ground and doesnt fall forever
      speedY = +6;
      rockEquipped =false;
    }
    /* Equips item ( If the player is close to the stick,
     and presses &apos;e&apos;, the sticks coordinates
     are set to the fit the player)
     */
    if (!rockEquipped && player.x > x-20 && player.x < x +20 && key ==
      'e' || key == '2' && rockPickedUp == true ) {
      rockEquipped = true;
      rockPickedUp = true;
      x = player.x + 70;
      y = player.y +70;
    }
    //Item stays connected to player
    if (rockEquipped && rockPickedUp ) {
      x = player.x + 75;
      y = player.y+ 70;
    }
    //Unequip
    if (rockEquipped && rockPickedUp && key == '1') {
      rockPickedUp = true;
      rockEquipped = false;
    }
    if (rockPickedUp == true && rockEquipped == false) {
      x = player.x + 50;
      y = 400;
    }
    if ( rockEquipped == true ) {
      for (int i = 0; i < 15; i++) {                                                              // Denne funktion er hvad der får stenene til at rykke sig fremad
        speedX = 0.1 + i ;                                                                       // samt at indskrænke hvor langt stenen må flyve. plus at unequipped
        if (key == ' ' ) {                                                                      // stenen så den ikke bare teleporter tilbage til playeren
          rockEquipped = false;
          rockPickedUp = false;
          x = x + speedX;
        }
      }
    }
  }
  boolean collision() {
    float distance = dist(monkey.x + 30, monkey.y + 30, rock.x+10, 
      rock.y+10);
    if (distance < 35) {

      monkey.dead = true;
      return true;
    } else {
      return false;
    }
  }
}
