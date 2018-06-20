using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Conversores;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio
{
    public class AnalisadorDeJogada
    {
        private readonly List<IJogada> _listaDeJogadas;
        private readonly IConversor<List<Carta>, string> _conversorDeMaoDe5Cartas;

        public AnalisadorDeJogada(IConversor<List<Carta>, string> conversorDeMaoDe5Cartas, 
            IIDentificadorDeCartas identificadorDeSequencia, 
            IIDentificadorDeCartas identificadorDeNaipesIguais, 
            IIDentificadorDeCartas identificadorDeTrinca, 
            IIDentificadorDeCartas identificadorDePar)
        {
            _conversorDeMaoDe5Cartas = conversorDeMaoDe5Cartas;

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
                new CartaMaisAlta()
            };
        }

        public IJogada Analisar(string mao)
        {
            var maoDeCartas = _conversorDeMaoDe5Cartas.Converter(mao);

            return _listaDeJogadas.FirstOrDefault(jogada => jogada.JogadaEncontradaNaMao(maoDeCartas));
        }
    }
}