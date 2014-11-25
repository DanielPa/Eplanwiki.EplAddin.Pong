using Eplan.EplApi.DataModel;
using Eplan.EplApi.EServices.Ged;
using System;
using System.Windows.Threading;
using System.Windows.Input;
using Eplan.EplApi.DataModel.Graphics;

namespace Eplanwiki.EplAddin.Pong
{
    [InteractionAttribute(Name = "XGedStartPong", Ordinal = 50, Prio = 20)]
    public class Game : InsertInteraction
    {
        private Ball ball;
        public Racket racket;
        private bool moveball;
        private Page currentPage;
        private bool moveRacketRight;
        DispatcherTimer timer;
      
      
        public void Start()
        {
            moveball = true;
            moveRacketRight = true;
            Page currentPage = this.Page;      
            ball = new Ball(currentPage);
            racket = new Racket(currentPage);                        
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += timerTick;                 
        }

        public void End()
        {            
            timer.Stop();            
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                End();
            }
            racket.Move();
            ball.Move(checkCollision());            
        }

        public override RequestCode OnPoint(Position oPosition)
        {
            //racket.Move(oPosition.CursorPosition.X);
            return base.OnPoint(oPosition);
        }

        public override void OnCursorMove(Position oPosition)
        {
            base.OnCursorMove(oPosition);
            //racket.Move(oPosition.CursorPosition.X);
        }

        public override RequestCode OnStart(InteractionContext oContext)
        {
            this.Start();
            return base.OnStart(oContext);
        }

        private bool checkCollision()
        {
            if (ball.newPosition.X >= racket.newPosition.X && ball.newPosition.X <= racket.newPosition.X+racket.width)
	        {
                if (ball.newPosition.Y - racket.newPosition.Y <= 5.0 )
                {
                    return true;
                }
	        }            
            return false;
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static double GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next(minimum, maximum);
        }
    }
}
