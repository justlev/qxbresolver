using System.Collections.Generic;

namespace Resolver.Models.BinaryGroup
{
    /// <summary>
    /// Contains 2 groups of a given type.
    /// Most of the cases, we would want to split User's input data into 2, most effecient groups. This interface holds those groups.
    /// </summary>
    /// <typeparam name="InputType"></typeparam>
    public interface IBinaryGroup<InputType>
    {
        IEnumerable<InputType> Group1 { get; }
        IEnumerable<InputType> Group2 { get; }

        void AddToGroup1(InputType value);
        void AddToGroup2(InputType value);
    }
}