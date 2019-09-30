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
    enum FireHit { None,HitTop,HitBtm };
    class Fire
    {
        public Texture2D PictureFlont;
        public Texture2D PictureBack;
        public Vector2 PositionFlont;
        public Vector2 PositionBack;
        public Rectangle rectTop, rectBtm;

        public void Initilize(Texture2D picFont,Texture2D picBack,Vector2 posBack)
        {
            PictureFlont = picFont;
            PictureBack = picBack;

            PositionBack = posBack;

            PositionFlont.X = posBack.X + picBack.Width; //เท่ากับต่ำแหน่งที่ต่อจากรูปหลัง
            PositionFlont.Y = posBack.Y;

            rectTop = new Rectangle((int)PositionFlont.X, (int)PositionFlont.Y,10, 10);
            rectBtm = new Rectangle((int)PositionFlont.X, (int)PositionFlont.Y+PictureFlont.Height-10,4, 10);

        }

        public FireHit Chekcolision (Rectangle Obj)
        {
            if(rectTop.Intersects(Obj)) { return FireHit.HitTop; }
            if(rectBtm.Intersects(Obj)) { return FireHit.HitBtm; }
            return FireHit.None;
        }

        public void DrawFont(SpriteBatch sb) //รูปหน้า
        {
            sb.Draw(PictureFlont, PositionFlont,Color.White);
        }

        public void DrawBack(SpriteBatch sb) //รูปหลัง
        {
            sb.Draw(PictureBack, PositionBack, Color.White);
        }

    }
}
