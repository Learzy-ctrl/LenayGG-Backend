/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos

namespace LGG.LenayGestorGatos.Aplication.Presenters
{

    public class UsuarioPresenter : IUsuarioPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UsuarioPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega un registro de la tabla Usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> AddUsuario(UsuarioAggregate aggregate)
        {

            return await _unitRepository.usuarioInfrastructure.AddUsuario(aggregate);
        }
    }
}

