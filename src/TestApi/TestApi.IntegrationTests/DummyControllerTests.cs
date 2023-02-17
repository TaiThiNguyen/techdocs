using Xunit;

public class DummyControllerTests
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
