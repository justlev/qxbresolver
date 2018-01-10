using System;
using System.Collections.Generic;
using Resolver.Models.Responses;

namespace Resolver.Models.BinaryGroup
{
    public interface IQubitsCalculationAPI<InputType>
    {
        IResponse<IBinaryGroup<InputType>> GetBestEqualGroups(IEnumerable<InputType> input,
            Func<IEnumerable<short>, bool> qubitsResultsFilter = null);
    }
}