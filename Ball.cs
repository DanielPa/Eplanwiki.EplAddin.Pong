using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.Graphics;
using System;
using System.Media;


namespace Eplanwiki.EplAddin.Pong
{
    public class Ball
    {
        private Arc circle;
        bool moveRight = false;
        bool moveDown = true;
        public PointD newPosition;

        public Ball(Page page)
        {            
            circle = new Arc();
            circle.Create(page);
            circle.Pen = new Pen((short)Game.GetRandomNumber(1, 255), -16002, -16002, -16002, 0);
            newPosition = new PointD(Game.GetRandomNumber(0.0, circle.Page.Size.X), Game.GetRandomNumber(0.0, circle.Page.Size.Y));
            circle.SetCircle(circle.Location, 5.0);
            circle.IsSurfaceFilled = true;
            
        }

        public void Move(bool collision)
        {            
            if (moveDown)
            {
                newPosition.Y -= 2.0;
                circle.Location = newPosition;    
                if (circle.Location.Y <= 0.0 || collision)
                {
                    moveDown = false;                    
                }
                
            }
            else
            {
                newPosition.Y += 2.0;
                circle.Location = newPosition;
                if (circle.Location.Y >= circle.Page.Size.Y)
                {
                    moveDown = true;                    
                }
            }
            if (moveRight)
            {
                newPosition.X += 2.0;
                circle.Location = newPosition;
                if (circle.Location.X >= circle.Page.Size.X)
                {
                    moveRight = false;                    
                }
                
            }
            else
            {
                newPosition.X -= 2.0;
                circle.Location = newPosition;
                if (circle.Location.X <= 0.0)
                {
                    moveRight= true;                    
                }
            }                                    
        }
        
    }
}
