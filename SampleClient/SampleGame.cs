using System;
using engenious;
using engenious.Input;


namespace SampleClient
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SampleGame : Game
    {

        public SampleGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ScreenComponent screenComponent = new ScreenComponent(this);
            Components.Add(screenComponent);

            screenComponent.KeyDown += (args) =>
            {
                Console.WriteLine("Down: " + args.Key.ToString());
            };

            screenComponent.KeyPress += (args) =>
            {
                Console.WriteLine("Press: " + args.Key.ToString());
            };

            screenComponent.KeyUp += (args) =>
            {
                Console.WriteLine("Up: " + args.Key.ToString());
            };

            


            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F11))
            {
                //TODO: this.ToggleFullScreen();
            }
            if (state.IsKeyDown(Keys.F12))
            {
               
                //TODO:
                //graphics.PreferredBackBufferWidth = 1920;
                //graphics.PreferredBackBufferHeight = 1080;
                //graphics.ApplyChanges();
            }
        }
    }
}
