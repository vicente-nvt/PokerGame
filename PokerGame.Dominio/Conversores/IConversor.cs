namespace PokerGame.Dominio.Conversores
{
    public interface IConversor<out TTipoSaida, in TTipoEntrada>
    {
        TTipoSaida Converter(TTipoEntrada entrada);
    }
}
