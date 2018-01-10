using System;
using System.Collections.Generic;
using Resolver.Models.BinaryGroup;

namespace Resolver.Convertion
{
    public interface IQubitsToGroupsConverter<TInput>
    {
        IEnumerable<IBinaryGroup<TInput>> DivideInputIntoGroupsByQubits(IEnumerable<TInput> originalInput,
            IEnumerable<IEnumerable<short>> qubitsGroups, int maxResultsCount = -1, Func<IEnumerable<short>, bool> qubitsResultsFilter = null);
    }
}