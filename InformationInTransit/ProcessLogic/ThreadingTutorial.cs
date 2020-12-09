using System;
using System.Diagnostics;
using System.Threading;

using System.Runtime.Remoting.Contexts;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// if ((worker.ThreadState & ThreadState.WaitSleepJoin) > 0)
    /// </summary>
    public partial class ThreadingTutorial
    {
        static EventWaitHandle eventWaitHandleBasic = new AutoResetEvent(false);
        //EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.Auto);
        //EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.Auto, "MyCompany.MyApp.SomeName");
        static long interlock;
        static object locker = new object();
        static Mutex mutex = new Mutex(false, "domainname.com OneAtATimeDemo");
        static Semaphore s = new Semaphore(3, 3);  // Available=3; Capacity=3
        static bool staticFieldsShareDataBetweenThreads;
        bool threadsShareData;
                
        public static void Main(string[] argv)
        {
            LocalVariablesAreKeptSeparate();
            ThreadsShareDataIfTheyHaveACommonReferenceToTheSameObjectInstance();
            StaticFieldsOfferAnotherWayToShareDataBetweenThreads();
            PassingParameterToThreadStart();
            ForegroundBackgroundThreads();
            ThreadPriorityProcessPriorityClass();
            JoiningAThread();
            WaitHandleBasic();
            OneAtATimePlease();
            SemaphoreTest();
            SynchronizationContexts();
            AtomicityAndInterlocked();
        }

        public static void LocalVariablesAreKeptSeparate()
        {
            new Thread(LocalVariableCallee).Start(); //Calling method on a new thread.
            LocalVariableCallee(); //Calling method on the main thread.
        }

        public static void LocalVariableCallee()
        {
            for (int counter = 1; counter <= 5; counter++)
            {
                System.Console.WriteLine(counter);
            }
        }

        public static void ThreadsShareDataIfTheyHaveACommonReferenceToTheSameObjectInstance()
        {
            ThreadingTutorial tt = new ThreadingTutorial();   // Create a common instance

            new Thread(tt.ThreadsShareDataCallee).Start();

            tt.ThreadsShareDataCallee();
        }

        public void ThreadsShareDataCallee()
        {
            if (!threadsShareData) { threadsShareData = true; Console.WriteLine("Threads share data."); }
        }

        public static void StaticFieldsOfferAnotherWayToShareDataBetweenThreads()
        {
            new Thread(StaticFieldsShareDataBetweenThreadsCallee).Start();
            StaticFieldsShareDataBetweenThreadsCallee();
        }

        public static void StaticFieldsShareDataBetweenThreadsCallee()
        {
            //Obtain an exclusive lock while reading and writing to the common field.
            //lock is a syntactic shortcut for a call to Monitor.Enter try catch finally Monitor.Exit.
            lock (locker)
            {
                if (!staticFieldsShareDataBetweenThreads)
                {
                    staticFieldsShareDataBetweenThreads = true;
                    System.Console.WriteLine("Static fields share data between threads.");
                }
            }
        }

        public static void PassingParameterToThreadStart()
        {
            Thread thread = new Thread(PassingParameterToThreadStartCallee);
            thread.Name = "worker";
            thread.Start(true);
            Thread.CurrentThread.Name = "main";
            PassingParameterToThreadStartCallee(false);
        }

        public static void PassingParameterToThreadStartCallee(object upperCase)
        {
            bool upper = (bool)upperCase;
            Console.WriteLine
            (
                "Thread Name: {0} | Greeting: {1}",
                Thread.CurrentThread.Name,
                upper ? "HELLO!" : "hello!"
            );
        }

        /// <summary>
        /// An application will end, once all the foreground threads are completed.
        /// </summary>
        public static void ForegroundBackgroundThreads()
        {
            Thread worker = new Thread(delegate() { Console.ReadLine(); });

            string[] argv = Environment.GetCommandLineArgs();

            if (argv.Length > 0)
            {
                worker.IsBackground = true;
            }

            worker.Start();
        }

        /// <summary>
        /// enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }
        /// enum ProcessPriorityClass {AboveNormal, BelowNormal, High, Idle, Normal, RealTime }
        /// </summary>
        public static void ThreadPriorityProcessPriorityClass()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        }

        /// <summary>
        /// Block until another thread ends by calling Join
        /// </summary>
        public static void JoiningAThread()
        {
            Thread t = new Thread (delegate() { Console.ReadLine(); });
            t.Start();
            t.Join();    // Wait until thread t finishes
            System.Console.WriteLine ("Thread t's ReadLine complete!");
        }

        public static void WaitHandleBasic()
        {
            new Thread (WaitHandleBasicCallee).Start();
            Thread.Sleep(1000);                    // Wait for some time...
            eventWaitHandleBasic.Set();
        }

        public static void WaitHandleBasicCallee()
        {
            System.Console.WriteLine("Waiting");
            eventWaitHandleBasic.WaitOne();         // Wait for notification
            System.Console.WriteLine("Notified");
        }

        public static void OneAtATimePlease()
        {
            // Wait 5 seconds if contended – in case another instance
            // of the program is in the process of shutting down.
            if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                Console.WriteLine("Another instance of the app is running. Bye!");
                return;
            }
            mutex.ReleaseMutex();
        }

        public static void SemaphoreTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread t = new Thread(SemaphoreTestCallee);
                t.Name = i.ToString();
                t.Start();
            }
            System.Console.ReadLine();
        }

        static void SemaphoreTestCallee()
        {
            DateTime complete = DateTime.Now.AddSeconds(1);
            while (true)
            {
                if (DateTime.Now > complete)
                {
                    break;
                }
                s.WaitOne();
                Thread.Sleep(100);   // Only 3 threads can get here at once
                s.Release();
                System.Console.WriteLine
                (
                    "{0} Thread name: {1}",
                    DateTime.Now,
                    Thread.CurrentThread.Name
                );
            }
        }

        public static void SynchronizationContexts()
        {
            AutoLock safeInstance = new AutoLock();
            new Thread(safeInstance.Demo).Start();      // Call the Demo
            new Thread(safeInstance.Demo).Start();      // method 3 times
            safeInstance.Demo();                        // concurrently.
            System.Console.ReadLine();
        }

        public static void AtomicityAndInterlocked()
        {
            // Simple increment/decrement operations:
            Interlocked.Increment (ref interlock);                              // 1
            Interlocked.Decrement (ref interlock);                              // 0

            // Add/subtract a value:
            Interlocked.Add (ref interlock, 3);                                 // 3

            // Read a 64-bit field:
            Console.WriteLine (Interlocked.Read (ref interlock));               // 3

            // Write a 64-bit field while reading previous value:
            // (This prints "3" while updating interlock to 10)
            Console.WriteLine(Interlocked.Exchange (ref interlock, 10));         // 10

            // Update a field only if it matches a certain value (10):
            Console.WriteLine (Interlocked.CompareExchange (ref interlock, 
                                                            123, 10));      // 123
        }
    }

    [Synchronization]
    public class AutoLock : ContextBoundObject
    {
        public void Demo()
        {
            System.Console.Write("Start...");
            Thread.Sleep(1000);           // We can't be preempted here
            System.Console.WriteLine("end");     // thanks to automatic locking!
        }
    }
}

/*
*/