using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTecJogos5.Components
{
    public class Jogador
    {
        public float Velocidade { get; set; }
        public Vector2 Posicao { get; set; } //inicio
        public Vector2 Direcao { get; set; } //termino
        public Texture2D Textura { get; set; }
        public Rectangle Frame { get; set; }

        public Jogador()
        {
        }

        public Jogador(ContentManager content, Vector2 posicao, Vector2 direcao, float velocidade = 0)
        {
            Textura = content.Load<Texture2D>("jogador");
            Posicao = posicao;
            Velocidade = velocidade;
            Direcao = direcao;
        }

        public void Movimentar(GameTime gameTime)
        {
            //Tempo real em segundos (deltatime)
            float tempoExecucao = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Calcular a movimentacao constante
            Posicao += Velocidade * Direcao * tempoExecucao;
        }

        public void Desenhar(SpriteBatch spriteBatch)
        {
            Frame = new Rectangle(Convert.ToInt16(Posicao.X), Convert.ToInt16(Posicao.Y), Textura.Width, Textura.Height);
            spriteBatch.Draw(Textura, Frame, Color.White);
        }

    }
}
