using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameObject
    {
        protected Transform transform;
        protected IntPtr image;
        protected int width;
        protected int height;
        protected float speed;
        protected int limit;

        public virtual void Update()
        {

        }
        public virtual void Render()
        {

        }

    }
}
