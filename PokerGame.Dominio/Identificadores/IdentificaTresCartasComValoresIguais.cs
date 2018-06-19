using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaTresCartasComValoresIguais : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IList<Carta> listaDeCartas)
        {

            var tresCartasComMesmoValor = new List<Carta>();

            foreach (var carta in listaDeCartas)
            {
                var primeiraCartaComMesmoValor = listaDeCartas.FirstOrDefault(outraCarta =>
                    outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta);

                var segundaCartaComMesmoValor = listaDeCartas.FirstOrDefault(outraCarta =>
                    outraCarta.Valor == carta.Valor &&
                    outraCarta.HashDaCarta != carta.HashDaCarta &&
                    outraCarta.HashDaCarta != primeiraCartaComMesmoValor?.HashDaCarta);

                if (primeiraCartaComMesmoValor != null && segundaCartaComMesmoValor != null)
                {
                    tresCartasComMesmoValor.Add(carta);
                    tresCartasComMesmoValor.Add(primeiraCartaComMesmoValor);
                    tresCartasComMesmoValor.Add(segundaCartaComMesmoValor);
                    break;
                }
            }

            return tresCartasComMesmoValor;
        }
    }
 }