using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CircusV2
{
    class Animation
    {
        Texture2D spriteStrip;

        SpriteEffects flip;

        float scale;

        int elapsedTime;

        int frameTime;

        int frameCount;

        int currentFrame;

        Color color;

        Rectangle sourceRect = new Rectangle();

        Rectangle destinationRect = new Rectangle();

        public int FrameWidth;
        public int FrameHeight;

        public bool Active;
        public bool Looping;

        public Vector2 Position;

        public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frameTime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.scale = scale;

            

            Looping = looping;
            Position = position;
            spriteStrip = texture;

            elapsedTime = 0;
            currentFrame = 0;

            Active = true;


        }

        public void Update(GameTime gameTime)
        {
            if (Active == false)
            { return; }

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime)
            {
                currentFrame++;

                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (Looping == false)
                    { Active = false; }
                }
                elapsedTime = 0;
            }

            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2, (int)Position.Y - (int)(FrameHeight * scale) / 2
                              , (int)(FrameWidth * scale), (int)(FrameHeight * scale));
        }

        public void Draw(SpriteBatch sb,SpriteEffects flip)
        {
            if (Active)
            {
                sb.Draw(spriteStrip, destinationRect, sourceRect, color,0f, new Vector2(0,0),flip,0f);
            }
        }
    }
}
