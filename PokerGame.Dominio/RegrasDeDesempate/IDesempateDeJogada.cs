using System.Collections.Generic;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public interface IDesempateDeJogada
    {
        IEnumerable<Carta> Desempatar(Jogada jogada, IEnumerable<Carta> maoA, IEnumerable<Carta> maoB);
    }
}