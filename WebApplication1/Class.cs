namespace WebApplication1
{
    public class Class
    {


        public static (int numberOfDays, decimal totalPrice) CalculateRent(RentCarRequest request)
        {
            var cars = new List<Car>
            {
                new Car(1, "Octavia RS", "Skoda", "01.02.2022", "АКПП", "Белый", "Полный привод", 200, 4, "assets/img/Octavia.png"),
                new Car(2, "M 3 Series", "BMW", "20.07.2023", "МКПП", "Красный", "Передний привод", 500, 4, "assets/img/M3.png"),
                new Car(3, "CLA", "Mercedes-Benz", "25.08.2023", "АКПП", "Синий", "Задний привод", 600, 2, "assets/img/cla.png"),
                new Car(4, "A4", "Audi", "10.09.2023", "АКПП", "Черный", "Полный привод", 700, 4, "assets/img/audi-a4.png"),
                new Car(5, "Golf GTI", "Volkswagen", "15.10.2023", "МКПП", "Белый", "Передний привод", 800, 4, "assets/img/GTI.png"),
                new Car(6, "Camry LE", "Toyota", "20.11.2023", "АКПП", "Серебристый", "Передний привод", 900, 4, "assets/img/camry.png"),
                new Car(7, "Accord EX", "Honda", "25.12.2023", "АКПП", "Красный", "Полный привод", 1000, 4, "assets/img/accord.png"),
                new Car(8, "Cruze", "Chevrolet", "10.01.2024", "МКПП", "Синий", "Передний привод", 1100, 4, "assets/img/cruze.png"),
                new Car(9, "Logan", "Renault", "15.02.2024", "АКПП", "Черный", "Полный привод", 1200, 4, "assets/img/logan.png")
            };

            // Вычисление количества дней аренды
            var startDate = DateTime.Parse(request.StartDateRent);
            var endDate = DateTime.Parse(request.EndDateRent);
            var numberOfDays = (endDate - startDate).Days;

            // Вычисление total price
            var carId = request.CarId;
            var car = cars.Find(car => car.Id == carId);

            // Проверка на несуществующий ID
            if (car == null)
            {
                throw new ArgumentException($"Не найден автомобиль с ID: {carId}");
            }

            var priceCar = car.PriceCarDay;
            var totalPrice = Decimal.Multiply(numberOfDays, priceCar);

            return (numberOfDays, totalPrice);
        }

    }
}
