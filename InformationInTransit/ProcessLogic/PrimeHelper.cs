using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace InformationInTransit.ProcessLogic
{
    public static partial class PrimeHelper
    {
        static int lowTest = 5000000,
            highTest = 10000000,
            totalTest = highTest - lowTest;

        public static void Main(string[] argv)
        {
            List<int> task1 = Task1();
            foreach (int task in task1)
            {
                System.Console.WriteLine(task);
            }
        }

        public static bool IsPrime(int n)
        {
            // zero, one, and negative numbers are not prime
            if (n < 2) return false;
            // 2 is the only even prime
            else if (n == 2) return true;
            // Check for evens
            else if ((n & 1) == 0) return false;

            double sq = Math.Sqrt(n);
            for (int i = 3; i <= sq; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static List<int> Task1()
        {
            var primes = from item in
                             Enumerable.Range(lowTest, totalTest)
                         where IsPrime(item)
                         select item;

            return primes.ToList();
        }

        public static List<int> Task2()
        {
            var primes = from item in
                             Enumerable.Range(lowTest, totalTest)
                         where IsPrime(item)
                         select item;

            return primes.ToList();
        }

        public static List<int> Task3()
        {
            List<int> primes = new List<int>();
            int complete = 0;

            /*
            Notifies a waiting thread that an event has occurred.
            AutoResetEvent allows threads to communicate with each other by signaling. Typically, this communication concerns a resource to which threads need exclusive access.

            A thread waits for a signal by calling WaitOne on the AutoResetEvent. If the AutoResetEvent is in the non-signaled state, the thread blocks, waiting for the thread that currently controls the resource to signal that the resource is available by calling Set.

            Calling Set signals AutoResetEvent to release a waiting thread. AutoResetEvent remains signaled until a single waiting thread is released, and then automatically returns to the non-signaled state. If no threads are waiting, the state remains signaled indefinitely.

            If a thread calls WaitOne while the AutoResetEvent is in the signaled state, the thread does not block. The AutoResetEvent releases the thread immediately and returns to the non-signaled state.
            */
            AutoResetEvent wait = new AutoResetEvent(false);

            for (int i = lowTest; i < highTest; i++)
            {
                /*
                Queues a method for execution, and specifies an object 
                 * containing data to be used by the method. The method 
                 * executes when a thread pool thread becomes available.
                */
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    /*
                     The lock keyword marks a statement block as a critical 
                     * section by obtaining the mutual-exclusion lock for a 
                     * given object, executing a statement, and then 
                     * releasing the lock. This statement takes the 
                     * following form: 
                    */ 
                    if (IsPrime((int)o))
                        lock (primes) { primes.Add((int)o); }

                    /*Increments a specified variable and stores the result, 
                     * as an atomic operation.
                    */ 
                    if (Interlocked.Increment(ref complete) == totalTest)
                        /*
                        Every object, in addition to having an associated lock, has an associated wait set, which is a set of threads. When an object is first created, its wait set is empty.
                        Wait sets are used by the methods wait (§20.1.6, §20.1.7, §20.1.8), notify (§20.1.9), and notifyAll (§20.1.10) of class Object. These methods also interact with the scheduling mechanism for threads (§20.20).
                        The method wait should be called for an object only when the current thread (call it T) has already locked the object's lock. Suppose that thread T has in fact performed N lock actions that have not been matched by unlock actions. The wait method then adds the current thread to the wait set for the object, disables the current thread for thread scheduling purposes, and performs N unlock actions to relinquish the lock. The thread T then lies dormant until one of three things happens:
                        * Some other thread invokes the notify method for that object and thread T happens to be the one arbitrarily chosen as the one to notify.
                        * Some other thread invokes the notifyAll method for that object.
                        * If the call by thread T to the wait method specified a timeout interval, the specified amount of real time has elapsed. 

                        The thread T is then removed from the wait set and re-enabled for thread scheduling. It then locks the object again (which may involve competing in the usual manner with other threads); once it has gained control of the lock, it performs additional lock actions and then returns from the invocation of the wait method. Thus, on return from the wait method, the state of the object's lock is exactly as it was when the wait method was invoked.

                        The notify method should be called for an object only when the current thread has already locked the object's lock. If the wait set for the object is not empty, then some arbitrarily chosen thread is removed from the wait set and re-enabled for thread scheduling. (Of course, that thread will not be able to proceed until the current thread relinquishes the object's lock.)

                        The notifyAll method should be called for an object only when the current thread has already locked the object's lock. Every thread in the wait set for the object is removed from the wait set and re-enabled for thread scheduling. (Of course, those threads will not be able to proceed until the current thread relinquishes the object's lock.)
                        */
                        wait.Set();
                }, i);
            }

            wait.WaitOne();
            return primes;
        }
    }
}
