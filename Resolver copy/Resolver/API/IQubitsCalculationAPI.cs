using System.Collections.Generic;
using Resolver.Models.Responses;

namespace Resolver.Models.BinaryGroup
{
    public interface IQubitsCalculationAPI
    {
        IResponse<IBinaryGroup<decimal>> GetBestEqualGroups(IEnumerable<decimal> input);
    }
}