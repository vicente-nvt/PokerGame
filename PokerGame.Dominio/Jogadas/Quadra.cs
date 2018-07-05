using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class Quadra : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeQuatroCartasComValoresIguais;

        public Quadra(IIDentificadorDeCartas identificadorDeQuatroCartasComValoresIguais)
        {
            _identificadorDeQuatroCartasComValoresIguais = identificadorDeQuatroCartasComValoresIguais;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            return _identificadorDeQuatroCartasComValoresIguais.IdentificarCartas(maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 4;

        public string Nome => "Quadra";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.Quadra;
    }
}