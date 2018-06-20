using System.Collections.Generic;
using PokerGame.Dominio;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Testes.Jogadas
{
    public class StraightFlush : IJogada
    {
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeNaipesIguais;
        private IIDentificadorDeCartas _identificadorDeSequencia;

        public StraightFlush(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeNaipesIguais, 
            IIDentificadorDeCartas identificadorDeSequencia)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDeNaipesIguais = identificadorDeNaipesIguais;
            _identificadorDeSequencia = identificadorDeSequencia;
        }

        public List<Carta> Encontrar()
        {
            var flush = _identificadorDeNaipesIguais.IdentificarCartas(_maoDe5Cartas);
            var straightFlush = _identificadorDeSequencia.IdentificarCartas(flush);
            
            var encontrouUmStraightFlushValido = straightFlush.Count == 5;

            return encontrouUmStraightFlushValido ? straightFlush : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}