using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    
    public class GameManager
    {
        private static GameManager instance;
        private static float gameTime = 15.0f;
        private static int duckHunt = 0;
        public static int DuckHunt { 
            get { return duckHunt; }
            set { duckHunt = value; } 
        }
        public static float GameTime
        {
            get { return gameTime; }
            set { gameTime = value; }
        }
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void Update()
        {
           GameStateManager.Instance.Update();
        }

        public void Render()
        {
            Engine.Clear();
            GameStateManager.Render();
            Engine.Show();
        }

        public static void GameCondition()
        {
            if (gameTime < 0)
            {
                GameStateManager.ChangeGameStatus(GameState.DefeatScreen);
            }
            if (duckHunt <= 0)
            {
                GameStateManager.ChangeGameStatus(GameState.VictoryScreen);
            }
        }
    }
}
