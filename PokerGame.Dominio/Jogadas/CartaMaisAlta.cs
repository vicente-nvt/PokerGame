using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class CartaMaisAlta : IJogada
    {
        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            return new List<Carta>() { maoDe5Cartas.OrderByDescending(carta => carta.Valor).First() };
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas) != null;

        public string Nome => "Carta Mais Alta";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.CartaMaisAlta;
    }
}