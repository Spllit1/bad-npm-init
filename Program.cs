using System;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // clear the console
            Console.Clear();
            // check if the -y flag is set
            bool isYFlagSet = args.Contains("-y");      
            // setup the project
            ProjectSetup.DoAll(isYFlagSet);
        }
    }
}

