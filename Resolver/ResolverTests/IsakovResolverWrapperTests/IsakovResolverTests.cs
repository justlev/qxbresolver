using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;
using Resolver.QuantumResolving;

namespace ResolverTests.IsakovResolverWrapperTests
{
    [TestClass]
    public class IsakovResolverTests
    {
        [TestMethod]
        public void When_ResolvingQubits_UsingIsakovWrapper_TheCouplingsAndBiases_AreDumped_Before_ResolverIsInvoked()
        {
            var processService = FakeContainer.GetProcessService();
            var fileService = FakeContainer.GetFileService();
            var procWorkindDir = "DIR";
            var procName = "PROC";
            var args = "ARGS";
            var scriptInputFileName = "latticeFile";
            
            processService.StartProcess(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(new StreamReader(Stream.Null));
            
            var input = new decimal[] {1, 2, 3, 4};
            var couplings = new List<ICoupling<int, decimal>>();
            couplings.Add(new Coupling<int, decimal>(1,2,2));
            var biases = new List<IBias<int, decimal>>();
            biases.Add(new Bias<int, decimal>(1, 0));
            
            var resolver = new IsakovScriptQubitsResolver<decimal>(processService, procWorkindDir, procName, args, scriptInputFileName, fileService);

            resolver.Resolve(input, biases, couplings);

            Received.InOrder(() =>
            {
                fileService.WriteToFile(scriptInputFileName, Arg.Any<string>());
                processService.Received(1).StartProcess(procWorkindDir, procName, args);
            });
        }
    }
}