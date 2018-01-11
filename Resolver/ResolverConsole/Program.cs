using System;
using ResolverConsole.CommandLineParsers;

namespace ResolverConsole
{
    class Program
    {
        /// <summary>
        /// Console consumer of the API.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Input too short. Will use test values: [(0,1), (1,3), (2,0)]");
                args = new[] {"", "0", "1", "1", "3", "2", "0"};
            }
            //var argsParser = new GraphArgsParser(); //Dividing the Graph requires a Graph representation, done via Nodes. This is the parser to nodes.
            var argsParser = new DecimalArrayParser(); //- Use for Difference Between Groups Usecase.
            var parsedArgs = argsParser.Parse(args);
            var response = GroupsComparisonProgram.Run(parsedArgs); //- Use for Difference Between Groups Usecase.
            
            //var response = GraphTraversalProgram.Run(parsedArgs); //Runs the API and gets the response.
            
            if (response.StatusCode != 0)
            {
                Console.WriteLine("An Error Occured: {0}", response.ErrorMessage);
                return;
            }

            foreach (var group in response.Content)
            {
                Console.WriteLine(group);
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}