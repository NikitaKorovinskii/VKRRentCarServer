using System.Drawing;

namespace WebApplication1;

public class Car
{
    
        public Car(
            int id, 
            string nameCar,
            string nameBrand, 
            string yearOfRelease,
            string transmissionType,
            string colorCar,
            string typeOfDrive,
            decimal priceCarDay,
            int countOfSeats,
            string imgCar)
        {
        Id = id;
        NameCar = nameCar;
        NameBrand = nameBrand;
        YearOfRelease = yearOfRelease;
        TransmissionType = transmissionType;
        ColorCar = colorCar;
        TypeOfDrive = typeOfDrive;
        PriceCarDay = priceCarDay;
        CountOfSeats = countOfSeats;
        ImgCar = imgCar;
    }

    public int Id { get; set; }
    public string NameCar { get; set; }
    public string NameBrand { get;  set; }
    public string YearOfRelease { get; set; }
    public string TransmissionType { get; set; }
    public string ColorCar { get; set; }
    public string TypeOfDrive { get; set; }
    public decimal PriceCarDay { get; set; }
    public int CountOfSeats { get; set; }
    public string ImgCar { get; set; }
}