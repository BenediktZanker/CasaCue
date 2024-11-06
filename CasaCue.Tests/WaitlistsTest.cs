using CasaCue.Services;

namespace CasaCue.Tests
{
    public class WaitlistTest
    {
        [Fact]
        public void AddGuest_IncreasesWaitlistCount()
        {
            // Arrange
            var waitlist = new Waitlist();

            // Act
            waitlist.AddGuest("John Doe");
            waitlist.AddGuest("Jane Smith");

            // Assert
            Assert.Equal(2, waitlist.GetWaitlistCount());
        }

        [Fact]
        public void GetWaitlistCount_EmptyWaitlist_ReturnsZero()
        {
            // Arrange
            var waitlist = new Waitlist();

            // Act
            var count = waitlist.GetWaitlistCount();

            // Assert
            Assert.Equal(0, count);
        }
    }
}
