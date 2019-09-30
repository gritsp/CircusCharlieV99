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
    enum BulletHit { None, Hit };
    class Bullets
    {
        public Texture2D Picture;
        public Vector2 Position;
        public Rectangle Box;
        public bool Active = false;
        public int speed = 10;
        public bool SR = false;
        public bool SL = false;
        public int Width
        {
            get { return Box.Width; }
        }
        public int Height
        {
            get { return Box.Height; }
        }

        public void Initilize(Texture2D Pic, Vector2 Pos)
        {
            Picture = Pic;
            Position = Pos;

            Box = new Rectangle((int)Pos.X, (int)Pos.Y, Pic.Width, Pic.Height);
        }
       
        public BulletHit CheckCollision(Rectangle Obj)
        {
            if (Box.Intersects(Obj)) { return BulletHit.Hit; }
            return BulletHit.None;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Picture, Position, Color.White);

        }
    }
}
