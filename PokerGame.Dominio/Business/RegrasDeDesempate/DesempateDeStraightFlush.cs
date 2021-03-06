﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.RegrasDeDesempate
{
    public class DesempateDeStraightFlush : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeStraightFlush(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            var cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(maoA).First();
            var cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(maoB).First();

            if (cartaMaisAltaDaMaoA.Valor == cartaMaisAltaDaMaoB.Valor) 
                return new List<Carta>();            

            return cartaMaisAltaDaMaoA.Valor > cartaMaisAltaDaMaoB.Valor ? maoA : maoB;
        }
    }
}