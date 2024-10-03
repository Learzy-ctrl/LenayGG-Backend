

namespace LGG.LenayGestorGatos.Aplication.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IPersonaInfraestructure personaInfraestructure {  get; }
        IUsuarioInfrastructure usuarioInfrastructure { get; }
        IFireAuthInfraestructure fireAuthInfraestructure { get; }
    }
}
