using System.ComponentModel;

namespace PokerGame.Testes
{
    public enum Jogada
    {
        [Description("Carta Alta")]
        CartaMaisAlta = 0,
        [Description("Par de Cartas")]
        UmParDeCartas = 15,
        [Description("Dois Pares de Cartas")]
        DoisPares = 16,
        Trinca = 17,
        Straight = 18,
        Flush = 19,
        [Description("Full House")]
        FullHouse = 20,
        Quadra = 21,
        [Description("Straight Flush")]
        StraightFlush = 22,
        [Description("Royal Flush")]
        RoyalFlush = 23
    }
}