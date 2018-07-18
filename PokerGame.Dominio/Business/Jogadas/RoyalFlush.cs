using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.Jogadas
{
    public class RoyalFlush : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;
        private readonly IIDentificadorDeCartas _identificadorDeNaipesIguais;

        public RoyalFlush(IIDentificadorDeCartas identificadorDeSequencia, 
            IIDentificadorDeCartas identificadorDeNaipesIguais)
        {
            _identificadorDeSequencia = identificadorDeSequencia;
            _identificadorDeNaipesIguais = identificadorDeNaipesIguais;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas)
        {
            var cartasDoMesmoNaipe = _identificadorDeNaipesIguais.IdentificarCartas(maoDe5Cartas);
            var sequenciaDeCartas = _identificadorDeSequencia.IdentificarCartas(cartasDoMesmoNaipe);

            var primeiraCartaDaSequencia = sequenciaDeCartas.FirstOrDefault();

            var primeiraCartaEhUmDez = primeiraCartaDaSequencia?.Valor == 10;

            return primeiraCartaEhUmDez ? sequenciaDeCartas : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 5;

        public string Nome => "Royal Flush";

        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.RoyalFlush;
    }
}