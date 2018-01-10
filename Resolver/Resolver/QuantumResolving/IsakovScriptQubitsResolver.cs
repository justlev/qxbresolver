using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Resolver.Models.Bias;
using Resolver.Models.Coupling;
using Resolver.Models.Resolving;
using Resolver.Services.Files;
using Resolver.Services.Process;

namespace Resolver.QuantumResolving
{
    public class IsakovScriptQubitsResolver<InputType> : IQubitsResolver<InputType, int, decimal, decimal>
    {
        private const string LETTICE_FILE_NAME = "IsakovSolver.lattice";
        
        private IProcessService _processService;
        private string _args;
        private string _workingDirectory;
        private string _fileName;
        private IFilesService _fileService;

        public IsakovScriptQubitsResolver(IProcessService processService, string workingDirectory, string fileName, string args, IFilesService fileService)
        {
            _processService = processService;
            _fileService = fileService;
            _workingDirectory = workingDirectory;
            _fileName = fileName;
            _args = args;
        }
        
        public IEnumerable<IQubitsResolvingResponse> Resolve(IEnumerable<InputType> inputNumbers, IEnumerable<IBias<int, decimal>> biases, IEnumerable<ICoupling<int, decimal>> numToCouplings)
        {
            DumpToLatticeFile(biases, numToCouplings);
            
            var output = string.Empty;
            using (var stream = _processService.StartProcess(_workingDirectory, _fileName, _args +" -l "+LETTICE_FILE_NAME))
            {
                output = stream.ReadToEnd();
            }

            if (string.IsNullOrEmpty(output))
            {
                 return new List<IQubitsResolvingResponse>(); //TODO: Maybe better to throw exception? I don't know.       
            }

            return ParseResult(output);
        }

        private IEnumerable<IQubitsResolvingResponse> ParseResult(string output)
        {
            var divider = "&&";
            var formatted = output.Replace("    ", divider);
            formatted = formatted.Replace(" ", "");
            var splittedOutput = formatted.Split(divider);
            var listOfResponses = new List<IQubitsResolvingResponse>();
            for (var i = 0; i < splittedOutput.Length-2; i+=3)
            {
                if (string.IsNullOrEmpty(splittedOutput[i]))
                {
                    i-=2;
                    continue;
                }

                var bytes = new List<short>();
                foreach (var character in splittedOutput[i + 2])
                {
                    if (character == '+') bytes.Add(1);
                    if (character == '-') bytes.Add(-1);
                }

                var response = new IsakovScriptResponse(decimal.Parse(splittedOutput[i]), bytes,
                    long.Parse(splittedOutput[i + 1]));
                listOfResponses.Add(response);
            }

            return listOfResponses;
        }

        private void DumpToLatticeFile(IEnumerable<IBias<int, decimal>> biases, IEnumerable<ICoupling<int, decimal>> couplings)
        {
            var fileContent = new StringBuilder();
            fileContent.Append("Isakov Solver Function File" + Environment.NewLine);
            foreach (var bias in biases)
            {
                fileContent.Append(bias);
                fileContent.Append(Environment.NewLine);
            }

            foreach (var coupling in couplings)
            {
                fileContent.Append(coupling);
                fileContent.Append(Environment.NewLine);
            }
            
            _fileService.WriteToFile(LETTICE_FILE_NAME, fileContent.ToString());
        }
    }
}