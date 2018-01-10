namespace ResolverConsole.CommandLineParsers
{
    public class DecimalArrayParser : IParser<decimal[]>
    {
        public decimal[] Parse(string[] args)
        {
            var result = new decimal[args.Length - 1];
            for (var i = 1; i < args.Length - 1; i++)
            {
                decimal number;
                if (!decimal.TryParse(args[i], out number))
                {
                    return null;
                }

                result[i] = number;
            }

            return result;
        }
    }
}