using MyGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        private Transform transform;
        private IntPtr image;
        private int width = 121;
        private int height = 114;
        private int startposition;
        private float speed;
        private int limit;
        private bool isActive;

        public Transform Transform => transform;
        public int Width => width;
        public int Height => height;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Enemy (int y, string image, float speed)
        {
            this.image = Engine.LoadImage(image);
            this.speed = speed;
           
            IsActive = true;
            if (speed>0)
            {
                transform = new Transform(new Vector2(0 - width, y - height));
                limit = 1024;
                startposition = 0- width;
            }
            else
            {
                transform = new Transform(new Vector2(1024 + width, y - height));
                limit = 0;
                startposition = 1024 + width;
            }
            
        }

        public void Update ()
        {
            CheckLimits();
            if (IsActive)
            {
                Transform.Traslate(new Vector2(1, 0), speed);
            }
            
        }

        public void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }

        private void CheckLimits()
        {
            if (speed > 0)
            {
                if (transform.Position.x >= limit)
                {
                    isActive = false;
                }
            }
            if (speed< 0)
            {
                if (transform.Position.x <= limit)
                {
                    isActive = false;
                }
            }
        }
        public void ResetEnemy(int estante)
        {
            isActive = true;
            
            if (estante == 1 || estante == 3)
            {
                speed = -150;
                limit = 0;
                startposition = 1024 + width;
                image = Engine.LoadImage("assets/Objetivos/Pato volteado.png");
                if(estante == 1) { transform.Position = new Vector2(1024+width, 223 - height); }
                else { transform.Position = new Vector2(1024 + width, 503 - height); }
            }
            if (estante == 2 || estante == 4)
            {
                speed = 150;
                limit = 1024;
                startposition = 0 - width;
                image = Engine.LoadImage("assets/Objetivos/Pato.png");
                if (estante == 2) { transform.Position = new Vector2(0 - width, 363 - height); }
                else { transform.Position = new Vector2(0 - width, 650 - height); }
            }
        }
    }
}
