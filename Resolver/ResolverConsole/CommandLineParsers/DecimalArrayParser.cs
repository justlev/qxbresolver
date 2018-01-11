namespace ResolverConsole.CommandLineParsers
{
    /// <summary>
    /// Args are [procName, 1,2,3,4] as string, parses it to decimal[]. 
    /// </summary>
    public class DecimalArrayParser : IParser<decimal[]>
    {
        public decimal[] Parse(string[] args)
        {
            var result = new decimal[args.Length - 1];
            for (var i = 1; i < args.Length; i++)
            {
                decimal number;
                if (!decimal.TryParse(args[i], out number))
                {
                    return null;
                }

                result[i-1] = number;
            }

            return result;
        }
    }
}