using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class UmaTrinca : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeTresCartasComValoresIguais;

        public UmaTrinca(IIDentificadorDeCartas identificadorDeTresCartasComValoresIguais)
        {
            _identificadorDeTresCartasComValoresIguais = identificadorDeTresCartasComValoresIguais;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {            
            var trinca = _identificadorDeTresCartasComValoresIguais.IdentificarCartas(maoDe5Cartas);
            var aMaoPossuiUmaTrinca = trinca.Count() == 3;                        

            return aMaoPossuiUmaTrinca ? trinca : new List<Carta>();
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 3;

        public string Nome => "Uma Trinca";

        public int PontuacaoDaJogada => 103;
    }
}
