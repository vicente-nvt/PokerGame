using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class CartaMaisAlta : IJogada
    {
        private readonly IList<Carta> _maoDe5Cartas;

        public CartaMaisAlta(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            return new List<Carta>() { _maoDe5Cartas.OrderByDescending(carta => carta.Valor).First() };
        }

        public bool JogadaEncontradaNaMao() => Encontrar() != null;
    }
}