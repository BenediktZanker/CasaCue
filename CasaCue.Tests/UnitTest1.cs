namespace CasaCue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int expected = 5;
            int actual = 2 + 3;
            Assert.Equal(expected, actual);
        }
    }
}
