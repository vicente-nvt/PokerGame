using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
{
    public class DesempateDeFlushTeste
    {
        private readonly List<Carta> _maoB;
        private readonly List<Carta> _maoA;
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeFlushTeste()
        {
            _identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _maoA = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Espadas).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(11).ComNaipe(Naipes.Ouros).Construir()
            };
        }
        [Fact]
        public void DeveDesempatarEntreDoisFlushs()
        {           
            var jogadaVencedoraEsperada = _maoB.Select(carta => carta.HashDaCarta).ToList();
            
            var jogadaVencedoraEncontrada = new DesempateDeFlush(_identificadorDeCartaMaisAlta).Desempatar(_maoA, _maoB)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(jogadaVencedoraEsperada, jogadaVencedoraEncontrada);
        }

        [Fact]
        public void NaoDeveEncontrarVencedorQuandoOsFlushsSaoIguais()
        {
            _maoB[4] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontrada = new DesempateDeFlush(_identificadorDeCartaMaisAlta).Desempatar(_maoA, _maoB);

            Assert.Empty(jogadaEncontrada);
        }
    }
}
