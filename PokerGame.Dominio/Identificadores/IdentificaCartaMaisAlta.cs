using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaCartaMaisAlta : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IEnumerable<Carta> listaDeCartas)
        {
            return listaDeCartas.OrderByDescending(carta => carta.Valor).ToList();
        }
    }
}