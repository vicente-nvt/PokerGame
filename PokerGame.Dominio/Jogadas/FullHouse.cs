﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class FullHouse : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public FullHouse(IIDentificadorDeCartas identificadorDeTrinca, IIDentificadorDeCartas identificadorDePar)
        {
            _identificadorDeTrinca = identificadorDeTrinca;
            _identificadorDePar = identificadorDePar;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            var trinca = _identificadorDeTrinca.IdentificarCartas(maoDe5Cartas);
            var restanteDasCartas = maoDe5Cartas.Where(carta => !trinca.Contains(carta)).ToList();
            var par = _identificadorDePar.IdentificarCartas(restanteDasCartas);

            var fullHouse = new List<Carta>();

            if (trinca.Count == 3 && par.Count == 2)
            {
                fullHouse.AddRange(trinca);
                fullHouse.AddRange(par);
            }

            return fullHouse;
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 5;

        public string Nome => "Full House";
        public int PontuacaoDaJogada => 106;
    }
}