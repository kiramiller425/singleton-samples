using System;

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
                    Console.WriteLine("   Singleton Instance did not yet exist. Created one now.");
                }
                else
                {
                    Console.WriteLine("   Singleton Instance already exists.");
                }

                return _instance;
            }
        }
    }
}
