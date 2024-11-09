
namespace LGG.LenayGestorGatos.Infraestructure.DataContexts
{
    public class FirebaseContext
    {
        public FirebaseApp firebaseApp { get; }

        public FirebaseContext(string serviceAccountPath)
        {
            firebaseApp = InitializeFirebase(serviceAccountPath);
        }

        private FirebaseApp InitializeFirebase(string serviceAccountPath)
        {
            return FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(serviceAccountPath)
            });
        }
    }
}
