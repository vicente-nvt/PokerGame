using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Conversores
{
    public class ConversorDeMaoDe5Cartas : IConversor<List<Carta>, string>
    {
        private readonly IConversor<Carta, string> _conversorDeCarta;

        public ConversorDeMaoDe5Cartas(IConversor<Carta, string> conversorDeCarta)
        {
            _conversorDeCarta = conversorDeCarta;
        }

        public List<Carta> Converter(string maoDe5Cartas)
        {
            var listaDeCartasParaConverter = maoDe5Cartas.Split(" ");

            return listaDeCartasParaConverter.Select(carta => _conversorDeCarta.Converter(carta)).ToList();
        }
    }
}