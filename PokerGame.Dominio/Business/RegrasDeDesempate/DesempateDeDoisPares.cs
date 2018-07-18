using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.RegrasDeDesempate
{
    public class DesempateDeDoisPares : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public DesempateDeDoisPares(IIDentificadorDeCartas identificadorDePar)
        {
            _identificadorDePar = identificadorDePar;
        }

        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            var umParDaMaoA = _identificadorDePar.IdentificarCartas(maoA);
            var restanteDaMaoA = maoA.Where(carta => !umParDaMaoA.Contains(carta)).ToList();
            var outroParDaMaoA = _identificadorDePar.IdentificarCartas(restanteDaMaoA);

            var umParDaMaoB = _identificadorDePar.IdentificarCartas(maoB);
            var restanteDaMaoB = maoB.Where(carta => !umParDaMaoB.Contains(carta)).ToList();
            var outroParDaMaoB = _identificadorDePar.IdentificarCartas(restanteDaMaoB);

            var parAltoDaMaoA = umParDaMaoA.First().Valor > outroParDaMaoA.First().Valor ? umParDaMaoA : outroParDaMaoA;
            var parAltoDaMaoB = umParDaMaoB.First().Valor > outroParDaMaoB.First().Valor ? umParDaMaoB : outroParDaMaoB;

            if (parAltoDaMaoA.First().Valor != parAltoDaMaoB.First().Valor)
                return parAltoDaMaoA.First().Valor > parAltoDaMaoB.First().Valor ? maoA : maoB;

            var parBaixoDaMaoA = umParDaMaoA.First().Valor < outroParDaMaoA.First().Valor ? umParDaMaoA : outroParDaMaoA;
            var parBaixoDaMaoB = umParDaMaoB.First().Valor < outroParDaMaoB.First().Valor ? umParDaMaoB : outroParDaMaoB;

            if (parBaixoDaMaoA.First().Valor != parBaixoDaMaoB.First().Valor)
                return parBaixoDaMaoA.First().Valor > parBaixoDaMaoB.First().Valor ? maoA : maoB;

            var quintaCartaDaMaoA = restanteDaMaoA.Where(carta => !outroParDaMaoA.Contains(carta)).ToList();
            var quintaCartaDaMaoB = restanteDaMaoB.Where(carta => !outroParDaMaoB.Contains(carta)).ToList();

            if (quintaCartaDaMaoA.First().Valor == quintaCartaDaMaoB.First().Valor)
                return new List<Carta>();

            return quintaCartaDaMaoA.First().Valor > quintaCartaDaMaoB.First().Valor ? maoA : maoB;
        }
    }
}