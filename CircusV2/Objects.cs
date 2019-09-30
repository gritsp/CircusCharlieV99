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
    enum ObjHit
    { None, HitTop, HitBtm, HitLeft, HitRight };
    class Objects
    {
        public Texture2D Picture;
        public Vector2 Position;
        public Rectangle Box,rectTop,rectBtm,rectLeft,rectRight;
        

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

            rectTop = new Rectangle((int)Pos.X + 10, (int)Pos.Y, Pic.Width - 20, Pic.Height / 2);
            rectBtm = new Rectangle((int)Pos.X + 10, (int)Pos.Y + Pic.Height / 2, Pic.Width - 20, Pic.Height / 2);
            rectLeft = new Rectangle((int)Pos.X, (int)Pos.Y, 10, Pic.Height);
            rectRight = new Rectangle((int)Pos.X + Pic.Width - 10, (int)Pos.Y, 10, Pic.Height);
        }
        public ObjHit CheckCollision(Rectangle Obj)
        {
            if (Obj.Intersects(rectTop)) { return ObjHit.HitTop; }
            if (Obj.Intersects(rectBtm)) { return ObjHit.HitBtm; }
            if (Obj.Intersects(rectLeft)) { return ObjHit.HitLeft; }
            if (Obj.Intersects(rectRight)) { return ObjHit.HitRight; }
            return ObjHit.None;
        }
        public void Draw(SpriteBatch sb) //เขียนหน้าจอ
        {
            sb.Draw(Picture, Position, Color.White);
        }
    }
}
