using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class CartaMaisAlta : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public CartaMaisAlta(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas)
        {
            return _identificadorDeCartaMaisAlta.IdentificarCartas(maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas) != null;

        public string Nome => "Carta Mais Alta";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.CartaMaisAlta;
    }
}