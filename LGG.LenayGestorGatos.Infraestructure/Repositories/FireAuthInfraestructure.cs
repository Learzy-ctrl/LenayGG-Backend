/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Clase
/// Update Date : 06/11/24
/// Update Description : Metodo recuperar contraseña agregada
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
                    Resultado = userRecord.Uid,
                    NumError = 0
                };
                return respuesta;
            }
            catch(Exception ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Error al crear Usuario: {ex.Message}",
                    NumError = 1
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
                        Resultado = token.FirebaseToken,
                        NumError = 0
                    };
                }
                return new RespuestaDB
                {
                    Resultado = "Usuario no logeado",
                    NumError = 1
                };
            }
            catch (Exception ex)
            {
                return new RespuestaDB
                {
                    Resultado = ex.Message,
                    NumError = 1
                };
            }
        
        }


        /// <summary>
        /// Valida si el token del usuario es valido
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ValidateAuth(string token)
        {
            try
            {
                var app = _fireContext.firebaseApp;
                var auth = FirebaseAdmin.Auth.FirebaseAuth.GetAuth(app);
                var decodedToken = await auth.VerifyIdTokenAsync(token);
                return new RespuestaDB
                {
                    Resultado = decodedToken.Uid,
                    NumError = 0
                };
            }catch(Exception ex)
            {
                return new RespuestaDB
                {
                    Resultado = "Token Expirado o no valido",
                    NumError = 1
                };
            }
        }

        /// <summary>
        /// Envia un correo para resetear contrasenia
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ResetPasswordByEmail(ResetPasswordAggregate aggregate)
        {
            try
            {
                await authProvider.SendPasswordResetEmailAsync(aggregate.Email);
                return new RespuestaDB
                {
                    Resultado = "Correo enviado con exito",
                    NumError = 0
                };
            }
            catch (Exception ex)
            {
                return new RespuestaDB
                {
                    Resultado = $"Ha ocurrido un error {ex.Message}",
                    NumError = 1
                };
            }
        }
    }
}
