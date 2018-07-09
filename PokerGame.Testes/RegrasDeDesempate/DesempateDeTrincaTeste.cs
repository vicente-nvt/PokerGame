using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
{
    public class DesempateDeTrincaTeste
    {
        private List<Carta> _maoB;
        private readonly List<Carta> _maoA;
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeTrincaTeste()
        {
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            _identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();            
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(7).ComNaipe(Naipes.Copas).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Copas).Construir()
            };
        }

        [Fact]
        public void DeveDesempatarEntreDuasTrincasDiferentes()
        {
            var maoVencedoraEsperada = _maoA.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = new DesempateDeTrinca(_identificadorDeTrinca, _identificadorDeCartaMaisAlta)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }
        
        [Fact]
        public void DeveDesempatarEntreDuasTrincasIguais()
        {
            _maoB = _maoA.Select(carta => carta).ToList();
            _maoA[4] = CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Copas).Construir();
            var maoVencedoraEsperada = _maoA.Select(carta => carta.HashDaCarta).ToList();

            var maoVencedoraEncontrada = new DesempateDeTrinca(_identificadorDeTrinca, _identificadorDeCartaMaisAlta)
                .Desempatar(_maoA, _maoB).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(maoVencedoraEsperada, maoVencedoraEncontrada);
        }
    }
}