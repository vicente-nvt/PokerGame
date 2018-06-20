using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class RoyalFlush : IJogada
    {
        private IList<Carta> _maoDe5cartas;
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;
        private readonly IIDentificadorDeCartas _identificadorDeNaipesIguais;

        public RoyalFlush(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeSequencia, 
            IIDentificadorDeCartas identificadorDeNaipesIguais)
        {
            _maoDe5cartas = maoDe5Cartas;
            _identificadorDeSequencia = identificadorDeSequencia;
            _identificadorDeNaipesIguais = identificadorDeNaipesIguais;
        }

        public List<Carta> Encontrar()
        {
            var cartasDoMesmoNaipe = _identificadorDeNaipesIguais.IdentificarCartas(_maoDe5cartas);
            var sequenciaDeCartas = _identificadorDeSequencia.IdentificarCartas(cartasDoMesmoNaipe);

            var primeiraCartaDaSequencia = sequenciaDeCartas.FirstOrDefault();

            var primeiraCartaEhUmDez = primeiraCartaDaSequencia?.Valor == 10;

            return primeiraCartaEhUmDez ? sequenciaDeCartas : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}