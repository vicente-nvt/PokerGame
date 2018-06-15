﻿using System.Collections.Generic;
using PokerGame.Dominio;
using Xunit;

namespace PokerGame.Testes
{
    public class CartaMaisAltaTeste
    {
        [Fact]
        public void DeveEncontrarOValorDaCartaMaisAltaDaMao()
        {
            const int valorDoAs = 14;
            var cartaEsperada = CartaBuilder.UmaCarta().ComValor(valorDoAs).ComNaipe(Naipes.Espadas).Construir();
            var maoDe5Cartas = new List<Carta>()
            {
                CartaBuilder.UmaCarta().ComValor(1).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).Construir(),
                CartaBuilder.UmaCarta().ComValor(9).Construir(),
                CartaBuilder.UmaCarta().ComValor(valorDoAs).Construir()
            };

            var cartaEncontrada = new CartaMaisAlta(maoDe5Cartas).Encontrar();

            Assert.Equal(cartaEsperada.Valor, cartaEncontrada.Valor);
        }        
    }
}