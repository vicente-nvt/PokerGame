using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Builders;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes.Identificadores
{
    public class IdentificaSequenciaDeCartasTeste
    {
        private readonly IList<Carta> _listaDeCartas;

        public IdentificaSequenciaDeCartasTeste()
        {
            _listaDeCartas = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(4).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).Construir(),
                CartaBuilder.UmaCarta().ComValor(2).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).Construir()
            };
        }

        [Fact]
        public void DeveIdentificarUmaSequenciaDeCartas()
        {
            var sequenciaEsperada = new List<Carta>
            {
                CartaBuilder.UmaCarta().ComValor(2).Construir(),
                CartaBuilder.UmaCarta().ComValor(3).Construir(),
                CartaBuilder.UmaCarta().ComValor(4).Construir(),
                CartaBuilder.UmaCarta().ComValor(5).Construir(),
                CartaBuilder.UmaCarta().ComValor(6).Construir()
            }.Select(carta => carta.HashDaCarta).ToList();

            var sequenciaIdentificada = new IdentificaSequenciaDeCarta().IdentificarCartas(_listaDeCartas)
                .Select(carta => carta.HashDaCarta).ToList();

            Assert.Equal(sequenciaEsperada, sequenciaIdentificada);
        }
    }
}
