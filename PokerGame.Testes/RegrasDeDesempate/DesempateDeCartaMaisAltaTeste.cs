using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
{
    public class DesempateDeCartaMaisAltaTeste
    {
        private readonly List<Carta> _maoA;
        private readonly List<Carta> _maoB;
        private readonly IRegraDeDesempate _desempateDeCartaMaisAlta;

        public DesempateDeCartaMaisAltaTeste()
        {
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Ouros).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Paus).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Paus).Construir()
            };
            IIDentificadorDeCartas identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _desempateDeCartaMaisAlta = new DesempateDeCartaMaisAlta(identificadorDeCartaMaisAlta);
        }

        [Fact]
        public void DeveDesempatarEntreCartasMaisAltas()
        {
            var jogadaVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();

            var jogadaVencedoraEncontrada = _desempateDeCartaMaisAlta.Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(jogadaVencedoraEsperada, jogadaVencedoraEncontrada);
        }

        [Fact]
        public void NaoDeveDesempatarEntreCartasMaisAltasEmMaosIguais()
        {
            _maoB[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir();

            var jogadaVencedoraEncontrada = _desempateDeCartaMaisAlta.Desempatar(_maoA, _maoB);

            Assert.Empty(jogadaVencedoraEncontrada);
        }
    }
}