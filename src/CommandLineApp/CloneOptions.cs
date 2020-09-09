using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using MediatR;

namespace CommandLineApp
{
    [Verb("clone", HelpText = "Clone a repository into a new directory.")]
    public class CloneOptions : IRequest<int>
    {
        [Value(0, MetaName = "Url", Required = true)]
        public string Url { get; set; }
    }

    public class CloneHandler : IRequestHandler<CloneOptions, int>
    {
        public Task<int> Handle(CloneOptions request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Cloning \"{request.Url}\"");
            return Task.FromResult(0);
        }
    }
}
