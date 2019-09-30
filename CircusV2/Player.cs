using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CircusV2
{
    
    class Player
    {
        
        //animationnnnnnnn
        public bool Active;
        public int score = 0;
        public Vector2 PositionAnimation;
        public Animation playerAnimation;
        public Rectangle rect;
        public Rectangle Box
        {
            get { return rect; }
        }

        public int WidthAnimation
        {
            get { return playerAnimation.FrameWidth; }
        }
        public int HightAnimation
        {
            get { return playerAnimation.FrameHeight; }
        }
        public void InitializeAnimation(Animation animation, Vector2 position)
        {
            playerAnimation = animation;
            PositionAnimation = position;
            rect = new Rectangle((int)PositionAnimation.X-50, (int)PositionAnimation.Y-50, 100, 100);
            Active = true;

        }
        public void update(GameTime gameTime)
        {
            playerAnimation.Position = PositionAnimation;
            playerAnimation.Update(gameTime);
        }


        //hit flow
        public void HitTop(Rectangle Obj)
        {            
            PositionAnimation.Y = Obj.Y-50;            
        }
        public void HitRight(Rectangle Obj)
        {
            PositionAnimation.X = Obj.X + Obj.Width+50;
            //Initilize(_pic, _pos, _speed, _W, _H);
        }
        public void HitLeft(Rectangle Obj)
        {
            PositionAnimation.X = Obj.X - 50;
            //Initilize(_pic, _pos, _speed, _W, _H);
        }
        public void HitDown(Rectangle Obj)
        {
            PositionAnimation.Y = Obj.Y + Obj.Height+50;
        }

        //control
        public void moveUp()
        {
            PositionAnimation.Y -= 10;
            InitializeAnimation(playerAnimation, PositionAnimation);
        }
        public void moveDown()
        {
            PositionAnimation.Y += 10;
            InitializeAnimation(playerAnimation, PositionAnimation);
        }
        public void moveLeft()
        {
            PositionAnimation.X -= 5;
            InitializeAnimation(playerAnimation, PositionAnimation);
        }
        public void moveRight()
        {
            PositionAnimation.X += 5;
            InitializeAnimation(playerAnimation, PositionAnimation);
        }

        //draw player
        public void DrawAnimation(SpriteBatch sb,SpriteEffects flip)
        {
            playerAnimation.Draw(sb,flip);
        }
    }
}

    

