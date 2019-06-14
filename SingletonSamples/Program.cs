/* Singleton Samples
 * Author: Kira Miller
 * Notes: This is just some practice as I follow along with https://csharpindepth.com/articles/singleton
 */

using System;
using System.Threading;

namespace SingletonSamples
{
    public class Program
    {
        public static NonThreadSafeSingleton nonThreadSafeSingleton1;
        public static NonThreadSafeSingleton nonThreadSafeSingleton2;

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting samples...");

            #region NonThreadSafeSingleton

            try
            {
                // In a valid Singleton pattern, these should throw an exception:
                ThreadPool.QueueUserWorkItem(SetupNonThreadSafeSingleton1);
                ThreadPool.QueueUserWorkItem(SetupNonThreadSafeSingleton2);
            }
            catch(Exception exception)
            {
                Console.WriteLine("It will not get here. " + exception.Message);
            }
            finally
            {
                Console.WriteLine("Completed example of NonThreadSafeSingleton.");
            }

            #endregion


            Console.WriteLine("Hello World!");
            var m = Console.ReadLine();
        }

        public static void SetupNonThreadSafeSingleton1(Object stateInfo)
        {
            nonThreadSafeSingleton1 = NonThreadSafeSingleton.Instance;
        }
        public static void SetupNonThreadSafeSingleton2(Object stateInfo)
        {
            nonThreadSafeSingleton2 = NonThreadSafeSingleton.Instance;
        }
    }
}
