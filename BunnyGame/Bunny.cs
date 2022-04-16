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

        //Texture2D bunnyTexture;

        Model bunnyModel;

        Effect bunnyEffect;

        VertexBuffer vertexBuffer;

        IndexBuffer indexBuffer;

        private VertexPositionColor[] vertices;

        public Bunny(Game game, Matrix world)
        {
            this.bunnyGame = game;
            //this.bunnyTexture = game.Content.Load<Texture2D>("bunny");
            //this.bunnyModel = content.Load<Model>("");
            InitalizeVertices();
            //InitalizeEffect();
            //bunnyEffect.World = world;
        }

        public void LoadContent(ContentManager content)
        {
            bunnyModel = content.Load<Model>("bunny");
        }

        public void InitalizeVertices()
        {
            //number of vertices  24578
            //number of polygons  24576

            vertices = new VertexPositionColor[5];
            // TODO: Add your initialization logic here

            vertices[0] = new VertexPositionColor(new Vector3(-0.5f, 0.5f, 0), Color.Plum);
            vertices[1] = new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0), Color.LightPink);
            vertices[2] = new VertexPositionColor(new Vector3(0.5f, 0.5f, 0), Color.DeepPink);
            vertices[3] = new VertexPositionColor(new Vector3(0.5f, -0.5f, 0), Color.LavenderBlush);
            vertices[4] = new VertexPositionColor(new Vector3(0.7f, 0.5f, 0.5f), Color.MediumPurple);

            vertexBuffer = new VertexBuffer(bunnyGame.GraphicsDevice, VertexPositionColor.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertices);

            RasterizerState state = new RasterizerState();
            state.CullMode = CullMode.CullClockwiseFace;
            state.FillMode = FillMode.WireFrame;
            bunnyGame.GraphicsDevice.RasterizerState = state;

        }

        public void InitalizeIndices()
        { }

        /*
        public void InitalizeEffect()
        {
            bunnyEffect = new BasicEffect(bunnyGame.GraphicsDevice);
            bunnyEffect.World = Matrix.CreateScale(1.0f);
            bunnyEffect.View = Matrix.CreateLookAt(new Vector3(), Vector3.Zero, Vector3.Up);
            bunnyEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, bunnyGame.GraphicsDevice.Viewport.AspectRatio, 0.2f, 50.0f);
            bunnyEffect.TextureEnabled = true;
            bunnyEffect.Texture = bunnyTexture;
            bunnyEffect.LightingEnabled = true;


        }

        */

        public void Draw(ICamera camera)
        {
            //bunnyEffect.View = camera.View;
            //bunnyEffect.Projection = camera.Projection;
           // bunnyEffect.CurrentTechnique.Passes[0].Apply();

            //bunnyGame.GraphicsDevice.SetVertexBuffer(vertexBuffer);
            //bunnyGame.GraphicsDevice.Indices = indexBuffer;
            //bunnyGame.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 100);


            bunnyEffect.CurrentTechnique = bunnyEffect.Techniques["Pretransformed"];
            foreach (EffectPass e in bunnyEffect.CurrentTechnique.Passes)
            {
                e.Apply();
                bunnyGame.GraphicsDevice.SetVertexBuffer(vertexBuffer);
                bunnyGame.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertices, 0, vertices.Length - 2);
            }

        }


    }
}
