using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class Straight : IJogada
    {
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeSequencia;

        public Straight(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeSequencia)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDeSequencia = identificadorDeSequencia;
        }

        public List<Carta> Encontrar()
        {
            return _identificadorDeSequencia.IdentificarCartas(_maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}