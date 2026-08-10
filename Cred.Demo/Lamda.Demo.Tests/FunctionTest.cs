using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace Lamda.Demo.Tests;

public class FunctionTest
{
    [Fact]
    public async Task TestToUpperFunctionAsync()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Function();
        var context = new TestLambdaContext();
        var upperCase = await function.FunctionHandler(context);

        Assert.Equal("HELLO WORLD", upperCase.First());
    }
}
