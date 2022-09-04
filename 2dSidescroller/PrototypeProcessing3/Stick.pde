class Stick {
  int x, y, w, h, dmg;
  float stickSpeedY = 0;
  float stickSpeedX= 0;
  boolean stickPickedUp = false;
  Stick() {
    x= 250;
    y=280;
    w=70;
    h=30;
    dmg=10;
  }
  void display() {
    Stick.resize(w, h);
    image(Stick, x, y);
  }
  void draw() {
    display();
    y += stickSpeedY;
    if (y >= 300 && !stickPickedUp) {
      stickSpeedY =0;
      y = 300;
    } else if (!stickPickedUp) { //item falls to the ground and doesnt fall tforever
      stickSpeedY = +6;
      equipped = false;
    }
    /* Equips item ( If the player is close to the stick,
     and presses &apos;e&apos;, the sticks coordinates 
     are set to the fit the player)
     */
    if (!equipped && player.x > x-20 && player.x < x +70 && key ==
      'e' || key == '1' && stickPickedUp ) {
      x = player.x + 30;
      y = player.y +30;
      equipped = true;
      stickPickedUp = true;
    }
    //Item stays connected to player
    if (equipped && stickPickedUp) {
      x = player.x + 22;
      y = player.y + 58;
    }
    //Unequip
    if (equipped && stickPickedUp && key =='2' ||
      rock.rockEquipped && equipped == true) {
      equipped = false;
      stickPickedUp = true;
    }
    if ( equipped == false && stickPickedUp == true) {
      x = player.x + 80;
      y = 390;
    }
    //Attacking (If the stick is equipped, and &apos; &apos; is pressed, then stick.x +30)
    x += stickSpeedX;
    if (equipped && key == ' ') {
      stickSpeedX = +35;
      atkPressed = true;
    } else {
      stickSpeedX =0;
      atkPressed= false;
    }
    if (x > player.x+60 && equipped==true) {
      stickSpeedX = 0;
      x --;
      atkPressed = false;
    }
  }
}
