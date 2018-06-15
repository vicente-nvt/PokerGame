using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class UmParDeCartas : IJogada

    {
        private readonly IList<Carta> _maoDe5Cartas;

        public UmParDeCartas(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var _parDeCartas = new List<Carta>();
            foreach (var carta in _maoDe5Cartas)
            {
                var cartaPar = _maoDe5Cartas.FirstOrDefault(outraCarta => outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta);

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