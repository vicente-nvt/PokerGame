using System;
using System.Collections.Generic;

namespace PokerGame.Dominio
{
    public class ConversorDeNaipe : IConversor<Naipes, string>
    {

        private static readonly Dictionary<string, Naipes> MapaDeNaipes = new Dictionary<string, Naipes>()
        {
            { "D", Naipes.Ouros },
            { "H", Naipes.Copas },
            { "S", Naipes.Espadas },
            { "C", Naipes.Paus }
        };

        public Naipes Converter(string naipe)
        {
            if (!MapaDeNaipes.ContainsKey(naipe))
                throw new Exception($"O naipe {naipe} não pode ser convertido.");

            return MapaDeNaipes[naipe];
        }
    }
}