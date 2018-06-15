using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class DoisParesDiferentes : IJogada
    {
        private IList<Carta> _maoDe5Cartas;

        public DoisParesDiferentes(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var doisPares = new List<Carta>();

            foreach (var carta in _maoDe5Cartas)
            {
                var outroPar = _maoDe5Cartas.FirstOrDefault(outraCarta => outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta);

                if (outroPar != null && !doisPares.Contains(carta))
                {
                    doisPares.Add(carta);
                    doisPares.Add(outroPar);
                }
            }

            return doisPares;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 4;
    }
}