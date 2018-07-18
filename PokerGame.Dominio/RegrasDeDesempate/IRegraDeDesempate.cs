﻿using System.Collections.Generic;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public interface IRegraDeDesempate
    {
        IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB);
    }
}