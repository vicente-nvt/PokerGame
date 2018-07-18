using System.Collections.Generic;

namespace PokerGame.Dominio.Business.Jogadas
{
    public interface IJogada
    {
        IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas);
        bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas);
        string Nome { get; }
        int PontuacaoDaJogada { get; }
        Jogada Jogada { get; }
    }
}