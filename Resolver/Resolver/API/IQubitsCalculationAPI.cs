using System;
using System.Collections.Generic;
using Resolver.Models.BinaryGroup;
using Resolver.Models.Responses;

namespace Resolver.API
{
    /// <summary>
    /// This is the main API interface.
    /// </summary>
    /// <typeparam name="InputType">Type of User's input</typeparam>
    public interface IQubitsCalculationAPI<InputType>
    {
        IResponse<IEnumerable<IBinaryGroup<InputType>>> Resolve(IEnumerable<InputType> input,
            Func<IEnumerable<short>, bool> qubitsResultsFilter = null, int maxResults = -1);
    }
}