

namespace LGG.LenayGestorGatos.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IPersonaInfraestructure personaInfraestructure {  get; }
        IUsuarioInfrastructure usuarioInfrastructure { get; }
        IFireAuthInfraestructure fireAuthInfraestructure { get; }
        IWalletInfraestructure walletInfraestructure { get; }
        ITransactionInfraestructure transactionInfraestructure { get; }
    }
}
