using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class DoisParesDiferentes : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDePares;

        public DoisParesDiferentes(IIDentificadorDeCartas identificadorDePares)
        {
            _identificadorDePares = identificadorDePares;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas)
        {
            var umPar = _identificadorDePares.IdentificarCartas(maoDe5Cartas);
            var restanteDaMao = maoDe5Cartas.Where(carta => !umPar.Contains(carta)).ToList();
            var outroPar = _identificadorDePares.IdentificarCartas(restanteDaMao);

            var encontrouDoisPares = umPar.Count == 2 && outroPar.Count == 2;    
            var doisPares = new List<Carta>();

            if (encontrouDoisPares)
            {
                doisPares.AddRange(umPar);
                doisPares.AddRange(outroPar);
            }

            return doisPares;
        }

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 4;

        public string Nome => "Dois Pares";
        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.DoisParesDiferentes;
    }
}