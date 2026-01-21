using Xunit;

namespace Conciliation.Tests;

public class SmokeTests
{
    [Fact]
    public void Sanity_check_should_pass()
    {
        Assert.True(true);
    }

    [Fact]
    public void Guid_should_not_be_empty()
    {
        var id = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public void Amount_should_be_positive_example()
    {
        var amount = 199.90m;
        Assert.True(amount > 0);
    }
}
