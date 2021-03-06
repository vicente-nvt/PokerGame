﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
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
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Diamonds).Construir()
            };
            _maoB = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Diamonds).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Clubs).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Clubs).Construir()
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
            _maoB[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Diamonds).Construir();

            var jogadaVencedoraEncontrada = _desempateDeCartaMaisAlta.Desempatar(_maoA, _maoB);

            Assert.Empty(jogadaVencedoraEncontrada);
        }
    }
}