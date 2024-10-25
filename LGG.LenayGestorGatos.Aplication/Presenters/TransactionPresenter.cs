/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description:Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class TransactionPresenter : ITransactionPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public TransactionPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
    }
}
