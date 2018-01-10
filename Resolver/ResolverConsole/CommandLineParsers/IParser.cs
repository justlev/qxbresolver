namespace ResolverConsole.CommandLineParsers
{
    public interface IParser<T>
    {
        T Parse(string[] args);
    }
}