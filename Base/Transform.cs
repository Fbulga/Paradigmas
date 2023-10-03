using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Transform
    {
        private Vector2 position;
        private Vector2 scale;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Scale => scale;

        public Transform(Vector2 position) 
        {
            this.position = position;
        }

        public Transform(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public void Traslate(Vector2 direction, float speed)
        {
            position.x += direction.x * speed * Program.DeltaTime;
            position.y += direction.y * speed * Program.DeltaTime;
        }
    }
}
