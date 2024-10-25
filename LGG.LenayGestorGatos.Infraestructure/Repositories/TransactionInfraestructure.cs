/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    class TransactionInfraestructure : ITransactionInfraestructure
    {
        private readonly GestorGastosContext _context;
        public TransactionInfraestructure(GestorGastosContext context)
        {
            _context = context;
        }
    }
}
