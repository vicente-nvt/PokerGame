﻿using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.Jogadas
{
    public class UmParDeCartas : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public UmParDeCartas(IIDentificadorDeCartas identificadorDePar)
        {
            _identificadorDePar = identificadorDePar;            
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas) => _identificadorDePar.IdentificarCartas(maoDe5Cartas);

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 2;

        public string Nome => "Um Par de Cartas";

        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.UmParDeCartas;
    }
}