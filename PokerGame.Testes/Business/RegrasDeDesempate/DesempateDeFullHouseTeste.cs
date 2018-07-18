using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeFullHouseTeste
    {
        [Fact]
        public void DeveDesempatarEntreDoisFullHouse()
        {
            var identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            var maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Spades).Construir()
            };
            var maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).ComNaipe(Naipes.Diamonds).Construir()
            };
            var maoVencedoraEsperada = maoA.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = new DesempateDeFullHouse(identificadorDeTrinca)
                .Desempatar(maoA, maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }
    }
}
