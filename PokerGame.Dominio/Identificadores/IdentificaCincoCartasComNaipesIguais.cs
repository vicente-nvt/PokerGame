using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Identificadores
{
    public class IdentificaCincoCartasComNaipesIguais : IIDentificadorDeCartas
    {
        public List<Carta> IdentificarCartas(IEnumerable<Carta> listaDeCartas)
        {
            var listaDeNaipesNaMao = listaDeCartas.Select(carta => carta.Naipe).ToList().Distinct();        
            var contemMaisDeUmNaipeNaMao = listaDeNaipesNaMao.Count() > 1;

            return contemMaisDeUmNaipeNaMao ? new List<Carta>() : (List<Carta>) listaDeCartas;
        }
    }
}