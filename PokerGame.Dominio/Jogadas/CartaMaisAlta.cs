using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio
{
    public class CartaMaisAlta : IJogada<Carta>
    {
        private readonly IList<Carta> _maoDe5Cartas;

        public CartaMaisAlta(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public Carta Encontrar()
        {
            return _maoDe5Cartas.OrderByDescending(carta => carta.Valor).First();
        }

        public bool JogadaEncontradaNaMao() => Encontrar() != null;
    }
}