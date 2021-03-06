﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Business.Jogadas
{
    public class CartaMaisAltaTeste
    {
        private readonly IJogada _cartaMaisAlta;

        public CartaMaisAltaTeste()
        {
            IIDentificadorDeCartas identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            _cartaMaisAlta = new CartaMaisAlta(identificadorDeCartaMaisAlta);
        }        

        [Fact]
        public void DeveEncontrarOValorDaCartaMaisAltaDaMao()
        {
            const int valorDoAs = 14;
            var cartaEsperada = CartaBuilder.UmaCarta().ComValor(valorDoAs).ComNaipe(Naipes.Spades).Construir();
            var maoDe5Cartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(1).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).Construir(),
                CartaBuilder.UmaCarta().ComValor(valorDoAs).Construir()
            };

            var cartaEncontrada = _cartaMaisAlta.Encontrar(maoDe5Cartas).First();

            Assert.Equal(cartaEsperada.Valor, cartaEncontrada.Valor);
        }

        [Fact]
        public void DeveInformarPontuacaoDaJogadaCorretamente()
        {
            const double pontuacaoEsperada = 100;

            double pontuacaoEncontrada = _cartaMaisAlta.PontuacaoDaJogada;

            Assert.Equal(pontuacaoEsperada, pontuacaoEncontrada);
        }
    }
}