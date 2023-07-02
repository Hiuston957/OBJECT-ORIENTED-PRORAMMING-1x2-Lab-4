/*
 * If a class implements IDisposable, it must define the Dispose method for releasing
unmanaged resources (a file, a connection, etc.). This method can be called whenever we
need and it cleans after the object. Also, IDisposable allows us to create objects with the
„using” statement which calls Dispose automatically once the object is not used anymore.
You can also manually call the Dispose() method.Be careful – after the object is disposed,
using it is still possible however it may result in troubles. Useful links:
• https://stackoverflow.com/questions/7456953/why-disposed-object-doesnt-throwexception-on-using-it-after-disposing
• https://social.msdn.microsoft.com/Forums/en-US/7fbef9b6-72cd-40c2-a73a4e9d25955928/can-object-exist-after-dispose
*/
using System;
using System.IO; // needed for StreamWriter
namespace Ex_04_08
{
    class Program
    {
        static void Main(string[] args)
        {
            // New style - shorter
            using RandomGenerator gen1 = new RandomGenerator();
            gen1.WriteRandomNumbers("file1.txt", 2077, 0, 100);
            // gen1.Dispose();
            // Old style - longer, however gives more control
            using (RandomGenerator gen2 = new RandomGenerator())
            {
                gen2.WriteRandomNumbers("file2.txt", 44, 0, 2);
            }
            Console.WriteLine("program end");
        }
    }
    /**********************************************************************/
    // RandomGenerator implements IDisposable, so it must define the Dispose method
    // IDisposable allows us to create objects with the "using" statement
    class RandomGenerator : IDisposable
    {
        string path;
        Random rnd;
        StreamWriter writer;
        // Ganerate random numbers and save them to a file
        public void WriteRandomNumbers(string filename, int howMany, int min, int max)
        {
            path = filename;
            rnd = new Random();
            writer = new StreamWriter(path);
            for (int i = 0; i < howMany; i++)
                writer.WriteLine(rnd.Next(min, max));
        }
        // Dispose cleans after the object
        public void Dispose()
        {
            if (!(writer is null)) // or if (writer is not null)
                writer.Dispose();
            Console.WriteLine(path + " cleaned up!");
        }
    }
}
