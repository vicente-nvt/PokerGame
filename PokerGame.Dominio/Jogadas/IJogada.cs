using System.Collections.Generic;

namespace PokerGame.Dominio.Jogadas
{
    public interface IJogada
    {
        List<Carta> Encontrar();
        bool JogadaEncontradaNaMao();
    }
}