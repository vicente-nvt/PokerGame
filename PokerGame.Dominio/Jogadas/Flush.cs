using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class Flush : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartasComMesmoNaipe;

        public Flush(IIDentificadorDeCartas identificadorDeCartasComMesmoNaipe)
        {
            _identificadorDeCartasComMesmoNaipe = identificadorDeCartasComMesmoNaipe;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas) => _identificadorDeCartasComMesmoNaipe.IdentificarCartas(maoDe5Cartas);        

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 5;

        public string Nome => "Flush";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.Flush;
    }
}
