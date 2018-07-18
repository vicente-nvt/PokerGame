using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeStraight : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeStraight(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            var cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(maoA).FirstOrDefault();
            var cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(maoB).FirstOrDefault();

            if (cartaMaisAltaDaMaoA?.Valor == cartaMaisAltaDaMaoB?.Valor)
                return new List<Carta>();

            return cartaMaisAltaDaMaoA?.Valor > cartaMaisAltaDaMaoB?.Valor ? maoA : maoB;
        }
    }
}