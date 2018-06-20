using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class StraightFlush : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeNaipesIguais;
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;

        public StraightFlush(IIDentificadorDeCartas identificadorDeNaipesIguais, 
            IIDentificadorDeCartas identificadorDeSequencia)
        {
            _identificadorDeNaipesIguais = identificadorDeNaipesIguais;
            _identificadorDeSequencia = identificadorDeSequencia;            
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            var flush = _identificadorDeNaipesIguais.IdentificarCartas(maoDe5Cartas);
            var straightFlush = _identificadorDeSequencia.IdentificarCartas(flush);
            
            var encontrouUmStraightFlushValido = straightFlush.Count == 5;

            return encontrouUmStraightFlushValido ? straightFlush : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 5;

        public string Nome => "Straight Flush";

        public int PontuacaoDaJogada => 108;
    }
}