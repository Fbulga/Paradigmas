using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class EnemyManager
    {
        private static EnemyManager instance;
        private static int estante;
        private static Random rand = new Random();
        private static float acumulador = 0;
        private static float contador = 0;

        public static EnemyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyManager();
                }
                return instance;
            }
        }
        public static void Update()
        {
            acumulador += Program.DeltaTime;
            if(acumulador > 1)
            {
                contador = 0;
                acumulador = 0;
                foreach (Enemy enemy in LevelManager.enemies)
                {
                    if (!enemy.IsActive && !enemy.IsShooted)
                    {
                        estante = rand.Next(1, 5);
                        enemy.ResetEnemy(estante);
                        break;
                    }
                    else { contador++; }
                }
                if (contador == LevelManager.enemies.Count) { GenerateEnemy(); }
            }
        }

        public static void GenerateEnemy()
        {
            estante = rand.Next(1, 5);
            if (estante == 1)
            {
                LevelManager.enemies.Add(new Enemy(223, "assets/Objetivos/Pato volteado.png", -150));
            }
            if (estante == 2)
            {
                LevelManager.enemies.Add(new Enemy(363, "assets/Objetivos/Pato.png", 150));
            }
            if (estante == 3)
            {
                LevelManager.enemies.Add(new Enemy(503, "assets/Objetivos/Pato volteado.png", -150));
            }
            if (estante == 4)
            {
                LevelManager.enemies.Add(new Enemy(650, "assets/Objetivos/Pato.png", 150));
            }
        }
    }
    
}
