using System;
using ResolverConsole.CommandLineParsers;

namespace ResolverConsole
{
    public class Program
    {
        /// <summary>
        /// Console consumer of the API.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Input too short. Will use test values: [(0,1), (1,3), (2,0)]");
                args = new[] {"", "0", "1", "1", "3", "2", "0", "3", "4", "5", "2"};
            }
            var argsParser = new GraphArgsParser(); //Dividing the Graph requires a Graph representation, done via Nodes. This is the parser to nodes.
            //args = new[] {"","1", "4", "6", "9"}; //- Use for Difference Between Groups Usecase.
            //var argsParser = new DecimalArrayParser(); //- Use for Difference Between Groups Usecase.
            var parsedArgs = argsParser.Parse(args);
            //var groupsComparisonRunner = new GroupsComparisonProblemRunner(); //- Use for Difference Between Groups Usecase.
            //var response = groupsComparisonRunner.Run(parsedArgs);  //- Use for Difference Between Groups Usecase.
            var graphDividingRunner = new GraphDividingProblemRunner();
            var response = graphDividingRunner.Run(parsedArgs); //Runs the API and gets the response.
            
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