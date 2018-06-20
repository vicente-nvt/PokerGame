using System;
using System.Collections.Generic;
using System.Text;
using PokerGame.Dominio;
using PokerGame.Dominio.Conversores;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using PokerGame.Testes.Identificadores;
using PokerGame.Testes.Jogadas;
using Xunit;

namespace PokerGame.Testes
{
    public class AnalisadorDeJogadasTeste
    {
        private ConversorDeNaipe _conversorDeNaipes;
        private ConversorDeValorDeCarta _conversorDeValorDeCarta;
        private ConversorDeCarta _conversorDeCarta;
        private ConversorDeMaoDe5Cartas _conversorDeMaoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeNaipesIguais;
        private IIDentificadorDeCartas _identificadorDeSequencia;
        private IIDentificadorDeCartas _identificadorDeTrinca;
        private IIDentificadorDeCartas _identificadorDePar;


        public AnalisadorDeJogadasTeste()
        {
            _identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _conversorDeNaipes = new ConversorDeNaipe();
            _conversorDeValorDeCarta = new ConversorDeValorDeCarta();
            _conversorDeCarta = new ConversorDeCarta(_conversorDeValorDeCarta, _conversorDeNaipes);
            _conversorDeMaoDe5Cartas = new ConversorDeMaoDe5Cartas(_conversorDeCarta);
        }

        [Theory]
        [InlineData("4D 6S 9H QH QC", Jogada.UmParDeCartas)]
        public void DeveIdentificarAJogadaDaMao(string mao, Jogada jogadaEsperada)
        {
            IIDentificadorDeCartas identificadorDePar;
            var jogadaEncontrada = new AnalisadorDeJogada(mao, _conversorDeMaoDe5Cartas, _identificadorDeNaipesIguais,
                _identificadorDeSequencia, _identificadorDeTrinca, _identificadorDePar).Analisar();

            Assert.Equal(jogadaEsperada, jogadaEncontrada);
        }
    }

    public class AnalisadorDeJogada
    {
        private string _mao;
        private IConversor<List<Carta>, string> _conversorDeMaoDe5Cartas;
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;
        private readonly IIDentificadorDeCartas _identificadorDeNaipesIguais;
        private IIDentificadorDeCartas _identificadorDeTrinca;
        private IIDentificadorDeCartas _identificadorDePar;

        public AnalisadorDeJogada(string mao, IConversor<List<Carta>, string> conversorDeMaoDe5Cartas, 
            IIDentificadorDeCartas identificadorDeSequencia, 
            IIDentificadorDeCartas identificadorDeNaipesIguais, 
            IIDentificadorDeCartas identificadorDeTrinca, 
            IIDentificadorDeCartas identificadorDePar)
        {
            _mao = mao;
            _conversorDeMaoDe5Cartas = conversorDeMaoDe5Cartas;
            _identificadorDeSequencia = identificadorDeSequencia;
            _identificadorDeNaipesIguais = identificadorDeNaipesIguais;
            _identificadorDeTrinca = identificadorDeTrinca;
            _identificadorDePar = identificadorDePar;
        }

        public Jogada Analisar()
        {
            var maoDeCartas = _conversorDeMaoDe5Cartas.Converter(_mao);

            var listaDeJogadas = new List<IJogada>
            {
                new RoyalFlush(maoDeCartas, _identificadorDeSequencia, _identificadorDeNaipesIguais),
                new StraightFlush(maoDeCartas, _identificadorDeNaipesIguais, _identificadorDeSequencia),
                new Quadra(maoDeCartas),
                new FullHouse(maoDeCartas, _identificadorDeTrinca, _identificadorDePar),
                new Flush(maoDeCartas, _identificadorDeNaipesIguais),
                new Straight(maoDeCartas, _identificadorDeSequencia),
                new UmaTrinca(maoDeCartas, _identificadorDeTrinca),
                new DoisParesDiferentes(maoDeCartas, _identificadorDePar),
                new UmParDeCartas(maoDeCartas),
                new CartaMaisAlta(maoDeCartas)
            };


            return new Jogada();
        }
    }
}
