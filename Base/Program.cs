

using System;
using System.Collections.Generic;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;
 
        static void Main(string[] args)
        {
            Initialize();
            
            while (true)
            {
                CalcDeltaTime();
                GameManager.Instance.Update();

                GameManager.Instance.Render();

                Sdl.SDL_Delay(5);
            }
        }

        private static void CalcDeltaTime()
        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;
        }

        private static void Initialize()
        {
            Engine.Initialize();
            LevelManager.Initialize();
            _startTime = DateTime.Now;
        }
    }

}
