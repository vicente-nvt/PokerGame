using System;
using System.Collections.Generic;

namespace PokerGame.Dominio.Conversores
{
    public class ConversorDeValorDeCarta : IConversor<int, string>
    {
        private static readonly Dictionary<string, int> MapaDeValores = new Dictionary<string, int>()
        {            
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "10", 10 },
            { "T", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 },
        };

        public int Converter(string valorDaCarta)
        {
            if (!MapaDeValores.ContainsKey(valorDaCarta))
                throw new Exception($"O valor {valorDaCarta} não pode ser convertido.");

            return MapaDeValores[valorDaCarta];
        }        
    }
}
