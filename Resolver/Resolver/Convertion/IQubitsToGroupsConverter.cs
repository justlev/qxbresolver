using System;
using System.Collections.Generic;
using Resolver.Models.BinaryGroup;

namespace Resolver.Convertion
{
    /// <summary>
    /// The output from the resolver is Qubits. This interface describes a class that takes the user's input, takes the resolved qubits, and an optional filter parameter.
    /// The output is an IEnumerable of Binary Groups, each group contains the appropriate values from the user's input, based on the resolved qubits.
    /// The results can also be filtered at this point.
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IQubitsToGroupsConverter<TInput>
    {
        IEnumerable<IBinaryGroup<TInput>> DivideInputIntoGroupsByQubits(IEnumerable<TInput> originalInput,
            IEnumerable<IEnumerable<short>> qubitsGroups, int maxResultsCount = -1, Func<IEnumerable<short>, bool> qubitsResultsFilter = null);
    }
}