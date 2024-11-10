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

        
        /// <summary>
        /// Actualiza foto de perfil de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UploadImage(PhotoUserAggregate photoUserAggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var response = await _unitRepository.fireAuthInfraestructure.UploadImage(photoUserAggregate, respuesta.Resultado);
            if(response.NumError != 0)
            {
                return response;
            }
            return await _unitRepository.usuarioInfrastructure.UploadImage(response.Resultado, respuesta.Resultado);
        }

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateUser(UpdateUserAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.usuarioInfrastructure.UpdateUser(aggregate, respuesta.Resultado);  
        }

        /// <summary>
        /// Consulta un usuario por su id
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetUser(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.usuarioInfrastructure.GetUser(respuesta.Resultado);
        }
        /// <summary>
        /// Elimina un usuario por su id
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteUser(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var response = await _unitRepository.fireAuthInfraestructure.DeleteUser(token);
            if(response.NumError != 0)
            {
                return response;
            }
            return await _unitRepository.usuarioInfrastructure.DeleteUser(respuesta.Resultado);
        }

        /// <summary>
        /// Cambia el correo de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ChangeUserEmail(EmailAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.fireAuthInfraestructure.ChangeUserEmail(aggregate.Email, token);
        }

        /// <summary>
        /// Cambia La contrasenia de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ChangeUserPassword(PasswordAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.fireAuthInfraestructure.ChangeUserPassword(aggregate.password, token);
        }
    }
}

