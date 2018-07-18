using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business
{
    public class AnalisadorDeJogada : IAnalisadorDeJogada 
    {
        private readonly List<IJogada> _listaDeJogadas;

        public AnalisadorDeJogada(IIDentificadorDeCartas identificadorDeSequencia,
            IIDentificadorDeCartas identificadorDeNaipesIguais,
            IIDentificadorDeCartas identificadorDeTrinca,
            IIDentificadorDeCartas identificadorDePar,
            IIDentificadorDeCartas identificadorDeCartaMaisAlta,
            IIDentificadorDeCartas identificadorDeQuatroCartasComValoresIguais)
        {        
            _listaDeJogadas = new List<IJogada>
            {
                new RoyalFlush(identificadorDeSequencia, identificadorDeNaipesIguais),
                new StraightFlush(identificadorDeNaipesIguais, identificadorDeSequencia),
                new Quadra(identificadorDeQuatroCartasComValoresIguais),
                new FullHouse(identificadorDeTrinca, identificadorDePar),
                new Flush(identificadorDeNaipesIguais),
                new Straight(identificadorDeSequencia),
                new UmaTrinca(identificadorDeTrinca),
                new DoisParesDiferentes(identificadorDePar),
                new UmParDeCartas(identificadorDePar),
                new CartaMaisAlta(identificadorDeCartaMaisAlta)
            };
        }

        public IJogada Analisar(IEnumerable<Carta> maoDeCartas) =>
            _listaDeJogadas.FirstOrDefault(jogada => jogada.JogadaEncontradaNaMao(maoDeCartas));

    }
}