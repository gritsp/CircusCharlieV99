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
    enum GoldHit { None,Hit };
    enum player { None,P1,P2  };
    enum stage { stage1, stage2, stage3 ,stage4 };
    class Gold
    {
        public stage maps = stage.stage1;

        public Texture2D Picture;
        public Vector2 Position;
        public Rectangle Box;
        public bool Active = true;
        public player playerGet = player.None;

        public void Initilize(Texture2D pic, Vector2 pos)
        {
            Picture = pic;
            Position = pos;

            Box = new Rectangle((int)Position.X, (int)Position.Y, Picture.Width, Picture.Height);
        }

        public GoldHit Checkcolision (Rectangle Obj)
        {
            if (Box.Intersects(Obj)) { return GoldHit.Hit; }
            return GoldHit.None;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Picture, Position, Color.White);
        }

    }
}
