using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.Graphics;
using System;
using System.Windows.Input;

namespace Eplanwiki.EplAddin.Pong
{
    public class Racket
    {
        private Rectangle rec;
        bool moveRight = true;
        public PointD newPosition;
        public Double width { get; private set;}

        public Racket(Page page)
        {
            rec = new Rectangle();
            rec.Create(page);
            rec.Pen = new Pen((short)Game.GetRandomNumber(1, 255), -16002, -16002, -16002, 0);
            newPosition = new PointD(50.0, 50.0);
            rec.SetArea(newPosition , new PointD(100.0, 45.0));
            rec.IsSurfaceFilled = true;
            this.width = rec.Width;
        }
        
        public void Move()
        {
            if (moveRight)
            {
                newPosition.X += 4.0;
                rec.Location = newPosition;
                if (rec.Location.X >= rec.Page.Size.X || Keyboard.IsKeyDown(Key.Left))
                {
                    moveRight = false;
                }
            }
            else
            {
                newPosition.X -= 4.0;
                rec.Location = newPosition;
                if (rec.Location.X <= 0.0 || Keyboard.IsKeyDown(Key.Right))
                {
                    moveRight = true;
                }
            }
            
        }
    }
}
