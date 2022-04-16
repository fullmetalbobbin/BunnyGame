using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BunnyGame
{
    public class BunnyCam : ICamera
    {

        BunnyGame game;

        Vector3 position;

        Vector3 direction;

        float horizontalAngle;

        float verticalAngle;

        MouseState oldMousyState;

        public Matrix View { get; set; }

        public Matrix Projection { get; set; }

        public float Swiftness { get; set; } = 0.3f;

        public float Sensitivity { get; set; } = 0.002f;



        public BunnyCam(Game game, Vector3 position)
        {
            this.game = (BunnyGame)game;
            this.position = position;
            this.horizontalAngle = 0;
            this.verticalAngle = 0;

            this.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 1, 300);

            Mouse.SetPosition(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);

            oldMousyState = Mouse.GetState();
        }


        public void Update(GameTime gameTime)
        {
            var newMousyState = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            var facing = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationZ(horizontalAngle));  //double check this rotation!

            if (keyboard.IsKeyDown(Keys.Up)) position += facing * Swiftness;
            if (keyboard.IsKeyDown(Keys.Down)) position -= facing * Swiftness;
            if (keyboard.IsKeyDown(Keys.Left)) position += Vector3.Cross(Vector3.Up, facing) * Swiftness;
            if (keyboard.IsKeyDown(Keys.Right)) position -= Vector3.Cross(Vector3.Up, facing) * Swiftness;

            horizontalAngle += Sensitivity * (oldMousyState.X - newMousyState.X); 
            verticalAngle += Sensitivity * (oldMousyState.Y - newMousyState.Y);

            direction = Vector3.Transform(Vector3.Forward, Matrix.CreateRotationX(verticalAngle) * Matrix.CreateRotationY(horizontalAngle));
            View = Matrix.CreateLookAt(position, position + direction, Vector3.Up);

            Mouse.SetPosition(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);
            oldMousyState = Mouse.GetState();

        }


    }
}
