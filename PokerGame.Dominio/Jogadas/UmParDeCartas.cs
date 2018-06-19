using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class UmParDeCartas : IJogada

    {
        private readonly IList<Carta> _maoDe5Cartas;

        public UmParDeCartas(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            return new IdentificaDuasCartasComValoresIguais().IdentificarCartas(_maoDe5Cartas);
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 2;
    }
}