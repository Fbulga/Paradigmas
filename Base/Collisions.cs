using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Collisions
    {
        public bool OnCollision(Enemy gameObject, Mira point)
        {
            if (gameObject.Transform.Position.x < point.Transform.Position.x + point.Width / 2 && gameObject.Transform.Position.x + gameObject.Width > point.Transform.Position.x + point.Width / 2 && gameObject.Transform.Position.y < point.Transform.Position.y + point.Height / 2 && gameObject.Transform.Position.y + gameObject.Height > point.Transform.Position.y + point.Height / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
