using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio
{
    public class AnalisadorDeJogada : IAnalisadorDeJogada 
    {
        private readonly List<IJogada> _listaDeJogadas;

        public AnalisadorDeJogada(IIDentificadorDeCartas identificadorDeSequencia,
            IIDentificadorDeCartas identificadorDeNaipesIguais,
            IIDentificadorDeCartas identificadorDeTrinca,
            IIDentificadorDeCartas identificadorDePar, 
            IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {        

            _listaDeJogadas = new List<IJogada>
            {
                new RoyalFlush(identificadorDeSequencia, identificadorDeNaipesIguais),
                new StraightFlush(identificadorDeNaipesIguais, identificadorDeSequencia),
                new Quadra(),
                new FullHouse(identificadorDeTrinca, identificadorDePar),
                new Flush(identificadorDeNaipesIguais),
                new Straight(identificadorDeSequencia),
                new UmaTrinca(identificadorDeTrinca),
                new DoisParesDiferentes(identificadorDePar),
                new UmParDeCartas(identificadorDePar),
                new CartaMaisAlta(identificadorDeCartaMaisAlta)
            };
        }

        public IJogada Analisar(List<Carta> maoDeCartas)
        {
            return _listaDeJogadas.FirstOrDefault(jogada => jogada.JogadaEncontradaNaMao(maoDeCartas));
        }
    }
}