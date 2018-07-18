using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaSequenciaDeCarta : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IEnumerable<Carta> listaDeCartas)
        {
            var listaDeCartasOrdenadasPorValor = listaDeCartas.OrderBy(carta => carta.Valor).ToList();
            var sequenciaQuebrada = false;

            foreach (var carta in listaDeCartasOrdenadasPorValor)
            {
                var proximaCarta = listaDeCartasOrdenadasPorValor.FirstOrDefault(outraCarta => outraCarta.Valor > carta.Valor);

                if (proximaCarta != null && proximaCarta.Valor != carta.Valor + 1)
                {
                    sequenciaQuebrada = true;
                    break;
                }
            }

            return !sequenciaQuebrada ? listaDeCartasOrdenadasPorValor : new List<Carta>();
        }
    }
}