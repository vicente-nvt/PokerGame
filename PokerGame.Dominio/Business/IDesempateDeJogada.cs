using System.Collections.Generic;
using PokerGame.Dominio.Business.Jogadas;

namespace PokerGame.Dominio.Business
{
    public interface IDesempateDeJogada
    {
        IEnumerable<Carta> Desempatar(Jogada jogada, IEnumerable<Carta> maoA, IEnumerable<Carta> maoB);
    }
}