using CasaCue.Models;
using CasaCue.Services;
using System;
using Xunit;
using System.Linq;

namespace CasaCue.Tests
{
    public class WaitlistServiceTests
    {
        [Fact]
        public void GetGuestById_ShouldReturnCorrectGuest()
        {
            // Arrange
            var service = new WaitlistService();
            var id = Guid.NewGuid();
            service.AddGuest(id, "John Doe", 3);

            // Act
            var guest = service.GetGuestById(id);

            // Assert
            Assert.NotNull(guest);
            Assert.Equal("John Doe", guest.Name);
            Assert.Equal(3, guest.GroupSize);
        }

        [Fact]
        public void GetGuestsByName_ShouldReturnAllGuestsWithMatchingName()
        {
            // Arrange
            var service = new WaitlistService();
            service.AddGuest(Guid.NewGuid(), "John Doe", 2);
            service.AddGuest(Guid.NewGuid(), "Jane Smith", 4);
            service.AddGuest(Guid.NewGuid(), "John Doe", 1);

            // Act
            var guests = service.GetGuestsByName("John Doe");

            // Assert
            Assert.NotNull(guests);
            Assert.Equal(2, guests.Count());
            Assert.All(guests, g => Assert.Equal("John Doe", g.Name));
        }

        [Fact]
        public void GetGuestByPosition_ShouldReturnCorrectGuest()
        {
            // Arrange
            var service = new WaitlistService();
            service.AddGuest(Guid.NewGuid(), "John Doe", 2);
            service.AddGuest(Guid.NewGuid(), "Jane Smith", 4);

            // Act
            var guest = service.GetGuestByPosition(2);

            // Assert
            Assert.NotNull(guest);
            Assert.Equal("Jane Smith", guest.Name);
        }

        [Fact]
        public void GetGuestByPosition_InvalidPosition_ShouldReturnNull()
        {
            // Arrange
            var service = new WaitlistService();
            service.AddGuest(Guid.NewGuid(), "John Doe", 2);

            // Act
            var guest = service.GetGuestByPosition(5);

            // Assert
            Assert.Null(guest);
        }
    }
}
