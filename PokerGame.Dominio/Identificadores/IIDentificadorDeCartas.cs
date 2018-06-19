using System.Collections.Generic;

namespace PokerGame.Dominio.Identificadores
{
    public interface IIDentificadorDeCartas
    {
        List<Carta> IdentificarCartas(IList<Carta> listaDeCartas);
    }
}