using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CommandLineApp.Tests
{
    public class AddVerbTests
    {
        [Fact]
        public async Task Add_throws_exception_with_invalid_path()
        {
            var mockFileSystem = new MockFileSystem(
                new Dictionary<string, MockFileData> {{"output.txt", new MockFileData("my data")}}
            );

            var addHandler = new AddHandler(mockFileSystem);

            await Should.ThrowAsync<PathForAddNotFoundException>(async () =>
            {
                await addHandler.Handle(new AddOptions() {Path = "notfound.txt"}, CancellationToken.None);
            });
        }

        [Fact]
        public async Task Add_returns_with_success_for_valid_path()
        {
            var mockFileSystem = new MockFileSystem(
                new Dictionary<string, MockFileData> {{"output.txt", new MockFileData("my data")}}
            );

            var addHandler = new AddHandler(mockFileSystem);
            await addHandler.Handle(new AddOptions() {Path = "output.txt"}, CancellationToken.None);
        }
    }
}
