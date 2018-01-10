using System.Collections.Generic;

namespace Resolver.Models.BinaryGroup
{
    /// <summary>
    /// Contains 2 groups of a given type.
    /// Would be widely used if the data of the system is binary.
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IBinaryGroup<TInput>
    {
        IEnumerable<TInput> Group1 { get; }
        IEnumerable<TInput> Group2 { get; }

        void AddToGroup1(TInput value);
        void AddToGroup2(TInput value);
    }
}