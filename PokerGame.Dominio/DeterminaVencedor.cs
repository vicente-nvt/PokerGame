using System.Collections.Generic;
using PokerGame.Dominio.Conversores;
using PokerGame.Dominio.RegrasDeDesempate;

namespace PokerGame.Dominio
{
    public class DeterminaVencedor
    {        
        private readonly IConversor<List<Carta>, string> _conversorDeMaoDe5Cartas;
        private readonly IAnalisadorDeJogada _analisadorDeJogada;
        private readonly IDesempateDeJogada _desempateDeJogada;

        public DeterminaVencedor(IConversor<List<Carta>, string> conversorDeMaoDe5Cartas, 
            IAnalisadorDeJogada analisadorDeJogada, 
            IDesempateDeJogada desempateDeJogada)
        {
            _conversorDeMaoDe5Cartas = conversorDeMaoDe5Cartas;
            _analisadorDeJogada = analisadorDeJogada;
            _desempateDeJogada = desempateDeJogada;
        }

        public string Determinar(Jogador jogadorA, Jogador jogadorB)
        {
            var maoJogadorA = _conversorDeMaoDe5Cartas.Converter(jogadorA.Mao);
            var jogadaJogadorA = _analisadorDeJogada.Analisar(maoJogadorA);

            var maoJogadorB = _conversorDeMaoDe5Cartas.Converter(jogadorB.Mao);
            var jogadaJogadorB = _analisadorDeJogada.Analisar(maoJogadorB);

            if (jogadaJogadorA.Jogada != jogadaJogadorB.Jogada)
                return jogadaJogadorA.PontuacaoDaJogada > jogadaJogadorB.PontuacaoDaJogada ? jogadorA.Nome : jogadorB.Nome;

            return Desempatar(jogadorA, jogadorB, maoJogadorA, jogadaJogadorA, maoJogadorB);
        }

        private string Desempatar(Jogador jogadorA, Jogador jogadorB, List<Carta> maoJogadorA, Jogadas.IJogada jogadaJogadorA, 
            List<Carta> maoJogadorB)
        {
            var maoVencedoraNoDesempate =
                _desempateDeJogada.Desempatar(jogadaJogadorA.Jogada, maoJogadorA, maoJogadorB);

            if (maoVencedoraNoDesempate.Count == 0)
                return "Empate";

            return maoVencedoraNoDesempate.Equals(maoJogadorA) ? jogadorA.Nome : jogadorB.Nome;
        }
    }
}