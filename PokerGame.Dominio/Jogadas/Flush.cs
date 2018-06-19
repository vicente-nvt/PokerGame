using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class Flush : IJogada
    {
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeCartasComMesmoNaipe;

        public Flush(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeCartasComMesmoNaipe)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDeCartasComMesmoNaipe = identificadorDeCartasComMesmoNaipe;
        }

        public List<Carta> Encontrar()
        {
            return _identificadorDeCartasComMesmoNaipe.IdentificarCartas(_maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}
