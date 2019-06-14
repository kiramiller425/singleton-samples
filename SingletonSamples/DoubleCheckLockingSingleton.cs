using System;

namespace SingletonSamples
{
    /// <summary>
    /// Double checks whether instance exists before and after lock. Still not the best performance.
    /// </summary>
    public sealed class DoubleCheckLockingSingleton
    {
        private static DoubleCheckLockingSingleton _instance = null;
        private static readonly object _padlock = new object();

        private DoubleCheckLockingSingleton()
        {

        }

        public static DoubleCheckLockingSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_padlock)
                    {
                        if(_instance == null)
                        {
                            _instance = new DoubleCheckLockingSingleton();
                            Console.WriteLine("   Singleton Instance did not yet exist. Created one now.");
                        }
                        else
                        {
                            Console.WriteLine("   Double-checking revealed that Singleton Instance already exists.");
                        }
                    }
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
