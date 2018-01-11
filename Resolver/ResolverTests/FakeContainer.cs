using System;
using NSubstitute;
using Resolver.Bias;
using Resolver.Convertion;
using Resolver.Coupling;
using Resolver.Facade;
using Resolver.Models.BinaryGroup;
using Resolver.QuantumResolving;
using Resolver.Services.Data;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace ResolverTests
{
    public static class FakeContainer
    {
        public static IQubitsCalculationAPI<T> GetAPI<T>()
        {
            return Substitute.For<IQubitsCalculationAPI<T>>();
        }

        public static IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType> GetResolvver<InputType,
            InputIDType, BiasValueType, CouplingValueType>()
        {
            return Substitute.For<IQubitsResolver<InputType, InputIDType, BiasValueType, CouplingValueType>>();
        }

        public static IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType> GetFacade<
            InputType, InputIDType, BiasValueType, CouplingValueType>()
        {
            return Substitute
                .For<IQuantumDataExtractionFacade<InputType, InputIDType, BiasValueType, CouplingValueType>>();
        }

        public static IQubitsToGroupsConverter<InputType> GetQubitsToGroupsConverter<InputType>()
        {
            return Substitute.For<IQubitsToGroupsConverter<InputType>>();
        }

        public static INodeTraverser<T> GetTraverser<T>() where T : IEquatable<T>
        {
            return Substitute.For<INodeTraverser<T>>();
        }

        public static IProcessService GetProcessService()
        {
            return Substitute.For<IProcessService>();
        }

        public static IFilesService GetFileService()
        {
            return Substitute.For<IFilesService>();
        }

        public static ICouplingProvider<T, T1> GetCouplingProvider<T, T1>()
        {
            return Substitute.For<ICouplingProvider<T, T1>>();
        }
        
        public static IBiasProvider<T, T1> GetBiasProvider<T, T1>()
        {
            return Substitute.For<IBiasProvider<T, T1>>();
        }
    }
}