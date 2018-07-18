using System;
using System.Collections.Generic;

namespace PokerGame.Dominio.Conversores
{
    public class ConversorDeNaipe : IConversor<Naipes, string>
    {

        private static readonly Dictionary<string, Naipes> MapaDeNaipes = new Dictionary<string, Naipes>()
        {
            { "D", Naipes.Diamonds },
            { "H", Naipes.Hearts },
            { "S", Naipes.Spades },
            { "C", Naipes.Clubs }
        };

        public Naipes Converter(string naipe)
        {
            if (!MapaDeNaipes.ContainsKey(naipe))
                throw new Exception($"O naipe {naipe} não pode ser convertido.");

            return MapaDeNaipes[naipe];
        }
    }
}