using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio
{
    public class UmParDeCartas : IJogada<List<Carta>>
    {
        private readonly IList<Carta> _maoDe5cartas;

        public UmParDeCartas(IList<Carta> maoDe5Cartas)
        {
            _maoDe5cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var _parDeCartas = new List<Carta>();
            foreach (var carta in _maoDe5cartas)
            {
                var cartaPar = _maoDe5cartas.FirstOrDefault(outraCarta => outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta);

                if (cartaPar != null)
                {
                    _parDeCartas.Add(carta);
                    _parDeCartas.Add(cartaPar);                        
                    break;
                }
            }

            return _parDeCartas;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 2;
    }
}