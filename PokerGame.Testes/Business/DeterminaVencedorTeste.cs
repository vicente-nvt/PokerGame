using System.Collections.Generic;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Conversores;
using Xunit;

namespace PokerGame.Testes.Business
{
    public class DeterminaVencedorTeste
    {
        private readonly IConversor<List<Carta>, string> _conversorDeMao;
        private readonly IAnalisadorDeJogada _analisadorDeJogada;
        private readonly IDesempateDeJogada _desempatadorDeJogada;

        public DeterminaVencedorTeste()
        {            
            var conversorDeValorDeCarta = new ConversorDeValorDeCarta();
            var conversorDeNaipe = new ConversorDeNaipe();
            var conversorDeCarta = ConversorDeCartaBuilder.UmConversor()
                .ComConversorDeNaipe(conversorDeNaipe)
                .ComConversorDeValorDeCarta(conversorDeValorDeCarta)
                .Construir();
            _conversorDeMao = ConversorDeMaoDe5CartasBuilder.UmConversor()
                .ComConversorDeCartas(conversorDeCarta)
                .Construir();
            _analisadorDeJogada = AnalisadorDeJogadaBuilder.UmAnalisador()
                .ComIdentificadorDeCartaMaisAltaDefinido()
                .ComIdentificadorDeParDefinido()
                .ComIdentificadorDeTrincaDefinido()
                .ComIdentificadorDeQuatroCartasDefinido()
                .ComIdentificadorDeNaipesIguaisDefinido()
                .ComIdentificadorDeSequenciaDefinido()
                .Construir();
            _desempatadorDeJogada = DesempateDeJogadaBuilder.UmDesempatador()
                .ComIdentificadorDeCartaMaisAltaDefinido()
                .ComIdentificadorDeParDefinido()
                .ComIdentificadorDeTrincaDefinido()
                .ComIdentificadorDeQuadraDefinido()
                .Construir();
        }

        [Theory]
        [InlineData("5H 5C 6S 7S KD", "2C 3S 8S 8D TD", "JogadorB")]
        [InlineData("5D 8C 9S JS AC", "2C 5C 7D 8S QH", "JogadorA")]
        [InlineData("2D 9C AS AH AC", "3D 6D 7D TD QD", "JogadorB")]
        [InlineData("4D 6S 9H QH QC", "3D 6D 7H QD QS", "JogadorA")]
        [InlineData("2H 2D 4C 4D 4S", "3C 3D 3S 9S 9D", "JogadorA")]
        [InlineData("TH JH QH KH AH", "TC JC QC KC AC", "Empate")]

        public void DeveDeterminarJogadorVencedor(string maoA, string maoB, string resultadoEsperado)
        {
            var jogadorA = new Jogador("JogadorA", _conversorDeMao.Converter(maoA));
            var jogadorB = new Jogador("JogadorB", _conversorDeMao.Converter(maoB));

            var jogadorVencedorEncontrado =
                new DeterminaVencedor(_conversorDeMao, _analisadorDeJogada, _desempatadorDeJogada)
                    .Determinar(jogadorA, jogadorB);

            Assert.Equal(resultadoEsperado, jogadorVencedorEncontrado);
        }
    }
}