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
        int telaX, telaY;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            telaX = graphics.PreferredBackBufferWidth;
            telaY = graphics.PreferredBackBufferHeight;
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bola = new Bola(Content, Vector2.One, new Vector2(0, 0), 100f);
            bola.Posicao = new Vector2((telaX - bola.Textura.Width), (telaY - bola.Textura.Height)) / 2;
            jogador1 = new Jogador(Content, Vector2.One, Vector2.Zero, 1000);
            jogador1.Posicao = new Vector2(0, (telaY - jogador1.Textura.Height) / 2);
            jogador2 = new Jogador(Content, Vector2.One, Vector2.Zero, 1000);
            jogador2.Posicao = new Vector2(telaX - jogador2.Textura.Width, (telaY - jogador2.Textura.Height) / 2);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            var kys = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kys.IsKeyDown(Keys.Escape)) 
            {
                Exit();
            }

            // TODO: Add your update logic here
            if (kys.IsKeyDown(Keys.Up))
            {
                jogador1.Direcao = new Vector2(0, -1);
                if (jogador1.Posicao.Y <= 0)
                    jogador1.Direcao = Vector2.Zero;
            }
            if (kys.IsKeyDown(Keys.Down))
            {
                jogador1.Direcao = new Vector2(0, +1);
                if (jogador1.Posicao.Y + jogador1.Frame.Height>= telaY)
                    jogador1.Direcao = Vector2.Zero;
            }
            if (kys.IsKeyUp(Keys.Up) && kys.IsKeyUp(Keys.Down))
                jogador1.Direcao = Vector2.Zero;


            if (kys.IsKeyDown(Keys.W))
            {
                jogador2.Direcao = new Vector2(0, -1);
                if (jogador2.Posicao.Y <= 0)
                    jogador2.Direcao = Vector2.Zero;
            }
            if (kys.IsKeyDown(Keys.S))
            {
                jogador2.Direcao = new Vector2(0, +1);
                if (jogador2.Posicao.Y + jogador2.Frame.Height >= telaY)
                    jogador2.Direcao = Vector2.Zero;
            }
            if (kys.IsKeyUp(Keys.W) && kys.IsKeyUp(Keys.S))
                jogador2.Direcao = Vector2.Zero;

            bola.Movimentar(gameTime);
            jogador1.Movimentar(gameTime);
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
