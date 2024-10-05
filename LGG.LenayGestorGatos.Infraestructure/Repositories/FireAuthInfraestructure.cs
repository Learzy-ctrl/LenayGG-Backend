/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class FireAuthInfraestructure : IFireAuthInfraestructure
    {
        private readonly FirebaseContext _fireContext;
        private static string WebAPIkey = "AIzaSyBElp7J8M4dbtLeagLi_e4xDwvmlN1MhG4";
        private readonly FirebaseAuthProvider authProvider;


        public FireAuthInfraestructure(FirebaseContext fireContext)
        {
            _fireContext = fireContext;
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        }


        /// <summary>
        /// Registra usuario usando correo y contraseña con servicio de firebase Auth
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> SignUp(UsuarioAggregate aggregate)
        {
            try
            {
                var app = _fireContext.firebaseApp;
                var auth = FirebaseAdmin.Auth.FirebaseAuth.GetAuth(app);
                var userRecord = await auth.CreateUserAsync(new UserRecordArgs()
                {
                    Email = aggregate.email,
                    Password = aggregate.Contrasenia,
                    DisplayName = aggregate.NombreUser
                });
                var respuesta = new RespuestaDB
                {
                    Mensaje = userRecord.Uid,
                    TipoError = 0
                };
                return respuesta;
            }
            catch(Exception ex)
            {
                return new RespuestaDB
                {
                    Mensaje = $"Error al crear Usuario: {ex.Message}",
                    TipoError = 1
                };
            }
        }

        /// <summary>
        /// Inicia sesion al usuario y devuelve un token de acceso
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> SignIn(SignInAggregate aggregate)
        {
            try
            {
                var token = await authProvider.SignInWithEmailAndPasswordAsync(aggregate.email, aggregate.password);
                if (token != null)
                {
                    return new RespuestaDB
                    {
                        Mensaje = token.FirebaseToken,
                        TipoError = 0
                    };
                }
                return new RespuestaDB
                {
                    Mensaje = "Usuario no logeado",
                    TipoError = 1
                };
            }
            catch (Exception ex)
            {
                return new RespuestaDB
                {
                    Mensaje = ex.Message,
                    TipoError = 1
                };
            }
        
        }
    }
}
