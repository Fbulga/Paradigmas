using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelManager
    {
        private static LevelManager instance;
        static IntPtr carpa = Engine.LoadImage("assets/Fondos/FondoCarpa.png");
        static IntPtr arma = Engine.LoadImage("assets/Jugador/Pistola.png");
        static Mira mira;
        public static List<Enemy> enemies = new List<Enemy>();

        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelManager();
                }
                return instance;
            }
        }

        public static void Update()
        {
            mira.Update();
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsActive)
                {
                    enemy.Update();
                }

            }
            if (Engine.KeyPress(Engine.KEY_ESP))
            {
                OnCollision();
            }
            EnemyManager.Update();
        }
        public static void Render()
        {
            Engine.Draw(carpa, 0, 0);
            Engine.Draw(arma, 0, 0);

            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsActive)
                {
                    enemy.Render();
                }
            }
            mira.Render();
        }
        public static void Initialize()
        {
            mira = new Mira(new Vector2(512, 512), 200.0f, "assets/Jugador/Mira.png");
            EnemyManager.GenerateEnemy();
        }
        private static void OnCollision()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsActive && enemy.Transform.Position.x < mira.Transform.Position.x + mira.Width / 2 && enemy.Transform.Position.x + enemy.Width > mira.Transform.Position.x + mira.Width / 2 && enemy.Transform.Position.y < mira.Transform.Position.y + mira.Height / 2 && enemy.Transform.Position.y + enemy.Height > mira.Transform.Position.y + mira.Height / 2)
                {
                    enemy.IsActive = false;
                    GameManager.DuckHunted += 1;
                }
            }
        }
    }
}
