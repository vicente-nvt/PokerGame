using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio;
using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;

namespace PokerGame.Testes.RegrasDeDesempate
{
    public class DesempateDeTrinca : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;
        private IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeTrinca(IIDentificadorDeCartas identificadorDeTrinca, IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeTrinca = identificadorDeTrinca;
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            var trincaDaMaoA = _identificadorDeTrinca.IdentificarCartas(maoA);
            var trincaDaMaoB = _identificadorDeTrinca.IdentificarCartas(maoB);

            var valorDaJogadaDaMaoA = trincaDaMaoA.Sum(carta => carta.Valor);
            var valorDaJogadaDaMaoB = trincaDaMaoB.Sum(carta => carta.Valor);

            if (valorDaJogadaDaMaoA == valorDaJogadaDaMaoB)
            {
                var cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta
                    .IdentificarCartas(maoA.Where(carta => !trincaDaMaoA.Contains(carta)).ToList())
                    .First();

                var cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta
                    .IdentificarCartas(maoB.Where(carta => !trincaDaMaoB.Contains(carta)).ToList())
                    .First();

                valorDaJogadaDaMaoA = cartaMaisAltaDaMaoA.Valor;
                valorDaJogadaDaMaoB = cartaMaisAltaDaMaoB.Valor;
            }

            return valorDaJogadaDaMaoA > valorDaJogadaDaMaoB ? maoA : maoB;
        }
    }
}