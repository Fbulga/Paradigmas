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
        private float speed;
        private int limit;
        private bool isActive;
        private bool isShooted = false;
        private Animation deathAnimation;

        public Transform Transform => transform;
        public int Width => width;
        public int Height => height;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public bool IsShooted
        {
            get => isShooted;
            set { isShooted = value; }
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
            }
            else
            {
                transform = new Transform(new Vector2(1024 + width, y - height));
                limit = 0;
            }
            CreateAnimations();
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
            if (isActive)
            {
                Engine.Draw(image, transform.Position.x, transform.Position.y);
            }
            if (isShooted)
            {
                deathAnimation.Update();
                Engine.Draw(deathAnimation.CurrentFrame, transform.Position.x, transform.Position.y);
                if (deathAnimation.CurrentFrameIndex == 3)
                {
                    isShooted = false;
                    deathAnimation.CurrentFrameIndex = 0;
                }
                
            }
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
            isShooted = false;
            if (estante == 1 || estante == 3)
            {
                speed = -150;
                limit = 0;
                image = Engine.LoadImage("assets/Objetivos/Pato volteado.png");
                if(estante == 1) { transform.Position = new Vector2(1024+width, 223 - height); }
                else { transform.Position = new Vector2(1024 + width, 503 - height); }
            }
            if (estante == 2 || estante == 4)
            {
                speed = 150;
                limit = 1024;
                image = Engine.LoadImage("assets/Objetivos/Pato.png");
                if (estante == 2) { transform.Position = new Vector2(0 - width, 363 - height); }
                else { transform.Position = new Vector2(0 - width, 650 - height); }
            }
            CreateAnimations();
        }
        private void CreateAnimations()
        {
            List<IntPtr> deathTextures = new List<IntPtr>();
            for (int i = 0; i < 4; i++)
            {
                if (Transform.Position.y == 223 - height || Transform.Position.y == 503 - height)
                {
                    IntPtr frame = Engine.LoadImage($"assets/Objetivos/Muerte Pato Volteado/{i}.png");
                    deathTextures.Add(frame);
                }
                else
                {
                    IntPtr frame = Engine.LoadImage($"assets/Objetivos/Muerte Pato/{i}.png");
                    deathTextures.Add(frame);
                }

            }
            deathAnimation = new Animation(deathTextures, 0.07f, true);
        }
    }
}
