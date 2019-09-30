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
    class Boss
    {

        public Texture2D Picture;
        public Vector2 Position;
        public Rectangle Box;
        public bool Active = true;
        public int HP = 100;

        public void Initilize(Texture2D pic, Vector2 pos)
        {
            Picture = pic;
            Position = pos;

            Box = new Rectangle((int)Position.X, (int)Position.Y, Picture.Width, Picture.Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Picture, Position, Color.White);
        }
    }
}
