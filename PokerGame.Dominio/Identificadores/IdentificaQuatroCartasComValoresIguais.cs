using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaQuatroCartasComValoresIguais : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IEnumerable<Carta> listaDeCartas)
        {
            var quadra = new List<Carta>();

            foreach (var carta in listaDeCartas)
            {
                var outrasTresCartasComMesmoValor = listaDeCartas.Where(outraCarta =>
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
    }
}