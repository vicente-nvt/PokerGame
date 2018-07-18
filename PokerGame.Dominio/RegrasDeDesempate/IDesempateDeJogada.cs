using System.Collections.Generic;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public interface IDesempateDeJogada
    {
        List<Carta> Desempatar(Jogada jogada, List<Carta> maoA, List<Carta> maoB);
    }
}