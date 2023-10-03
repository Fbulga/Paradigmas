using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum GameState
    {
        MenuScreen,
        Gameplay,
        VictoryScreen,
        DefeatScreen
    }
    public class GameStateManager
    {
        private static GameStateManager instance;
        private static GameState gameState;
        private static IntPtr menuImage = Engine.LoadImage("assets/Fondos/MenuInicial.png");
        private static IntPtr victoryImage = Engine.LoadImage("assets/Fondos/PantallaVictoria.png");
        private static IntPtr defeatImage = Engine.LoadImage("assets/Fondos/PantallaDerrota.png");


        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameStateManager();
                }
                return instance;
            }
        }
        public void Update()
        {
            switch (gameState)
            {
                case GameState.MenuScreen:
                    if (Engine.KeyPress(Engine.KEY_P))
                    {
                        GameManager.GameTime = 15.0f;
                        GameManager.DuckHunt = 10;
                        if(LevelManager.enemies != null)
                        {
                            LevelManager.enemies.Clear();
                        }
                        gameState = GameState.Gameplay;
                    }
                    break;
                case GameState.Gameplay:
                    LevelManager.Update();
                    GameManager.GameTime -= Program.DeltaTime;
                    GameManager.GameCondition();
                    break;
                case GameState.VictoryScreen:
                    if (Engine.KeyPress(Engine.KEY_E))
                    {
                        gameState = GameState.MenuScreen;
                    }
                    break;
                case GameState.DefeatScreen:
                    if (Engine.KeyPress(Engine.KEY_E))
                    {
                        gameState = GameState.MenuScreen;
                    }
                    break;
                default:
                    gameState = GameState.MenuScreen;
                    break;
            }
        }
        public static void Render()
        {
            switch (gameState)
            {
                case GameState.MenuScreen:
                    Engine.Draw(menuImage, 0, 0);
                    break;
                case GameState.Gameplay:
                    LevelManager.Render();
                    break;
                case GameState.VictoryScreen:
                    Engine.Draw(victoryImage, 0, 0);
                    break;
                case GameState.DefeatScreen:
                    Engine.Draw(defeatImage, 0, 0);
                    break;
            }
        }
        public static void ChangeGameStatus(GameState newGameState)
        {
            gameState = newGameState;
        }
    }
}
