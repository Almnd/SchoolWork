PImage Monkey;
PImage Crab;
PImage Sand;
PImage PantherL;
PImage PantherR;
PImage Heart [] = new PImage [3];
PImage Stick;
PImage Human;
PImage Bar;
PImage gameBackground;
PImage Player;
PImage ShadowMonster;
float d;
boolean rightPressed =false;
boolean leftPressed = false;
boolean upPressed = false;
boolean atkPressed = false;
boolean moveRight = true;
boolean press1 = false;
boolean press2 = false;
boolean equipped = false;
boolean jumping = false;
String gameState = "START";
Player player = new Player();
Stick stick= new Stick();
Crab crab = new Crab();
Monkey monkey = new Monkey();
Rock rock = new Rock();
Stone stone = new Stone();
Panther panther = new Panther();
Human human = new Human();
ShadowMonster shadowMonster = new ShadowMonster();
Monster monster = new Monster();
void setup () {
 size(800, 450);
 Bar = loadImage("bar.png");
 Sand =loadImage("Sand_Dune.png");
 Human=loadImage("Human.png");
 Player = loadImage("mainCharMan.png");
 gameBackground = loadImage ("gameBackgroundFinish.png");
 ShadowMonster = loadImage("shadowMonsterFinal.png");
 Stick=loadImage("actualStick.png");
 PantherL =loadImage("PantherL.png");
 PantherR =loadImage("PantherR.png");
 Heart[0] = loadImage("Heart.png");
 Heart[1] = loadImage("Heart.png");
 Heart[2] = loadImage("Heart.png");
 Crab =loadImage("OCRAB.png");
 Monkey = loadImage("monkey.png");
}
void draw () {
 println(gameState);
 if (gameState == "START") {
 playGame();
 } else if ( gameState == "RESET") {
 resetGame();
 }else if (gameState == "DEATH"){

 }
}
void playGame() {
 gameFunctions();
}
void gameFunctions() {
 println(player.x, player.y);
 translate(player.x*-1+100, 0);
 image(gameBackground, 0, 0);
 gameBackground.resize(6000, 450);
 player.draw();
 player.display();
 rock.draw();
 stick.draw();
 monster.draw();
 Sand.resize(60, 30);
}
void resetGame() {
 if ( mousePressed == true) {
 player.hp = 30;
 crab.crabHidden = true;
 crab.x=300;
 crab.y=285;
 crab.width=70;
 crab.height=50;
 crab.speedX=0;
 crab.speedY=0;
 crab.dmg = 10;
 crab.death = false;
 human.x=4800;
 human.y=210;
 human.width=260;
 human.height=200;
 human.speedX=0;
 human.speedY=0;
 human.dmg = 10;
 human.hp =30;
 human.death = false;
 monkey.x=1995;
 monkey. y=275;
 monkey.width=70;
 monkey.height=50;
 monkey.speedX=0;
 monkey.speedY=0;
 monkey.dead = false;
 monkey.moveUp = true;
 panther. faceRight = true;
 panther.faceLeft = false;
 panther.x=2900;
 panther.y=225;
 panther.width=250;
 panther.height=130;
 panther.speedX=0;
 panther.speedY=0;
 panther.dmg = 20;
 panther.hp = 30;
 panther.death = false;
 player.death1 = false;
 player.death2 = false;
 player.h0Display = true;
 player.h1Display = true;
 player.h2Display = true;
 player.playerSpeedY = 0;
 player.x= 100;
 player.y=220;
 player.w=100;
 player.h=100;
 player.hp=30;
 rock.speedX = 0;
 rock.speedY = 0;
 rock.life = 255;
 rock.rocksVisible = false;
 rock.rockPickedUp = false;
 rock.rockEquipped = false;
 rock.thrown = false;
 rock.x=200;
 rock.y=320;
 rock.w=10;
 shadowMonster.x=4300;
 shadowMonster.y=210;
 shadowMonster.width=150;
 shadowMonster.height=110;
 shadowMonster.speedX=0;
 shadowMonster.speedY=0;
 shadowMonster.dmg = 10;
 shadowMonster.hp = 30;
 shadowMonster.death = false;
 stick.stickSpeedY = 0;
 stick.stickSpeedX= 0;
 stick.stickPickedUp = false;
 stick.x= 250;
 stick.y=280;
 stick.w=70;
 stick.h=30;
 stick.dmg=25;
 stone.x = monkey.x + 40;
 stone.y = monkey.y + 30;
 stone.width = 10;
 stone.sy = 1;
 stone.sx = 1;
 stone.dmg = 10;

 gameState = "START";
 }
}
void keyPressed() {
 if (keyCode == '1') {
 press1 = true;
 }
 if (keyCode =='2') {
 press2 = true;
 }
 if (keyCode =='A') {
 leftPressed = true;
 }
 if (keyCode == 'D') {
 rightPressed = true;
 }
 if (keyCode == 'W' && !jumping) {
 upPressed = true;
 }
 if (keyCode == ' ' && equipped) {
 atkPressed = true;
 }
}
void keyReleased() {
 if (keyCode == '1') {
 press1 = false;
 }
 if (keyCode == '2') {
 press2 = false;
 }
 if (keyCode == 'A' ){
 leftPressed = false;
 }
 if (keyCode == 'D') {
 rightPressed = false;
 }
 if (keyCode == 'W') {
 upPressed = false;
 }
 if (keyCode == ' ') {
 atkPressed = false;
 }
}
