using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Business.Jogadas;
using PokerGame.Dominio.Business.RegrasDeDesempate;
using PokerGame.Dominio.Conversores;

namespace PokerGame.Dominio.Business
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
            var jogadaJogadorA = _analisadorDeJogada.Analisar(jogadorA.Mao);            
            var jogadaJogadorB = _analisadorDeJogada.Analisar(jogadorB.Mao);

            if (jogadaJogadorA.Jogada != jogadaJogadorB.Jogada)
                return jogadaJogadorA.PontuacaoDaJogada > jogadaJogadorB.PontuacaoDaJogada ? jogadorA.Nome : jogadorB.Nome;

            return Desempatar(jogadorA, jogadorB, jogadaJogadorA);
        }

        private string Desempatar(Jogador jogadorA, Jogador jogadorB, IJogada jogada)        
        {
            var maoVencedoraNoDesempate =
                _desempateDeJogada.Desempatar(jogada.Jogada, jogadorA.Mao, jogadorB.Mao);

            if (!maoVencedoraNoDesempate.Any())
                return "Empate";

            return maoVencedoraNoDesempate.Equals(jogadorA.Mao) ? jogadorA.Nome : jogadorB.Nome;
        }
    }
}