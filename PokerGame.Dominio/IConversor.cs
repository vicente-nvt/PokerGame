namespace PokerGame.Dominio
{
    public interface IConversor<out TTipoSaida, in TTipoEntrada>
    {
        TTipoSaida Converter(TTipoEntrada entrada);
    }
}
