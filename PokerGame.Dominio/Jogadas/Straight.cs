using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class Straight : IJogada
    {
        private IList<Carta> _maoDe5Cartas;

        public Straight(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var maoDe5CartasOrdenadaPorValor = _maoDe5Cartas.OrderBy(carta => carta.Valor).ToList();
            var sequenciaQuebrada = false;

            foreach (var carta in maoDe5CartasOrdenadaPorValor)
            {             
                var proximaCarta = maoDe5CartasOrdenadaPorValor.FirstOrDefault(outraCarta => outraCarta.Valor > carta.Valor);

                if (proximaCarta != null && proximaCarta.Valor != carta.Valor + 1)
                {
                    sequenciaQuebrada = true;
                    break;
                }
            }

            return !sequenciaQuebrada ? maoDe5CartasOrdenadaPorValor : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}