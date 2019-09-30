using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

using Microsoft.Xna.Framework.Audio;


namespace CircusV2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
   
     
    public class Game1 : Game
    {
        Song cir;
        Song tu;
        Song mainon;

        SoundEffect effect;

        SoundEffect effect2;

        SoundEffect circus;
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int W, H;
        
        //scane pic
        Texture2D bgGroundPic;
        Texture2D bgSkyPic;
        Texture2D bgSkyPic2;
        Texture2D bgSkyPic3;
        Texture2D bgMountainPic;
        
        //ground pic
        Texture2D gPic100;
        Texture2D gPic250;
        Texture2D gPic800;

        //Rock pic
        Texture2D RockPic;

        Texture2D FireRingB;
        Texture2D FireRingF;

        //coin pic
        Texture2D CoinPic;
        Texture2D goal1Pic;
        Texture2D goal2Pic;

        //boss pic
        Texture2D BossPic;
        Texture2D bulletsbossPic;

        Player P1;
        Player P2;

        Texture2D RedWin;
        Texture2D BlueWin;

        //initialize list
        List<Ground> groundList1;
        List<Ground> groundList2;
        List<Ground> groundList3;

        List<Rock> rockList2;
        //List<Rock> rockList3;

        List<Fire> FireList1;
        List<Fire> FireList2;
        //List<Fire> FireList3;

        int HP = 100;
        Boss boss;

        //stage 1
        Ground ground;
        Ground g100_maps1_1;
        Ground g100_maps1_2;
        Ground g800_maps1;
               

        Fire fireLeft_maps1;
        Fire fireRight_maps1;

        Gold Coin_maps1;
        Gold goal1_maps1;
        Gold goal2_maps1;

        //stage 2
        Ground ground2;
        Ground g100_maps2;
        Ground g250_maps2_left;
        Ground g250_maps2_right;

        Rock rock_left;
        Rock rock_right;
        Rock rock_g_left;
        Rock rock_g_right;

        Fire fireLeft_maps2;
        Fire fireRight_maps2;

        Gold Coin_maps2;
        Gold goal1_maps2;
        Gold goal2_maps2;

        //stage 3
        Ground ground3;
        Ground g100_maps3_left;
        Ground g100_maps3_right;
        Ground g800_maps3;
        Ground g100_maps3_center;

        Gold Coin_maps3_1;

        Gold goal1_maps3;
        Gold goal2_maps3;


        Bullets bulletP1;
        Bullets bulletP2;
        Bullets bulletsBoss;

        int timer = 0;
        Timer WaitFall = new Timer(1000);


        SpriteEffects flip  = SpriteEffects.FlipHorizontally;
        SpriteEffects flip2 = SpriteEffects.None;

        bool jumping; 
        float jumpspeed = 25;

        bool jumping2;
        float jumpspeed2 = 25;

        SpriteFont font;


        KeyboardState currentKS;
        KeyboardState previousKs;

        int play1 = 0;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            W = 1280;
            H = 720;
            graphics.PreferredBackBufferHeight = H;
            graphics.PreferredBackBufferWidth = W;
            graphics.ApplyChanges();                      

            P1 = new Player();
            P2 = new Player();


            
            //stage1--------------------------stage1
            //add coid maps 1
            Coin_maps1 = new Gold();
            goal1_maps1 = new Gold();
            goal2_maps1 = new Gold();

            //Add ground list stage 1
            ground = new Ground();
            g100_maps1_1 = new Ground();
            g100_maps1_2 = new Ground();
            g800_maps1 = new Ground();
            groundList1 = new List<Ground>();
            groundList1.Add(ground);
            groundList1.Add(g100_maps1_1);
            groundList1.Add(g100_maps1_2);
            groundList1.Add(g800_maps1);            

            //Add ground list stage 1
            fireRight_maps1 = new Fire();
            fireLeft_maps1 = new Fire();
            FireList1 = new List<Fire>();
            FireList1.Add(fireRight_maps1);
            FireList1.Add(fireLeft_maps1);

            //stage2--------------------------------stage2
            //Add ground list stage 2
            ground2 = new Ground();
            g100_maps2 = new Ground();
            g250_maps2_left = new Ground();
            g250_maps2_right = new Ground();
            groundList2 = new List<Ground>();
            groundList2.Add(ground2);
            groundList2.Add(g100_maps2);
            groundList2.Add(g250_maps2_left);
            groundList2.Add(g250_maps2_right);

            //add rock
            rock_left = new Rock();
            rock_right = new Rock();
            rock_g_left = new Rock();
            rock_g_right = new Rock();
            rockList2 = new List<Rock>();
            rockList2.Add(rock_g_left);
            rockList2.Add(rock_g_right);
            rockList2.Add(rock_left);
            rockList2.Add(rock_right);

            

            //add coin
            Coin_maps2 = new Gold();
            goal1_maps2 = new Gold();
            goal2_maps2 = new Gold();

            //addfire
            fireRight_maps2 = new Fire();
            fireLeft_maps2 = new Fire();
            FireList2 = new List<Fire>();
            FireList2.Add(fireRight_maps2);
            FireList2.Add(fireLeft_maps2);

            //stage 3 -------------------------------stage 3
            //add ground
            ground3 = new Ground();
            g100_maps3_left = new Ground();
            g100_maps3_right = new Ground();
            g100_maps3_center = new Ground();
            g800_maps3 = new Ground();
            groundList3 = new List<Ground>();
            groundList3.Add(ground3);
            groundList3.Add(g100_maps3_left);
            groundList3.Add(g100_maps3_right);
            groundList3.Add(g800_maps3);
            groundList3.Add(g100_maps3_center);

            Coin_maps3_1 = new Gold();

            goal1_maps3 = new Gold();
            goal2_maps3 = new Gold();

            //bullet
            bulletP1 = new Bullets();
            bulletP2 = new Bullets();

            boss = new Boss();
            bulletsBoss = new Bullets();
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

         
            // TODO: use this.Content to load your game content here
            //bullet
            Texture2D bulletPic = Content.Load<Texture2D>("bullet/bullet");

           
            

            RedWin = Content.Load<Texture2D>("RedWin");
            BlueWin = Content.Load<Texture2D>("BlueWin");

            bgGroundPic = Content.Load<Texture2D>("bg/ground");
            bgSkyPic = Content.Load<Texture2D>("bg/sky");
            bgSkyPic2 = Content.Load<Texture2D>("bg/sky2");
            bgSkyPic3 = Content.Load<Texture2D>("bg/sky3");
            bgMountainPic = Content.Load<Texture2D>("bg/mountain");
            gPic100 = Content.Load<Texture2D>("bg/Tile");
            gPic250 = Content.Load<Texture2D>("bg/Tile250");
            gPic800 = Content.Load<Texture2D>("bg/Tile800");

            RockPic = Content.Load<Texture2D>("bg/Rock");

            FireRingB = Content.Load<Texture2D>("firering/fireback");
            FireRingF = Content.Load<Texture2D>("firering/fireflont");

            CoinPic = Content.Load<Texture2D>("bg/coin");
            goal1Pic = Content.Load<Texture2D>("bg/goal1");
            goal2Pic = Content.Load<Texture2D>("bg/goal2");

            bulletsbossPic = Content.Load<Texture2D>("bullet/BulletBoss");
            BossPic = Content.Load<Texture2D>("bg/Boss");

            Animation playerAnimation1 = new Animation();
            Animation playerAnimation2 = new Animation();

            Texture2D playerTexture1 = Content.Load<Texture2D>("player/PlayerRed");
            Texture2D playerTexture2 = Content.Load<Texture2D>("player/PlayerBlue");


            

            //initilize(Texture2D Pic, Vector2 Pos)
            ground.Initilize(bgGroundPic, new Vector2(0, H - bgGroundPic.Height));
            
            //stage 1-------------------------------------------------------------
            //player 1
            playerAnimation1.Initialize(playerTexture1, new Vector2(100, H - bgGroundPic.Height), 100, 100, 8, 100, Color.White, 1.0f, true);
            P1.InitializeAnimation(playerAnimation1, new Vector2(100, H - bgGroundPic.Height));

            //player2
            playerAnimation2.Initialize(playerTexture2, new Vector2(W - 100, H - bgGroundPic.Height), 100, 100, 8, 100, Color.White, 1.0f, true);
            P2.InitializeAnimation(playerAnimation2, new Vector2(W - 100, H - bgGroundPic.Height));
                                
           
            g100_maps1_1.Initilize(gPic100, new Vector2(0, H - bgGroundPic.Height - 220));
            g100_maps1_2.Initilize(gPic100, new Vector2(W - gPic100.Width, H - bgGroundPic.Height - 220));
            g800_maps1.Initilize(gPic800, new Vector2(W / 2 - 400, 400));

            //coin
            Coin_maps1.Initilize(CoinPic, new Vector2(W / 2 - CoinPic.Width / 2, g800_maps1.Position.Y - CoinPic.Height));
            goal1_maps1.Initilize(goal1Pic, new Vector2(W / 2, ground.Position.Y - goal1Pic.Height));
            goal2_maps1.Initilize(goal2Pic, new Vector2(W / 2 - goal2Pic.Width, ground.Position.Y - goal2Pic.Height));

            //firering
            fireLeft_maps1.Initilize(FireRingF, FireRingB, new Vector2(130, H - bgGroundPic.Height - FireRingB.Height - 350));
            fireRight_maps1.Initilize(FireRingF, FireRingB, new Vector2(W - 130 - FireRingB.Width - FireRingF.Width, H - bgGroundPic.Height - FireRingB.Height - 350));


            //stage 2  -------------------------------------------------------------
            ground2.Initilize(bgGroundPic, new Vector2(0, H - bgGroundPic.Height));
            g100_maps2.Initilize(gPic100, new Vector2(W / 2 - gPic100.Width / 2, ground.Position.Y - gPic100.Height));
            g250_maps2_left.Initilize(gPic250, new Vector2(0, 300));
            g250_maps2_right.Initilize(gPic250, new Vector2(W - gPic250.Width, 300));

            rock_left.Initilize(RockPic, new Vector2(g250_maps2_left.Width - RockPic.Width, 300 - RockPic.Height));
            rock_right.Initilize(RockPic, new Vector2(W - gPic250.Width, 300 - RockPic.Height));
            rock_g_left.Initilize(RockPic, new Vector2(400+FireRingB.Width/2, H-bgGroundPic.Height-RockPic.Height));
            rock_g_right.Initilize(RockPic, new Vector2(W-400-RockPic.Width- FireRingB.Width/2, H - bgGroundPic.Height - RockPic.Height));

            Coin_maps2.Initilize(CoinPic, new Vector2(W / 2 - CoinPic.Width / 2, g100_maps2.Position.Y - CoinPic.Height));
            goal1_maps2.Initilize(goal1Pic, new Vector2(0, ground.Position.Y - goal1Pic.Height));
            goal2_maps2.Initilize(goal2Pic, new Vector2(W - goal2Pic.Width , ground.Position.Y - goal2Pic.Height));

            fireLeft_maps2.Initilize(FireRingF, FireRingB, new Vector2(400, H - bgGroundPic.Height-FireRingB.Height-130));
            fireRight_maps2.Initilize(FireRingF, FireRingB, new Vector2(W - 400 - FireRingB.Width - FireRingF.Width, H - bgGroundPic.Height -FireRingB.Height-130));


            //stage 3-----------------------------------------------------------

            ground3.Initilize(bgGroundPic, new Vector2(0, H - bgGroundPic.Height));
            g100_maps3_left.Initilize(gPic100, new Vector2(0, H - bgGroundPic.Height - 220));
            g100_maps3_right.Initilize(gPic100, new Vector2(W - gPic100.Width, H - bgGroundPic.Height - 220));
            g800_maps3.Initilize(gPic800, new Vector2(W / 2 - 400, H - bgGroundPic.Height - 220));
            g100_maps3_center.Initilize(gPic100, new Vector2(W / 2 - 50, H - bgGroundPic.Height - 320));

            Coin_maps3_1.Initilize(CoinPic, new Vector2(g800_maps3.Position.X+400-CoinPic.Width/2, g800_maps3.Position.Y - CoinPic.Height));


            goal1_maps3.Initilize(goal1Pic, new Vector2(0, ground.Position.Y - goal1Pic.Height));
            goal2_maps3.Initilize(goal2Pic, new Vector2(W - goal2Pic.Width, ground.Position.Y - goal2Pic.Height));


            //bullet
            bulletP1.Initilize(bulletPic, new Vector2(playerAnimation1.Position.X,playerAnimation1.Position.Y - bulletPic.Height/2));
            bulletP2.Initilize(bulletPic, new Vector2(playerAnimation2.Position.X,playerAnimation2.Position.Y - bulletPic.Height/2));

            

            boss.Initilize(BossPic, new Vector2(W / 2-BossPic.Width/2,H - bgGroundPic.Height-350 - BossPic.Height));
            bulletsBoss.Initilize(bulletsbossPic, new Vector2(0, boss.Position.Y + 17.5f));

            //font
            font = Content.Load<SpriteFont>("font");


            effect = Content.Load<SoundEffect>("tag12");
            effect2 = Content.Load<SoundEffect>("p12");

            tu = Content.Load<Song>("lung");
            cir = Content.Load<Song>("cirss");
            mainon = Content.Load<Song>("non");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            currentKS = Keyboard.GetState();

            updatePlayer(gameTime); //player1
            updatePlayer2(gameTime); //player 2

            previousKs = currentKS;

            updateHitGround(gameTime);


            base.Update(gameTime);
        }

        private void updatePlayer(GameTime gameTime)
        {
            //player 1
            P1.update(gameTime);
            if (P1.Active == true)
            {
                if (currentKS.IsKeyDown(Keys.D))
                {
                    P1.moveRight();
                    flip = SpriteEffects.FlipHorizontally;
                }
                if (currentKS.IsKeyDown(Keys.A))
                {
                    P1.moveLeft();
                    flip = SpriteEffects.None;
                }
                if (currentKS.IsKeyDown(Keys.W) && !previousKs.IsKeyDown(Keys.W))
                {
                    jumping = true;
                    //jumpspeed = 25;
                    P1.moveUp();
                }
                if (jumping == true)
                {
                    if (jumping && jumpspeed >= 0)
                    {
                        P1.moveUp();
                        jumpspeed -= 1;

                    }
                    else if (jumpspeed < 0 && jumpspeed >= -5)
                    {
                        P1.moveDown();
                        jumpspeed--;
                    }
                    else { jumping = false; }
                }
                else if (jumping == false)
                {
                    P1.moveDown();
                }
                //bullet
                if (bulletP1.Active == false)
                {
                    bulletP1.Position.X = P1.playerAnimation.Position.X;
                    bulletP1.Position.Y = P1.playerAnimation.Position.Y;
                    if (currentKS.IsKeyDown(Keys.E) && !currentKS.IsKeyDown(Keys.Q))
                    {
                        bulletP1.Active = true;
                        bulletP1.SR = true;
                    }
                    if (currentKS.IsKeyDown(Keys.Q) && !currentKS.IsKeyDown(Keys.E))
                    {
                        bulletP1.Active = true;
                        bulletP1.SL = true;
                    }
                }
                if (bulletP1.Active == true)
                {
                    bulletP1.Box.X = (int)bulletP1.Position.X;
                    bulletP1.Box.Y = (int)bulletP1.Position.Y;
                    if (bulletP1.SR == true)
                    {
                        bulletP1.Position.X += bulletP1.speed;
                    }
                    if (true && bulletP1.SL == true)
                    {
                        bulletP1.Position.X -= bulletP1.speed;
                    }
                }
                P1.PositionAnimation.X = MathHelper.Clamp(P1.PositionAnimation.X, 50, W - P1.playerAnimation.FrameWidth + 50);
                P1.PositionAnimation.Y = MathHelper.Clamp(P1.PositionAnimation.Y, 50, H - P1.playerAnimation.FrameHeight + 50);
            }
        }

        private void updatePlayer2(GameTime gameTime)
        {
            //player 2 ------------------------------------------------------------------ player2 
            P2.update(gameTime);
            if (P2.Active == true)
            {
                if (currentKS.IsKeyDown(Keys.NumPad6))
                {
                    P2.moveRight();
                    flip2 = SpriteEffects.FlipHorizontally;

                }
                if (currentKS.IsKeyDown(Keys.NumPad4))
                {
                    P2.moveLeft();
                    flip2 = SpriteEffects.None;
                }
                if (currentKS.IsKeyDown(Keys.NumPad8) && !previousKs.IsKeyDown(Keys.NumPad8))
                {
                    jumping2 = true;
                    //jumpspeed = 25;
                    P2.moveUp();
                }
                if (jumping2 == true)
                {
                    if (jumping2 && jumpspeed2 >= 0)
                    {
                        P2.moveUp();
                        jumpspeed2 -= 1;

                    }
                    else if (jumpspeed2 < 0 && jumpspeed2 >= -5)
                    {
                        P2.moveDown();
                        jumpspeed2--;
                    }
                    else { jumping2 = false; }
                }
                else if (jumping2 == false)
                {
                    P2.moveDown();
                }
                //bullet
                if (bulletP2.Active == false)
                {
                    bulletP2.Position.X = P2.playerAnimation.Position.X;
                    bulletP2.Position.Y = P2.playerAnimation.Position.Y;
                    if (currentKS.IsKeyDown(Keys.NumPad9) && !currentKS.IsKeyDown(Keys.NumPad7))
                    {
                        bulletP2.Active = true;
                        bulletP2.SR = true;
                    }
                    if (currentKS.IsKeyDown(Keys.NumPad7) && !currentKS.IsKeyDown(Keys.NumPad9))
                    {
                        bulletP2.Active = true;
                        bulletP2.SL = true;
                    }
                }
                if (bulletP2.Active == true)
                {
                    bulletP2.Box.X = (int)bulletP2.Position.X;
                    bulletP2.Box.Y = (int)bulletP2.Position.Y;
                    if (bulletP2.SR == true)
                    {
                        bulletP2.Position.X += bulletP2.speed;
                    }
                    if (bulletP2.SL == true)
                    {
                        bulletP2.Position.X -= bulletP2.speed;
                    }
                }
                P2.PositionAnimation.X = MathHelper.Clamp(P2.PositionAnimation.X, 50, W - P2.playerAnimation.FrameWidth + 50);
                P2.PositionAnimation.Y = MathHelper.Clamp(P2.PositionAnimation.Y, 50, H - P2.playerAnimation.FrameHeight + 50);
            }
        }

        private void updateHitGround(GameTime gameTime)
        {
            
            //check player stand at top ground
            if (Coin_maps1.maps == stage.stage1)
            {
                if (play1 == 1)
                {
                    MediaPlayer.Play(cir);
                    //circus.Play();

                }
                play1++;

                
                for (int i = 0; i < groundList1.Count; i++)
                {
                    //player 1
                    if (groundList1[i].CheckCollision(P1.rect) == GroundHit.HitTop)
                    {
                        P1.HitTop(groundList1[i].Box);
                        jumpspeed = 25;
                    }
                    if (groundList1[i].CheckCollision(P1.rect) == GroundHit.HitBtm)
                    {
                        P1.HitDown(groundList1[i].Box);
                        jumpspeed = -5;
                    }
                    if (groundList1[i].CheckCollision(P1.rect) == GroundHit.HitRight)
                    {
                        P1.HitRight(groundList1[i].Box);
                    }

                    if (groundList1[i].CheckCollision(P1.rect) == GroundHit.HitLeft)
                    {
                        P1.HitLeft(groundList1[i].Box);
                    }

                    //player 2
                    if (groundList1[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList1[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList1[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList1[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList1[i].CheckCollision(P2.rect) == GroundHit.HitBtm)
                    {
                        P2.HitDown(groundList1[i].Box);
                        jumpspeed2 = -5;
                    }

                    if (groundList1[i].CheckCollision(P2.rect) == GroundHit.HitRight)
                    {
                        P2.HitRight(groundList1[i].Box);
                    }

                    if (groundList1[i].CheckCollision(P2.rect) == GroundHit.HitLeft)
                    {
                        P2.HitLeft(groundList1[i].Box);
                    }
                }

                // firering
                for (int i = 0; i < FireList1.Count; i++)
                {
                    if (FireList1[i].Chekcolision(P1.rect) != FireHit.None)
                    {
                       
                        P1.Active = false;
                    }
                    if (FireList1[i].Chekcolision(P2.rect) != FireHit.None)
                    {
                     
                        P2.Active = false;
                    }
                }

                //coin
                if (Coin_maps1.playerGet == player.None && (Coin_maps1.Checkcolision(P1.rect) == GoldHit.Hit))
                {
                    Coin_maps1.Active = false;
                    Coin_maps1.playerGet = player.P1;
                }

                if (Coin_maps1.playerGet == player.None && (Coin_maps1.Checkcolision(P2.rect) == GoldHit.Hit))
                {
                    Coin_maps1.Active = false;
                    Coin_maps1.playerGet = player.P2;
                }


                //coin check player win
                if (Coin_maps1.playerGet == player.P1 && goal1_maps1.Checkcolision(P1.rect) == GoldHit.Hit)
                {
                    P1.score++;
                    Coin_maps1.maps = stage.stage2;
                    Coin_maps1.playerGet = player.None;
                    MediaPlayer.Stop();
                    P1.Active = false;
                    P2.Active = false;
                    play1 = 0;
                }
                if (Coin_maps1.playerGet == player.P2 && goal2_maps1.Checkcolision(P2.rect) == GoldHit.Hit)
                {
                    P2.score++;
                    Coin_maps1.maps = stage.stage2;                    
                    Coin_maps1.playerGet = player.None;
                    MediaPlayer.Stop();
                    P1.Active = false;
                    P2.Active = false;
                    play1 = 0;
                }

                if (P1.Active == false && Coin_maps1.Active == false && Coin_maps1.playerGet == player.P1)
                {
                    Coin_maps1.Active = true;
                    Coin_maps1.playerGet = player.None;
                }
                if (P2.Active == false && Coin_maps1.Active == false && Coin_maps1.playerGet == player.P2)
                {
                    Coin_maps1.Active = true;
                    Coin_maps1.playerGet = player.None;                    
                }

            }

            if (Coin_maps1.maps == stage.stage2)
            {

                if (play1 == 1)
                {
                    MediaPlayer.Play(cir);
                    //circus.Play();

                }
                play1++;
                for (int i = 0; i < groundList2.Count; i++)
                {
                    //player 1
                    if (groundList2[i].CheckCollision(P1.rect) == GroundHit.HitTop)
                    {
                        P1.HitTop(groundList2[i].Box);
                        jumpspeed = 25;
                    }
                    if (groundList2[i].CheckCollision(P1.rect) == GroundHit.HitBtm)
                    {
                        P1.HitDown(groundList2[i].Box);
                        jumpspeed = -5;
                    }
                    if (groundList2[i].CheckCollision(P1.rect) == GroundHit.HitRight)
                    {
                        P1.HitRight(groundList2[i].Box);
                    }

                    if (groundList2[i].CheckCollision(P1.rect) == GroundHit.HitLeft)
                    {
                        P1.HitLeft(groundList2[i].Box);
                    }

                    //player 2
                    if (groundList2[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList2[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList2[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList2[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList2[i].CheckCollision(P2.rect) == GroundHit.HitBtm)
                    {
                        P2.HitDown(groundList2[i].Box);
                        jumpspeed2 = -5;
                    }

                    if (groundList2[i].CheckCollision(P2.rect) == GroundHit.HitRight)
                    {
                        P2.HitRight(groundList2[i].Box);
                    }

                    if (groundList2[i].CheckCollision(P2.rect) == GroundHit.HitLeft)
                    {
                        P2.HitLeft(groundList2[i].Box);
                    }
                }
                for (int i = 0; i < rockList2.Count; i++)
                {
                    if (rockList2[i].Box.Intersects(P1.rect))
                    {
                        P1.Active = false;
                        
                    }

                    if (rockList2[i].Box.Intersects(P2.rect))
                    {
                        P2.Active = false;
                        
                    }

                }

                // firering
                for (int i = 0; i < FireList2.Count; i++)
                {
                    if (FireList2[i].Chekcolision(P1.rect) != FireHit.None)
                    {
                       
                        P1.Active = false;
                    }
                    if (FireList2[i].Chekcolision(P2.rect) != FireHit.None)
                    {
                        
                        P2.Active = false;
                    }
                }

                //coin
                if (Coin_maps2.playerGet == player.None && (Coin_maps2.Checkcolision(P1.rect) == GoldHit.Hit))
                {
                    Coin_maps2.Active = false;
                    Coin_maps2.playerGet = player.P1;
                }

                if (Coin_maps2.playerGet == player.None && (Coin_maps2.Checkcolision(P2.rect) == GoldHit.Hit))
                {
                    Coin_maps2.Active = false;
                    Coin_maps2.playerGet = player.P2;
                }
                //coin check player win
                if (Coin_maps2.playerGet == player.P1 && goal1_maps2.Checkcolision(P1.rect) == GoldHit.Hit)
                {
                    P1.score++;
                    Coin_maps1.maps = stage.stage3;
                    P1.Active = false;
                    P2.Active = false;
                    MediaPlayer.Stop();
                    play1 = 0;
                }
                if (Coin_maps2.playerGet == player.P2 && goal2_maps2.Checkcolision(P2.rect) == GoldHit.Hit)
                {
                    P2.score++;
                    Coin_maps1.maps = stage.stage3;
                    P1.Active = false;
                    P2.Active = false;
                    MediaPlayer.Stop();
                    play1 = 0;
                }

                if (P1.Active == false && Coin_maps2.Active == false && Coin_maps2.playerGet == player.P1)
                {
                    Coin_maps2.Active = true;
                    Coin_maps2.playerGet = player.None;
                }
                if (P2.Active == false && Coin_maps2.Active == false && Coin_maps2.playerGet == player.P2)
                {
                    Coin_maps2.Active = true;
                    Coin_maps2.playerGet = player.None;
                }

            }
            
            if(Coin_maps1.maps == stage.stage3)
            {
                if(play1 == 1)
                {
                    MediaPlayer.Play(tu);
                }
                play1++;
                for (int i =0; i < groundList3.Count; i++)
                {
                    //player 1
                    if (groundList3[i].CheckCollision(P1.rect) == GroundHit.HitTop)
                    {
                        P1.HitTop(groundList3[i].Box);
                        jumpspeed = 25;
                    }
                    if (groundList3[i].CheckCollision(P1.rect) == GroundHit.HitBtm)
                    {
                        P1.HitDown(groundList3[i].Box);
                        jumpspeed = -5;
                    }
                    if (groundList3[i].CheckCollision(P1.rect) == GroundHit.HitRight)
                    {
                        P1.HitRight(groundList3[i].Box);
                    }

                    if (groundList3[i].CheckCollision(P1.rect) == GroundHit.HitLeft)
                    {
                        P1.HitLeft(groundList3[i].Box);
                    }

                    //player 2
                    if (groundList3[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList3[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList3[i].CheckCollision(P2.rect) == GroundHit.HitTop)
                    {
                        P2.HitTop(groundList3[i].Box);
                        jumpspeed2 = 25;
                    }

                    if (groundList3[i].CheckCollision(P2.rect) == GroundHit.HitBtm)
                    {
                        P2.HitDown(groundList3[i].Box);
                        jumpspeed2 = -5;
                    }

                    if (groundList3[i].CheckCollision(P2.rect) == GroundHit.HitRight)
                    {
                        P2.HitRight(groundList3[i].Box);
                    }

                    if (groundList3[i].CheckCollision(P2.rect) == GroundHit.HitLeft)
                    {
                        P2.HitLeft(groundList3[i].Box);
                    }
                }
                //boss
                if (timer % 200 == 50 && boss.Active == true)
                {
                    bulletsBoss.Active = true;
                    if (bulletsBoss.CheckCollision(P1.rect) == BulletHit.Hit)
                    { P1.Active = false; }
                    if (bulletsBoss.CheckCollision(P2.rect) == BulletHit.Hit)
                    { P2.Active = false; }
                }
                if (timer % 100 == 0)
                { bulletsBoss.Active = false; }
                if (HP <= 0)
                { boss.Active = false; }
                timer++;

                if (bulletP1.Box.Intersects(boss.Box))
                {
                    HP -= 10;
                    bulletP1.Active = false;
                }
                if (bulletP2.Box.Intersects(boss.Box))
                {
                    HP -= 10;
                    bulletP2.Active = false;
                }

                //check coin
                
                if (boss.Active == false)
                {
                    groundList3.Remove(g100_maps3_center);

                }

                //coin
                if (Coin_maps3_1.playerGet == player.None && (Coin_maps3_1.Checkcolision(P1.rect) == GoldHit.Hit))
                {
                    Coin_maps3_1.Active = false;
                    Coin_maps3_1.playerGet = player.P1;
                }

                if (Coin_maps3_1.playerGet == player.None && (Coin_maps3_1.Checkcolision(P2.rect) == GoldHit.Hit))
                {
                    Coin_maps3_1.Active = false;
                    Coin_maps3_1.playerGet = player.P2;
                }
                //coin check player win
                if (Coin_maps3_1.playerGet == player.P1 && goal1_maps3.Checkcolision(P1.rect) == GoldHit.Hit)
                {
                    P1.score+=3;
                    Coin_maps1.maps = stage.stage4;
                    MediaPlayer.Stop();
                    play1 = 0;
                  

                }
                if (Coin_maps3_1.playerGet == player.P2 && goal2_maps3.Checkcolision(P2.rect) == GoldHit.Hit)
                {
                    P2.score+=3;
                    Coin_maps1.maps = stage.stage4;
                    MediaPlayer.Stop();
                    play1 = 0;
                }

                if (P1.Active == false && Coin_maps3_1.Active == false && Coin_maps3_1.playerGet == player.P1)
                {
                    Coin_maps3_1.Active = true;
                    Coin_maps3_1.playerGet = player.None;
                }
                if (P2.Active == false && Coin_maps3_1.Active == false && Coin_maps3_1.playerGet == player.P2)
                {
                    Coin_maps3_1.Active = true;
                    Coin_maps3_1.playerGet = player.None;
                }


            }
            if(Coin_maps1.maps == stage.stage4)
            {
                if(play1 == 1)
                {
                    MediaPlayer.Play(mainon);
                }
                play1++;
            }

            //bullet
            if (bulletP1.Box.Intersects(P2.rect) && P1.Active == true)
            {
                effect2.Play();
                bulletP1.Active = false;
                P2.Active = false;
                
            }
            if (bulletP2.Box.Intersects(P1.rect) && P2.Active == true)
            {
                effect2.Play();
                bulletP2.Active = false;
                P1.Active = false;
                
            }
            if (bulletP1.Position.X >= W || bulletP1.Position.X <= 0)
            {

                effect.Play();
                bulletP1.Active = false;
            }
            if (bulletP2.Position.X >= W || bulletP2.Position.X <= 0)
            {
                effect.Play();
                bulletP2.Active = false;
            }

            

            if (bulletP1.Active == false)
            { bulletP1.Box.X = -100; bulletP1.Box.Y = -100; bulletP1.SR = false; bulletP1.SL = false; }
            if (bulletP2.Active == false)
            { bulletP2.Box.X = -100; bulletP2.Box.Y = -100; bulletP2.SR = false; bulletP2.SL = false; }
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if(Coin_maps1.maps == stage.stage1)
            {
                spriteBatch.Draw(bgSkyPic, Vector2.Zero, Color.White);
                for(int i = 0; i < groundList1.Count; i++)
                {
                    groundList1[i].Draw(spriteBatch);
                }

                if (Coin_maps1.Active == true)
                { Coin_maps1.Draw(spriteBatch); }
                goal1_maps1.Draw(spriteBatch);
                goal2_maps1.Draw(spriteBatch);

                for(int i = 0; i < FireList1.Count; i++)
                {
                    FireList1[i].DrawBack(spriteBatch);
                }
                //player 1---------------------------------------------------------------- player 1
                if (P1.Active == true)
                { P1.DrawAnimation(spriteBatch, flip); }
                if (P1.Active == false)
                {
                    P1.PositionAnimation = ground.Position;
                }

                //player 2 -------------------------------------------------------------- player 2
                if (P2.Active == true)
                { P2.DrawAnimation(spriteBatch, flip2); }
                if (P2.Active == false)
                {
                    P2.PositionAnimation = ground.Position;
                }
                for(int i = 0; i < FireList1.Count; i++)
                {
                    FireList1[i].DrawFont(spriteBatch);
                }

                if ((P1.Active == false))
                {                    
                    P1.PositionAnimation = new Vector2(100, H - bgGroundPic.Height - 50);
                    P1.Active = true;                   
                }
                
                if ((P2.Active == false))
                {                    
                    P2.Active = true;
                    P2.PositionAnimation = new Vector2(W - 100, H - bgGroundPic.Height-50);
                }
            }

            //stage2----------------------------------------------------------------------------------------------------------------------------------------
            if (Coin_maps1.maps == stage.stage2)
            {
                spriteBatch.Draw(bgSkyPic2, Vector2.Zero, Color.White);
                for (int i = 0; i < groundList2.Count; i++)
                {
                    groundList2[i].Draw(spriteBatch);
                }

                for (int i = 0; i < rockList2.Count; i++)
                { rockList2[i].Draw(spriteBatch); }

                if (Coin_maps2.Active == true)
                { Coin_maps2.Draw(spriteBatch); }
                goal1_maps2.Draw(spriteBatch);
                goal2_maps2.Draw(spriteBatch);

                for (int i = 0; i < FireList2.Count; i++)
                {
                    FireList2[i].DrawBack(spriteBatch);
                }
                //player 1---------------------------------------------------------------- player 1
                if (P1.Active == true)
                { P1.DrawAnimation(spriteBatch, flip); }
                if (P1.Active == false)
                {
                    P1.PositionAnimation = ground.Position;
                }

                //player 2 -------------------------------------------------------------- player 2
                if (P2.Active == true)
                { P2.DrawAnimation(spriteBatch, flip2); }

                if (P2.Active == false)
                {
                    P2.PositionAnimation = ground.Position;
                }

                for (int i = 0; i < FireList2.Count; i++)
                {
                    FireList2[i].DrawFont(spriteBatch);
                }

                if ((P1.Active == false))
                {
                    
                    P1.Active = true;
                    P1.PositionAnimation = new Vector2(W - 100, 300);
                   
                }
                if ((P2.Active == false))
                {
                    P2.Active = true;
                    P2.PositionAnimation = new Vector2(100, 300);

                }
            }
            //stage3---------------------------------------------------------------------------------
            if (Coin_maps1.maps == stage.stage3)
            {
                spriteBatch.Draw(bgSkyPic3, Vector2.Zero, Color.White);

                if (Coin_maps3_1.Active == true)
                {
                    Coin_maps3_1.Draw(spriteBatch);
                }
                
                goal1_maps3.Draw(spriteBatch);
                goal2_maps3.Draw(spriteBatch);

                //player 1---------------------------------------------------------------- player 1
                if (P1.Active == true)
                { P1.DrawAnimation(spriteBatch, flip); }
                if (P1.Active == false)
                {
                    P1.PositionAnimation = ground.Position;
                }

                //player 2 -------------------------------------------------------------- player 2
                if (P2.Active == true)
                { P2.DrawAnimation(spriteBatch, flip2); }

                if (P2.Active == false)
                {
                    P2.PositionAnimation = ground.Position;
                }

                for (int i =0; i < groundList3.Count; i++)
                {
                    groundList3[i].Draw(spriteBatch);
                }

                //Check boss is Active
                if (bulletsBoss.Active == true)
                { bulletsBoss.Draw(spriteBatch); }
                if (boss.Active == true)
                { boss.Draw(spriteBatch);}

                //Check player is Active
                if ((P1.Active == false))
                {
                    P1.Active = true;
                    P1.PositionAnimation = new Vector2(100, H - bgGroundPic.Height - 50);

                }
                if ((P2.Active == false))
                {
                    P2.Active = true;
                    P2.PositionAnimation = new Vector2(W - 100, H - bgGroundPic.Height - 50);

                }

            }

            if(Coin_maps1.maps == stage.stage4)
            {
                if (P1.score > P2.score)
                {
                    spriteBatch.Draw(RedWin, new Vector2(W / 2 - 100, H / 2 - 50), Color.White);
                    spriteBatch.DrawString(font, "is Winer", new Vector2(W / 2 , H / 2), Color.Black);
                }
                if (P2.score > P1.score)
                {
                    spriteBatch.Draw(BlueWin, new Vector2(W / 2 - 100, H / 2 - 50), Color.White);
                    spriteBatch.DrawString(font, "is Winer", new Vector2(W / 2 , H / 2), Color.Black);
                }
            }
            

            if (bulletP1.Active == true && P1.Active == true)
            {
                bulletP1.Draw(spriteBatch);
            }

            if (bulletP2.Active == true && P2.Active == true)
            {
                bulletP2.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}