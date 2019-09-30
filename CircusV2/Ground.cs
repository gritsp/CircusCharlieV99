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

    enum GroundHit
    { None, HitTop, HitBtm, HitLeft, HitRight };
    class Ground
    {
        private Texture2D _pic;
        private Vector2 _pos;        
        private Rectangle _rect; //size
      

        private Rectangle _rectTop, _rectBtm, _rectLeft, _rectRight;
        public Texture2D Picture
        {
            get { return _pic; }
        }
        public Vector2 Position
        {
            get { return _pos; }            
        }        

        public Rectangle Box
        {
            get { return _rect; }
        }

        public int Width
        {
            get { return _rect.Width; }
        }
        public int Height
        {
            get { return _rect.Height; }
        }
        public void Initilize(Texture2D Pic, Vector2 Pos)
        {
            _pic = Pic;
            _pos = Pos;
           

            _rect = new Rectangle((int)Pos.X, (int)Pos.Y, Pic.Width, Pic.Height);

            _rectTop = new Rectangle((int)Pos.X+10, (int)Pos.Y, Pic.Width-20, Pic.Height / 2);
            _rectBtm = new Rectangle((int)Pos.X+10, (int)Pos.Y + Pic.Height / 2, Pic.Width-20, Pic.Height / 2);
            _rectLeft = new Rectangle((int)Pos.X, (int)Pos.Y ,10, Pic.Height);
            _rectRight = new Rectangle((int)Pos.X + Pic.Width-10, (int)Pos.Y ,10, Pic.Height);
        }
        public GroundHit CheckCollision(Rectangle Obj)
        {
            if (Obj.Intersects(_rectTop)) { return GroundHit.HitTop; }
            if (Obj.Intersects(_rectBtm)) { return GroundHit.HitBtm; }
            if (Obj.Intersects(_rectLeft)) { return GroundHit.HitLeft; }
            if (Obj.Intersects(_rectRight)) { return GroundHit.HitRight; }
            return GroundHit.None;
        }
        public void Draw(SpriteBatch sb) //เขียนหน้าจอ
        {
            sb.Draw(_pic, _pos, Color.White);
        }
    }
}
