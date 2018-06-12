using System;
using PokerGame.Dominio;
using Xunit;

namespace PokerGame.Testes
{
    public class ConversorDeValorDeCartaTeste
    {

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        [InlineData("4", 4)]
        [InlineData("5", 5)]
        [InlineData("6", 6)]
        [InlineData("7", 7)]
        [InlineData("8", 8)]
        [InlineData("9", 9)]
        [InlineData("10", 10)]
        [InlineData("T", 11)]
        [InlineData("Q", 12)]
        [InlineData("K", 13)]
        [InlineData("A", 14)]
        public void DeveConverterUmValorDeCartaCorreto(string valorDeCartaParaConverter, int valorDeCartaEsperado)
        {
            var valorDeCartaConvertido = new ConversorDeValorDeCarta().Converter(valorDeCartaParaConverter);
            
            Assert.Equal(valorDeCartaEsperado, valorDeCartaConvertido);
        }

        [Theory]
        [InlineData("35")]
        [InlineData("X")]
        public void NaoDeveConverterUmValorDeCartaIncorreto(string valorDaCartaParaConverter)
        {            
            var mensagemEsperada = $"O valor {valorDaCartaParaConverter} não pode ser convertido.";

            var excecao = Assert.Throws<Exception>(() => new ConversorDeValorDeCarta().Converter(valorDaCartaParaConverter));
            
            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}
