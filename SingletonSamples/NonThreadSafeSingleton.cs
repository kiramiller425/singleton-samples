
namespace SingletonSamples
{
    /// <summary>
    /// This one is not thread-safe and not a valid Singleton as at least 2 threads could potentially 
    /// evaluate that if statement at nearly the same time and create multiple instances, which 
    /// invalidates this pattern.
    /// </summary>
    public sealed class NonThreadSafeSingleton
    {
        private static NonThreadSafeSingleton _instance = null;

        private NonThreadSafeSingleton()
        {

        }

        public static NonThreadSafeSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new NonThreadSafeSingleton();
                }
                else
                {
                    // this is just to demonstrate
                    throw new System.Exception("Instance already exists.");
                }

                return _instance;
            }
        }
    }
}
