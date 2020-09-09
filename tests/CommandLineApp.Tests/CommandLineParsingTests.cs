using Shouldly;
using Xunit;

namespace CommandLineApp.Tests
{
    public class CommandLineParsingTests
    {
        [Fact]
        public void Can_map_commit_option()
        {
            var verb = Program.GetVerb(new[] {"commit", "-m", "This is my commit message"});
            verb.ShouldBeOfType<CommitOptions>();
            ((CommitOptions)verb).Message.ShouldBe("This is my commit message");
        }

        [Fact]
        public void Invalid_command_line_parsing_fails()
        {
            Should.Throw<CommandLineParsingException>(() =>
            {
                Program.GetVerb(new[] {"test", "http://example.com"});
            });
        }
    }
}
