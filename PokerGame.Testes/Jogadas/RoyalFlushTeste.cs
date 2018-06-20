﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class RoyalFlushTeste
    {
        private List<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeSequencia;
        private IIDentificadorDeCartas _identificadorDeNaipesIguais;

        public RoyalFlushTeste()
        {            
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(11).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Copas).Construir()
            };

            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
        }

        [Fact]
        public void DeveEncontrarUmRoyalFlushNaMao()
        {
            var royalFlushEsperado = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(11).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Copas).Construir()
            }.Select(carta => carta.HashDaCarta).ToList();

            var royalFlushEncontrado =
                new RoyalFlush(_maoDe5Cartas, _identificadorDeSequencia, _identificadorDeNaipesIguais).Encontrar()
                    .Select(carta => carta.HashDaCarta).ToList();
            
            Assert.Equal(royalFlushEsperado, royalFlushEncontrado);
        }

        [Fact]
        public void DeveEncontrarAJogadaNaMao()
        {
            var jogadaEncontradaNaMao =
                new RoyalFlush(_maoDe5Cartas, _identificadorDeSequencia, _identificadorDeNaipesIguais)
                    .JogadaEncontradaNaMao();

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeASequenciaEstiverQuebrada()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Copas).Construir();

            var jogadaEncontradaNaMao =
                new RoyalFlush(_maoDe5Cartas, _identificadorDeSequencia, _identificadorDeNaipesIguais)
                    .JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSePeloMenosUmNaipeForDiferentes()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(13).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontradaNaMao =
                new RoyalFlush(_maoDe5Cartas, _identificadorDeSequencia, _identificadorDeNaipesIguais)
                    .JogadaEncontradaNaMao();

            Assert.False(jogadaEncontradaNaMao);
        }
    }
}
