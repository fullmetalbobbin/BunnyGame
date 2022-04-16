using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BunnyGame
{
    public class Bunny
    {
        Game bunnyGame;

        Texture2D bunnyTexture;

        Model bunnyModel;

        BasicEffect bunnyEffect;

        VertexBuffer vertexBuffer;

        IndexBuffer indexBuffer;


        public Bunny(Game game, Matrix world)
        {
            this.bunnyGame = game;
            this.bunnyTexture = game.Content.Load<Texture2D>("bunny");
            this.bunnyModel = game.Content.Load<Model>("bunny");
            bunnyEffect.World = world;
        }


        public void InitalizeEffect()
        {
            bunnyEffect = new BasicEffect(bunnyGame.GraphicsDevice);
            bunnyEffect.World = Matrix.CreateScale(1.0f);
            bunnyEffect.View = Matrix.CreateLookAt(new Vector3(), Vector3.Zero, Vector3.Up);
            bunnyEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 0.2f, 50.0f);
            bunnyEffect.TextureEnabled = true;
            bunnyEffect.Texture = bunnyTexture;
            bunnyEffect.LightingEnabled = true;


        }

        public void Draw(ICamera camera)
        {
            bunnyEffect.View = camera.View;
            bunnyEffect.Projection = camera.Projection;
            bunnyEffect.CurrentTechnique.Passes[0].Apply();

            bunnyGame.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            bunnyGame.GraphicsDevice.Indices = indexBuffer;
            bunnyGame.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 100);

        }


    }
}
