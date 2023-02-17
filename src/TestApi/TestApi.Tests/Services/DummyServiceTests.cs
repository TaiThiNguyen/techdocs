using Xunit;

public class DummyServiceTests
{
    [Fact]
    public void Happy()
    {
        // Arrange
        var test = 1;

        // Act
        test++;

        // Assert
        Assert.Equal(2, test);
    }
}
