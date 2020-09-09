using System;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using MediatR;

namespace CommandLineApp
{
    [Verb("commit", HelpText = "Record changes to the repository.")]
    public class CommitOptions : IRequest<int>
    {
        [Option('m', "Message", HelpText = "Message for commit")]
        public string Message { get; set; }
    }

    public class CommitHandler : IRequestHandler<CommitOptions, int>
    {
        public Task<int> Handle(CommitOptions request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Commiting with a message of \"{request.Message}\"");
            return Task.FromResult(0);
        }
    }
}
