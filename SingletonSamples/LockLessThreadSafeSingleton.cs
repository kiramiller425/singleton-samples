using System;

namespace SingletonSamples
{
    /// <summary>
    /// This is a semi-lazy, thread-safe example that doesn't use locks. That means less checking and 
    /// faster performance. It works because static constructors in C# only execute when an instance of
    /// the class is created or static member is referenced. There are complications if static constructors
    /// refer to each other in a cycle. Also this isn't the absolute best performance or laziness.
    /// </summary>
    public sealed class LockLessThreadSafeSingleton
    {
        private static readonly LockLessThreadSafeSingleton _instance = new LockLessThreadSafeSingleton();

        static LockLessThreadSafeSingleton()
        {
            // Creating this Singleton instance with the private constructor will also trigger this static constructor:
            Console.WriteLine("   Static constructor triggered.");
        }

        private LockLessThreadSafeSingleton()
        {
            Console.WriteLine("   Singleton Instance created via private constructor.");
        }

        public static LockLessThreadSafeSingleton Instance
        {
            get
            {
                Console.WriteLine("   Returning Singleton Instance.");
                return _instance;
            }
        }
    }
}
