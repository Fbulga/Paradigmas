using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
    public class Mira : GameObject
    {
        //private Transform transform;
        //private IntPtr image;
        //private int width = 85;
        //private int height = 83;
        //private float speed;

        public Transform Transform => transform;
        public int Width => width;
        public int Height => height;

        public Mira(Vector2 position, float speed, string image,int width,int height)
        {
            transform = new Transform(position);
            this.image = Engine.LoadImage(image);
            this.speed = speed;
            this.width = width;
            this.height = height;
        }

        public override void Update()
        {
            if (Engine.KeyPress(Engine.KEY_LEFT)) { transform.Traslate(new Vector2(-1, 0), speed); }

            if (Engine.KeyPress(Engine.KEY_RIGHT)) { transform.Traslate(new Vector2(1, 0), speed); }

            if (Engine.KeyPress(Engine.KEY_UP)) { transform.Traslate(new Vector2(0, -1), speed); }

            if (Engine.KeyPress(Engine.KEY_DOWN)) { transform.Traslate(new Vector2(0, 1), speed); }

        }

        public override void Render()
        {
            Engine.Draw(image, transform.Position.x, transform.Position.y);
        }
        

    }

}
