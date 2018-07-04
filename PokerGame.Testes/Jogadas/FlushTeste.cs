﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;
using Xunit;

namespace PokerGame.Testes.Jogadas
{
    public class FlushTeste
    {
        private readonly List<Carta> _maoDe5Cartas;
        private readonly IJogada _flush;

        public FlushTeste()
        {
            _maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(14).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Copas).Construir(),
                CartaBuilder.UmaCarta().ComValor(12).ComNaipe(Naipes.Copas).Construir()
            };

            var identificardorDeCincoNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            _flush = new Flush(identificardorDeCincoNaipesIguais);
        }

        [Fact]
        public void DeveEncontrarUmFlushNaMao()
        {
            var flushEsperado = new List<string> { "5.Copas", "8.Copas", "14.Copas", "10.Copas", "12.Copas" }.ToList();

            var flushEncontrado = _flush.Encontrar(_maoDe5Cartas).Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(flushEsperado, flushEncontrado);
        }

        [Fact]
        public void DeveVerificarSeEncontrouAJogadaNaMao()
        {
            var jogadaEncontradaNaMao = _flush.JogadaEncontradaNaMao(_maoDe5Cartas);

            Assert.True(jogadaEncontradaNaMao);
        }

        [Fact]
        public void NaoDeveEncontrarAJogadaNaMaoSeAlgumaCartaForDeNaipeDiferente()
        {
            _maoDe5Cartas[0] = CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Ouros).Construir();

            var jogadaEncontradaNaMao = _flush.JogadaEncontradaNaMao(_maoDe5Cartas); 

            Assert.False(jogadaEncontradaNaMao);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 105;

            double pontuacaoEncontrada = _flush.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}
