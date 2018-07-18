using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.Jogadas
{
    public class UmaTrinca : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeTresCartasComValoresIguais;

        public UmaTrinca(IIDentificadorDeCartas identificadorDeTresCartasComValoresIguais)
        {
            _identificadorDeTresCartasComValoresIguais = identificadorDeTresCartasComValoresIguais;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas)
        {            
            var trinca = _identificadorDeTresCartasComValoresIguais.IdentificarCartas(maoDe5Cartas);
            var aMaoPossuiUmaTrinca = trinca.Count() == 3;                        

            return aMaoPossuiUmaTrinca ? trinca : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 3;

        public string Nome => "Uma Trinca";

        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.UmaTrinca;
    }
}
