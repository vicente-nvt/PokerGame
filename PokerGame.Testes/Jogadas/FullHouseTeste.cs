﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class FullHouseTeste
    {
        private List<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeTrinca;
        private IIDentificadorDeCartas _identificadorDePar;

        public FullHouseTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Ouros).Construir(),
                CartaBuilder.UmaCarta().ComValor(1).ComNaipe(Naipes.Espadas).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Paus).Construir()
            };

            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
        }

        [Fact]
        public void DeveEncontrarUmFullHouseNaMao()
        {
            var fullHouseEsperado = new List<string> {"1.Copas", "1.Ouros", "1.Espadas", "2.Espadas", "2.Paus"};

            var fullHouseEncontrado = new FullHouse(_identificadorDeTrinca, _identificadorDePar)
                .Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(fullHouseEsperado, fullHouseEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao =
                new FullHouse(_identificadorDeTrinca, _identificadorDePar).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoNaoTiverUmaTrinca()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao =
                new FullHouse(_identificadorDeTrinca, _identificadorDePar).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoQuandoNaoTiverUmPar()
        {
            _maoDe5Cartas[1] = CartaBuilder.UmaCarta().ComValor(3).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao =
                new FullHouse(_identificadorDeTrinca, _identificadorDePar).JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.False(jogadaEncontradaNaMao);
        }

    }
}