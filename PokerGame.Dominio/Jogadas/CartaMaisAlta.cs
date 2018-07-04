using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class CartaMaisAlta : IJogada
    {
        private IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public CartaMaisAlta(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            return _identificadorDeCartaMaisAlta.IdentificarCartas(maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas) != null;

        public string Nome => "Carta Mais Alta";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.CartaMaisAlta;
    }
}