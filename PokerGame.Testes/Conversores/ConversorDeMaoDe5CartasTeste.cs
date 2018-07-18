using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Conversores;
using Xunit;

namespace PokerGame.Testes.Conversores
{
    public class ConversorDeMaoDe5CartasTeste
    {        
        [Fact]
        public void DeveConverterUmaMaoDe5CartasValidas()
        {
            const string maoDe5Cartas = "4D 6S 9H QH QC";
            var maoDe5CartasEsperada = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Clubs).Construir()
            }.Select(cartas => cartas.HashDaCarta);
            var conversorDeCarta = ConversorDeCartaBuilder.UmConversor()
                .ComConversorDeValorDeCarta(new ConversorDeValorDeCarta())
                .ComConversorDeNaipe(new ConversorDeNaipe())
                .Construir();

            var maoDe5CartasConvertida = new ConversorDeMaoDe5Cartas(conversorDeCarta)
                .Converter(maoDe5Cartas)
                .Select(cartas => cartas.HashDaCarta);
                                    
            Assert.Equal(maoDe5CartasEsperada, maoDe5CartasConvertida);
        }
    }
}

