using System;
using PokerGame.Dominio;
using Xunit;

namespace PokerGame.Testes
{


    public class ConversorDeNaipeTeste
    {
        [Theory]
        [InlineData("S", Naipes.Espadas)]
        [InlineData("H", Naipes.Copas)]
        [InlineData("D", Naipes.Ouros)]
        [InlineData("C", Naipes.Paus)]
        public void DeveConverterUmNaipeExistente(string naipeParaConverter, Naipes naipeEsperado)
        {
            var naipeConvertido = new ConversorDeNaipe().Converter(naipeParaConverter);

            Assert.Equal(naipeEsperado, naipeConvertido);
        }

        [Fact]
        public void NaoDeveConverterUmNaipeInexistente()
        {
            const string naipeParaConverter = "X";
            var mensagemEsperada = $"O naipe {naipeParaConverter} não pode ser convertido.";

            var excecao = Assert.Throws<Exception>(() => new ConversorDeNaipe().Converter(naipeParaConverter));

            Assert.Equal(mensagemEsperada, excecao.Message);
        }
    }
}
