using Firebase.Storage;
using FirebaseAdmin.Messaging;

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
        private static string bucketUrl = "mvvmguia-ecc82.appspot.com";
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
                var response = await authProvider.CreateUserWithEmailAndPasswordAsync(aggregate.email, aggregate.Contrasenia, aggregate.NombreUser);
                var app = _fireContext.firebaseApp;
                var auth = FirebaseAdmin.Auth.FirebaseAuth.GetAuth(app);
                var decodedToken = await auth.VerifyIdTokenAsync(response.FirebaseToken);
                await authProvider.SendEmailVerificationAsync(response.FirebaseToken);
                var respuesta = new RespuestaDB
                {
                    Resultado = decodedToken.Uid,
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
        public async Task<RespuestaDB> ResetPasswordByEmail(EmailAggregate aggregate)
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

        /// <summary>
        /// Sube imagen a la nube de firebase
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> UploadImage(PhotoUserAggregate photoUserAggregate, string UID)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(photoUserAggregate.ImageBase64);
                using (var stream = new MemoryStream(imageBytes))
                {
                    var storage = new FirebaseStorage(bucketUrl);
                    var imgRef = storage.Child(UID).Child($"userPhoto{UID}");
                    await imgRef.PutAsync(stream);
                    var url = await imgRef.GetDownloadUrlAsync();
                    return new RespuestaDB
                    {
                        NumError = 0,
                        Resultado = url
                    };
                }
            }catch (Exception ex)
            {
                return new RespuestaDB
                {
                    NumError = 1,
                    Resultado = $"Error al subir la imagen {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Borra un usuario de firebase
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteUser(string token)
        {
            try
            {
                await authProvider.DeleteUserAsync(token);
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

        /// <summary>
        /// Cambia el correo de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ChangeUserEmail(string email, string token)
        {
            try
            {
                await authProvider.ChangeUserEmail(token, email);
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

        /// <summary>
        /// Cambia La contrasenia de un usuario
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaDB> ChangeUserPassword(string password, string token)
        {
            try
            {
                await authProvider.ChangeUserPassword(token, password);
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

        /// <summary>
        /// Envia notificaciones al dispositivo del usuario
        /// </summary>
        /// <returns></returns>
        public async Task<NotificationAggregate> SendNotification(string deviceToken, string typeTransaction, string amount, DateTime fechaTransaccion)
        {
            try
            {
                string message = "";
                switch (typeTransaction)
                {
                    case "Gasto":
                        message = "gastado";
                        break;
                    case "Ingreso":
                        message = "ingresado";
                        break;
                    case "Transferencia":
                        message = "transferido";
                        break;
                }

                var messaging = FirebaseMessaging.GetMessaging(_fireContext.firebaseApp);
                var messageNotification = new Message()
                {
                    Token = deviceToken,
                    Notification = new Notification()
                    {
                        Title = $"{typeTransaction} realizado con exito",
                        Body = $"Has {message} ${amount} recientemente"
                    }
                };
                messaging.SendAsync(messageNotification).GetAwaiter();
                return new NotificationAggregate
                {
                    encabezado = $"{typeTransaction} realizado con exito",
                    cuerpo = $"Has {message} ${amount} recientemente",
                    fecha = fechaTransaccion,
                };
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
