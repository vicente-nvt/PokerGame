using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Conversores;
using Xunit;

namespace PokerGame.Testes.Conversores
{
    public class ConversorDeCartasTeste
    {
        [Theory]
        [InlineData("5S", 5, Naipes.Spades )]  
        [InlineData("TD", 10, Naipes.Diamonds)]
        [InlineData("AH", 14, Naipes.Hearts)]        
        public void DeveConverterUmaCartaValida(string cartaDeEntrada, int valor, Naipes naipe)
        {
            var cartaEsperada = CartaBuilder.UmaCarta().ComNaipe(naipe).ComValor(valor).Construir();

            var cartaConvertida = new ConversorDeCarta(new ConversorDeValorDeCarta(), new ConversorDeNaipe()).Converter(cartaDeEntrada);

            Assert.Equal(cartaEsperada.Valor, cartaConvertida.Valor);
            Assert.Equal(cartaEsperada.Naipe, cartaConvertida.Naipe);
        }
    }
}