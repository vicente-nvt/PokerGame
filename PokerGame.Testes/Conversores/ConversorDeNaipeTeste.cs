using System;
using PokerGame.Dominio;
using PokerGame.Dominio.Conversores;
using Xunit;

namespace PokerGame.Testes.Conversores
{
    public class ConversorDeNaipeTeste
    {
        [Theory]
        [InlineData("S", Naipes.Spades)]
        [InlineData("H", Naipes.Hearts)]
        [InlineData("D", Naipes.Diamonds)]
        [InlineData("C", Naipes.Clubs)]
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
