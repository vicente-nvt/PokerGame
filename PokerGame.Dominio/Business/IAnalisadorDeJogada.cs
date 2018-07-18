using System.Collections.Generic;
using PokerGame.Dominio.Business.Jogadas;

namespace PokerGame.Dominio.Business
{
    public interface IAnalisadorDeJogada
    {
        IJogada Analisar(IEnumerable<Carta> maoDeCartas);
    }
}