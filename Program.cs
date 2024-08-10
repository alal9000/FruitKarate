using System;
using SplashKitSDK;
using MyGame;

namespace SplashKitDemo
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.LoadSoundEffect("Splat", "Splat.wav");
            FruitKarate _game = new FruitKarate();

            // open the game window
            new Window("Fruit Karate", 800, 600);

            // run the game loop
            while (!SplashKit.WindowCloseRequested("Fruit Karate"))
            {
                // fetch the next batch of UI interaction
                SplashKit.ProcessEvents();

                // check user input - space to launch fruit
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _game.LaunchFruit();
                }

                // punch fruit if mouse is clicked
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    _game.PunchAt(SplashKit.MousePosition());
                }

                // update the postition and velocity of fruit
                _game.Update();

                // clear the screen to white
                SplashKit.ClearScreen(Color.White);

                // draw everything in the game
                _game.Draw();

                // draw onto the screen, limit to 60fps
                SplashKit.RefreshScreen(60);
            }
        }
    }
}
