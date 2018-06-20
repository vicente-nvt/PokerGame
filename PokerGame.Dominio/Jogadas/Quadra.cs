using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class Quadra : IJogada
    {
        public List<Carta> Encontrar(List<Carta> maoDe5Cartas)
        {
            var quadra = new List<Carta>();

            foreach (var carta in maoDe5Cartas)
            {
                var outrasTresCartasComMesmoValor = maoDe5Cartas.Where(outraCarta =>
                    outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta).ToList();

                if (outrasTresCartasComMesmoValor.Count == 3)
                {
                    quadra.Add(carta);
                    quadra.AddRange(outrasTresCartasComMesmoValor);
                    break;
                }
            }

            return quadra;
        }

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 4;

        public string Nome => "Quadra";
        public int PontuacaoDaJogada => 107;
    }
}