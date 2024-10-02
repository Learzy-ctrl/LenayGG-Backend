
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

        public IPersonaPresenter PersonaPresenter => new PersonaPresenter(_unitRepository, _mapper);    //
    }
}
