using GameTecJogos5.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GameTecJogos5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bola bola;
        Jogador jogador1, jogador2;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bola = new Bola(Content, new Vector2(100, 100), new Vector2(0, -1), 10);
            jogador1 = new Jogador(Content, new Vector2(0, graphics.PreferredBackBufferHeight/2), Vector2.Zero, 100);
            jogador2 = new Jogador(Content, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight / 2), Vector2.Zero, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            bola.Movimentar(gameTime);
            var kys = Keyboard.GetState();
            if (kys.IsKeyDown(Keys.Up))
                jogador1.Direcao = new Vector2(0, -1);
            if (kys.IsKeyDown(Keys.Down))
                jogador1.Direcao = new Vector2(0, +1);
            if (kys.IsKeyDown(Keys.Right))
                jogador1.Direcao = new Vector2(+1, 0);
            if (kys.IsKeyDown(Keys.Left))
                jogador1.Direcao = new Vector2(-1, 0);
            jogador1.Movimentar(gameTime);

            if (kys.IsKeyDown(Keys.W))
                jogador2.Direcao = new Vector2(0, -1);
            if (kys.IsKeyDown(Keys.S))
                jogador2.Direcao = new Vector2(0, +1);
            if (kys.IsKeyDown(Keys.D))
                jogador2.Direcao = new Vector2(+1, 0);
            if (kys.IsKeyDown(Keys.A))
                jogador2.Direcao = new Vector2(-1, 0);
            jogador2.Movimentar(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            bola.Desenhar(spriteBatch);
            jogador1.Desenhar(spriteBatch);
            jogador2.Desenhar(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
