using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class Flush : IJogada
    {
        private IList<Carta> _maoDe5Cartas;

        public Flush(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var listaDeNaipesNaMao = (_maoDe5Cartas as List<Carta>).Select(carta => carta.Naipe).ToList();
            var listaDeNaipesDistintosNaMao = listaDeNaipesNaMao.Distinct();
            var contemMaisDeUmNaipeNaMao = listaDeNaipesDistintosNaMao.Count() > 1;

            return contemMaisDeUmNaipeNaMao ? new List<Carta>() : (List<Carta>)_maoDe5Cartas;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}
