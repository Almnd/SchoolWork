class Monster {
  int x, y;
  int width = 80;
  int height = 100;
  int hp;
  int speedY;
  int speedX;
  int dmg;
  void draw() {
    human.draw();
    monkey.draw();
    crab.draw();
    panther.draw();
    shadowMonster.draw();
    shadowMonster.damage();
    shadowMonster.checkDeath();
    shadowMonster.display();
    shadowMonster.draw();
    shadowMonster.damage();
    shadowMonster.checkDeath();
  }
}
