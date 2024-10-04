/// Developer : Israel Curiel
/// Creation Date : 02/10/2024
/// Creation Description: Clase
/// Update Date : --
/// Update Description : --
/// CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Infraestructure.Repositories
{
    public class FireAuthInfraestructure : IFireAuthInfraestructure
    {
        private readonly FirebaseContext _fireContext;

        public FireAuthInfraestructure(FirebaseContext fireContext)
        {
            _fireContext = fireContext;
        }

        /// <summary>
        /// Registra usuario usando correo y contraseña con servicio de Firebase Auth
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> SignUp(UsuarioAggregate aggregate)
        {
            try
            {
                var app = _fireContext.firebaseApp;
                var auth = FirebaseAuth.GetAuth(app);
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
            catch (Exception ex)
            {
                return new RespuestaDB
                {
                    Mensaje = $"Error al crear Usuario: {ex.Message}",
                    TipoError = 1
                };
            }
        }

        /// <summary>
        /// Inicia sesión usando correo y contraseña y devuelve un token
        /// </summary>
        public async Task<string> SignIn(string email, string password)
        {
            try
            {
                var app = _fireContext.firebaseApp;
                var auth = FirebaseAuth.GetAuth(app);
                var signInResult = await auth.VerifyIdTokenAsync(email, password);
                return signInResult.IdToken; // Token de autenticación
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al iniciar sesión: {ex.Message}");
            }
        }
    }
}
