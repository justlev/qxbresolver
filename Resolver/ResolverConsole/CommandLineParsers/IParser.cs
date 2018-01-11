namespace ResolverConsole.CommandLineParsers
{
    /// <summary>
    /// Describes an object that takes string arguments as input, and returns a parsed object.
    /// </summary>
    /// <typeparam name="T">Target output type</typeparam>
    public interface IParser<T>
    {
        T Parse(string[] args);
    }
}