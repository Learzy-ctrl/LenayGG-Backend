
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
            //string jsonContent = File.ReadAllText(serviceAccountPath);
            //GoogleCredential credential = GoogleCredential.FromJson(jsonContent);
            GoogleCredential credential = GoogleCredential.FromJson(serviceAccountPath);
            return FirebaseApp.Create(new AppOptions()
            {
                Credential = credential
            });
        }
    }
}
