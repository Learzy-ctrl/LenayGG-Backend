﻿/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos

namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class FireAuthPresenter : IFireAuthPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public FireAuthPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Registra usuario usando FirebaseAuth
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> SignUp(UsuarioAggregate aggregate)
        {
            return await _unitRepository.fireAuthInfraestructure.SignUp(aggregate);
        }
    }
}
