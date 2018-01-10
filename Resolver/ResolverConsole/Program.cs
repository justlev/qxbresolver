using System;
using ResolverConsole.CommandLineParsers;

namespace ResolverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Short Input. Will use test values: [(0,1), (1,3), (2,0)]");
                args = new[] {"", "0", "1", "1", "3", "2", "0"};
            }
            var argsParser = new GraphArgsParser();
            //var argsParser = new DecimalArrayParser(); //- Use for Difference Between Groups Usecase.
            var parsedArgs = argsParser.Parse(args);
            //var response = GroupsComparisonProgram.Run(parsedArgs); //- Use for Difference Between Groups Usecase.
            var response = GraphTraversalProgram.Run(parsedArgs);
            if (response.StatusCode != 0)
            {
                Console.WriteLine("An Error Occured: {0}", response.ErrorMessage);
                return;
            }
            Console.WriteLine(response.Content);
        }
    }
}