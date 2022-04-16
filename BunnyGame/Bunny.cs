using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BunnyGame
{
    public class Bunny
    {
        Game game;

        Texture2D bunnyTexture;

        BasicEffect bunnyEffect;

        VertexBuffer vertexBuffer;

        IndexBuffer indexBuffer;


        public Bunny(Game game)
        { 
        }


        public void InitalizeEffect()
        {
            bunnyEffect = new BasicEffect(game.GraphicsDevice);
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

            game.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            game.GraphicsDevice.Indices = indexBuffer;
            //game.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0);

        }


    }
}
