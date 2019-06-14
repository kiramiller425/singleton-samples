using System;

namespace SingletonSamples
{
    /// <summary>
    /// Instantiation is triggered by the first reference to the static member of the nested class, 
    /// which only occurs in Instance. This implementation is fully lazy. 
    /// </summary>
    public sealed class FullLazySingleton
    {
        private FullLazySingleton()
        {
            Console.WriteLine("   Private constructor triggered.");
        }

        public static FullLazySingleton Instance
        {
            get
            {
                var tempInstance = NestedFullLazySingleton._instance;
                Console.WriteLine("   Returning Singleton Instance.");
                return tempInstance;
            }
        }

        private class NestedFullLazySingleton
        {
            static NestedFullLazySingleton()
            {
                Console.WriteLine("   Static nested constructor triggered.");
            }

            internal static readonly FullLazySingleton _instance = new FullLazySingleton();
        }
    }
}
