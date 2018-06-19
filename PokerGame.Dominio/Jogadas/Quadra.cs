using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class Quadra : IJogada
    {
        private IList<Carta> _maoDe5Cartas;

        public Quadra(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var quadra = new List<Carta>();

            foreach (var carta in _maoDe5Cartas)
            {
                var outrasTresCartasComMesmoValor = _maoDe5Cartas.Where(outraCarta =>
                    outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta).ToList();

                if (outrasTresCartasComMesmoValor.Count == 3)
                {
                    quadra.Add(carta);
                    quadra.AddRange(outrasTresCartasComMesmoValor);
                    break;
                }
            }

            return quadra;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 4;
    }
}