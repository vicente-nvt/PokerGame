using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaDuasCartasComValoresIguais : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IEnumerable<Carta> listaDeCartas)
        {
            var _parDeCartas = new List<Carta>();
            foreach (var carta in listaDeCartas)
            {
                var cartaPar = listaDeCartas.FirstOrDefault(outraCarta =>
                    outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta);

                if (cartaPar != null)
                {
                    _parDeCartas.Add(carta);
                    _parDeCartas.Add(cartaPar);
                    break;
                }
            }

            return _parDeCartas;
        }
    }
}