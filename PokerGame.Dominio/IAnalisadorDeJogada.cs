using System.Collections.Generic;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio
{
    public interface IAnalisadorDeJogada
    {
        IJogada Analisar(IEnumerable<Carta> maoDeCartas);
    }
}