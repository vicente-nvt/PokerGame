﻿using System.Collections.Generic;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificaCincoCartasComNaipesIguaisTeste
    {
        private readonly IList<Carta> _listaDeCartas;

        public IdentificaCincoCartasComNaipesIguaisTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(10).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(8).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).ComNaipe(Naipes.Hearts).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).ComNaipe(Naipes.Hearts).Construir()
            };
        }

        [Fact]
        public void DeveIdentificarTodosOsNaipesIguaisNaLista()
        {
            var todosOsNaipesSaoIguais =
                new IdentificaCincoCartasComNaipesIguais().IdentificarCartas(_listaDeCartas).Count == 5;

            Assert.True(todosOsNaipesSaoIguais);
        }

        [Fact]
        public void NaoDeveIndetificarSeUmNaipeForDiferente()
        {
            _listaDeCartas[0] = CartaBuilder.UmaCarta().ComValor(5).ComNaipe(Naipes.Spades).Construir();

            var todosOsNaipesSaoIguais =
                new IdentificaCincoCartasComNaipesIguais().IdentificarCartas(_listaDeCartas).Count == 5;

            Assert.False(todosOsNaipesSaoIguais);
        }
    }
}
