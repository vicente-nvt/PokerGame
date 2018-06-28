using System.Collections.Generic;

namespace PokerGame.Dominio.Jogadas
{
    public interface IJogada
    {
        List<Carta> Encontrar(List<Carta> maoDe5Cartas);
        bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas);
        string Nome { get; }
        int PontuacaoDaJogada { get; }
    }
}