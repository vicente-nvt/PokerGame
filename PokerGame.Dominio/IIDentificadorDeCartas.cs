using System.Collections.Generic;

namespace PokerGame.Dominio
{
    public interface IIDentificadorDeCartas
    {
        List<Carta> IdentificarCartas(IList<Carta> listaDeCartas);
    }
}