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
        public static void Main(string[] args)
        {
            int delayBetweenExamples = 1000; // 1 second

            Console.WriteLine("Starting samples...");

            NonThreadSafeSingletonExample();
            Thread.Sleep(delayBetweenExamples);

            SimpleLockThreadSafeSingletonExample();
            Thread.Sleep(delayBetweenExamples);

            DoubleCheckLockingSingletonExample();
            Thread.Sleep(delayBetweenExamples);


            Console.WriteLine("Completed Samples. Goodbye!");
            var dummyVariable = Console.ReadLine();
        }

        #region NonThreadSafeSingleton

        public static NonThreadSafeSingleton nonThreadSafeSingleton;

        public static void NonThreadSafeSingletonExample()
        {
            try
            {
                // These will likely create at least 2 instances, violating the Singleton pattern:
                ThreadPool.QueueUserWorkItem(SetupNonThreadSafeSingleton);
                ThreadPool.QueueUserWorkItem(SetupNonThreadSafeSingleton);
            }
            catch (Exception exception)
            {
                Console.WriteLine("It should not get here. " + exception.Message);
            }
            finally
            {
                Console.WriteLine("Completed example of NonThreadSafeSingleton.");
            }
        }

        public static void SetupNonThreadSafeSingleton(Object stateInfo)
        {
            nonThreadSafeSingleton = NonThreadSafeSingleton.Instance;
            nonThreadSafeSingleton = NonThreadSafeSingleton.Instance;
            nonThreadSafeSingleton = NonThreadSafeSingleton.Instance;
        }

        #endregion

        #region SimpleLockThreadSafeSingleton

        public static SimpleLockThreadSafeSingleton simpleLockThreadSafeSingleton;

        public static void SimpleLockThreadSafeSingletonExample()
        {
            try
            {
                // There should only be 1 instance created:
                ThreadPool.QueueUserWorkItem(SetupSimpleLockThreadSafeSingleton);
                ThreadPool.QueueUserWorkItem(SetupSimpleLockThreadSafeSingleton);
            }
            catch (Exception exception)
            {
                Console.WriteLine("It should not get here. " + exception.Message);
            }
            finally
            {
                Console.WriteLine("Completed example of SimpleLockThreadSafeSingleton.");
            }
        }

        public static void SetupSimpleLockThreadSafeSingleton(Object stateInfo)
        {
            simpleLockThreadSafeSingleton = SimpleLockThreadSafeSingleton.Instance;
            simpleLockThreadSafeSingleton = SimpleLockThreadSafeSingleton.Instance;
            simpleLockThreadSafeSingleton = SimpleLockThreadSafeSingleton.Instance;
        }

        #endregion

        #region DoubleCheckLockingSingleton

        public static DoubleCheckLockingSingleton doubleCheckLockingSingleton;

        public static void DoubleCheckLockingSingletonExample()
        {
            try
            {
                // There should only be 1 instance created:
                ThreadPool.QueueUserWorkItem(SetupDoubleCheckLockingSingleton);
                ThreadPool.QueueUserWorkItem(SetupDoubleCheckLockingSingleton);
            }
            catch (Exception exception)
            {
                Console.WriteLine("It should not get here. " + exception.Message);
            }
            finally
            {
                Console.WriteLine("Completed example of DoubleCheckLockingSingleton.");
            }
        }

        public static void SetupDoubleCheckLockingSingleton(Object stateInfo)
        {
            doubleCheckLockingSingleton = DoubleCheckLockingSingleton.Instance;
            doubleCheckLockingSingleton = DoubleCheckLockingSingleton.Instance;
            doubleCheckLockingSingleton = DoubleCheckLockingSingleton.Instance;
        }

        #endregion
        
    }
}
