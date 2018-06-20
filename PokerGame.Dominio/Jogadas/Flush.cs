using System.Collections.Generic;
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

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas) => _identificadorDeCartasComMesmoNaipe.IdentificarCartas(maoDe5Cartas);        

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 5;

        public string Nome => "Flush";
        public int PontuacaoDaJogada => 105;
    }
}
