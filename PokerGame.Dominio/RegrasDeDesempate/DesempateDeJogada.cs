using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.Jogadas;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeJogada
    {
        private readonly Dictionary<Jogada, IRegraDeDesempate> _dicionarioDeDesempate;

        public DesempateDeJogada(IIDentificadorDeCartas identificadorDeTrinca,
            IIDentificadorDeCartas identificadorDeCartaMaisAlta,
            IIDentificadorDeCartas identificadorDeQuadra, 
            IIDentificadorDeCartas identificadorDePar)
        {          

            _dicionarioDeDesempate = new Dictionary<Jogada, IRegraDeDesempate>
            {                
                { Jogada.StraightFlush, new DesempateDeStraightFlush(identificadorDeCartaMaisAlta) },
                { Jogada.Quadra, new DesempateDeQuadra(identificadorDeQuadra) },
                { Jogada.FullHouse, new DesempateDeFullHouse(identificadorDeTrinca) },
                { Jogada.Flush, new DesempateDeFlush(identificadorDeTrinca) },
                { Jogada.Straight, new DesempateDeStraight(identificadorDeCartaMaisAlta) },
                { Jogada.UmaTrinca, new DesempateDeTrinca(identificadorDeTrinca, identificadorDeCartaMaisAlta) },
                { Jogada.DoisParesDiferentes, new DesempateDeDoisPares(identificadorDePar) }
            };
        }

        public List<Carta> Desempatar(Jogada jogada, List<Carta> maoA, List<Carta> maoB)
        {
            return _dicionarioDeDesempate[jogada].Desempatar(maoA, maoB);
        }
    }
}