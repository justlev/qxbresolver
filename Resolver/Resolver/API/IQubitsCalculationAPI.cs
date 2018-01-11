using System;
using System.Collections.Generic;
using Resolver.Models.Responses;

namespace Resolver.Models.BinaryGroup
{
    /// <summary>
    /// This is the main API interface.
    /// You expect to call it from wherever (Console, WebUI, ...), and get the final response.
    /// </summary>
    /// <typeparam name="InputType">Type of User's input</typeparam>
    public interface IQubitsCalculationAPI<InputType>
    {
        IResponse<IEnumerable<IBinaryGroup<InputType>>> GetResolvedGroups(IEnumerable<InputType> input,
            Func<IEnumerable<short>, bool> qubitsResultsFilter = null, int maxResults = -1);
    }
}