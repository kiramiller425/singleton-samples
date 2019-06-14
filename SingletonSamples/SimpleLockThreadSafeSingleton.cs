using System;

namespace SingletonSamples
{
    /// <summary>
    /// This one is thread-safe, with a simple lock. This is not the best performance, though.
    /// </summary>
    public class SimpleLockThreadSafeSingleton
    {
        private static SimpleLockThreadSafeSingleton _instance = null;
        private static readonly object _padlock = new object();

        private SimpleLockThreadSafeSingleton()
        {

        }

        public static SimpleLockThreadSafeSingleton Instance
        {
            get
            {
                lock (_padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new SimpleLockThreadSafeSingleton();
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
}
