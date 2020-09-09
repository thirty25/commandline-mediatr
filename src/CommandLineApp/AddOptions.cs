using System;
using System.IO.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using MediatR;

namespace CommandLineApp
{
    [Verb("add", HelpText = "Add file contents to the index.")]
    public class AddOptions : IRequest<int>
    {
        [Value(0, MetaName = "Path", Required = true)]
        public string Path { get; set; }
    }

    public class AddHandler : IRequestHandler<AddOptions, int>
    {
        private readonly IFileSystem _fileSystem;

        public AddHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Task<int> Handle(AddOptions request, CancellationToken cancellationToken)
        {
            if (!_fileSystem.File.Exists(request.Path))
            {
                throw new PathForAddNotFoundException(request.Path);
            }

            Console.WriteLine($"Adding \"{request.Path}\"");
            return Task.FromResult(0);
        }
    }

    public class PathForAddNotFoundException : Exception
    {
        public string Path { get; }

        public PathForAddNotFoundException(string path)
        {
            Path = path;
        }
    }
}
