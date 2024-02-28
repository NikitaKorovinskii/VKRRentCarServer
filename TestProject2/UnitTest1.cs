using WebApplication1;
using Xunit.Sdk;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Тест для корректного расчета
        public void CalculateRent_ValidRequest_ReturnsCorrectNumberOfDaysAndTotalPrice()
        {
            // Arrange
            var request = new RentCarRequest
            {
                StartDateRent = "20.02.2024",
                EndDateRent = "25.02.2024",
                CarId = 1
            };

            // Act
            var (numberOfDays, totalPrice) = Class.CalculateRent(request);

            // Assert
            Assert.AreEqual(5, numberOfDays);
            Assert.AreEqual(1000, totalPrice);
        }
        [TestMethod]
        //Тест для случая с одинаковыми датами:
        public void CalculateRent_SameDates_ReturnsZeroDaysAndTotalPrice()
        {
            // Arrange
            var request = new RentCarRequest
            {
                StartDateRent = "2024-02-26",
                EndDateRent = "2024-02-26",
                CarId = 1
            };

            // Act
            var (numberOfDays, totalPrice) = Class.CalculateRent(request);

            // Assert
            Assert.AreEqual(0, numberOfDays);
            Assert.AreEqual(0, totalPrice);
        }
        [TestMethod]
        //Тест для случая с неверным ID машины
        public void CalculateRent_InvalidCarId_ThrowsException()
        {
            // Arrange
            var request = new RentCarRequest
            {
                StartDateRent = "2024-02-26",
                EndDateRent = "2024-03-02",
                CarId = 999
            };

            // Assert
            Assert.ThrowsException<ArgumentException>(() => Class.CalculateRent(request));
        }
    }
}