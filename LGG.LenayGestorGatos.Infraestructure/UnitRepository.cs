
namespace LGG.LenayGestorGatos.Infraestructure;
public class UnitRepository:BaseDisposable, IUnitRepository
{
    private readonly GestorInventariosContext _context;
    private readonly GestorGastosContext _contexto;
    private readonly FirebaseContext _fireContext;
    private readonly IConfiguration _configuration;


    public UnitRepository(GestorInventariosContext context, GestorGastosContext contexto, FirebaseContext fireContext,IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        _contexto = contexto;
        _fireContext = fireContext;
    }

    protected override void DisposeManagedResource()
    {
        try
        {
            _context.Dispose();


            //if (_context.Database.GetDbConnection != null)
            //{
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().State);
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().ConnectionTimeout);
            //}
        }
        finally
        {
            base.DisposeManagedResource();
        }
    }
    //
    public IPersonaInfraestructure personaInfraestructure => new PersonaInfraestructure(_context);

    public IUsuarioInfrastructure usuarioInfrastructure => new UsuarioInfrastructure(_contexto);

    public IFireAuthInfraestructure fireAuthInfraestructure => new FireAuthInfraestructure(_fireContext);

    public IWalletInfraestructure walletInfraestructure => new WalletInfraestructure(_contexto);

    public async ValueTask<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }



    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

}
