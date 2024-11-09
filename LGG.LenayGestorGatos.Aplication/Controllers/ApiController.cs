
using LGG.LenayGestorGatos.Aplication.Presenters;

namespace LGG.LenayGestorGatos.Aplication.Controllers
{
    public class ApiController:IApiController
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public ApiController(IUnitRepository unitRepository, IMapper mapper, IConfiguration configuration)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IPersonaPresenter PersonaPresenter => new PersonaPresenter(_unitRepository, _mapper);

        public IUsuarioPresenter usuarioPresenter => new UsuarioPresenter(_unitRepository, _mapper);

        public IFireAuthPresenter fireAuthPresenter => new FireAuthPresenter(_unitRepository, _mapper);

        public IWalletPresenter walletPresenter => new WalletPresenter(_unitRepository, _mapper);

        public ITransactionPresenter transactionPresenter => new TransactionPresenter(_unitRepository, _mapper);
    }
}
