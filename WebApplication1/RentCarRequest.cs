namespace WebApplication1
{
    public class RentCarRequest
    {
        public int CarId { get; set; }
        public string StartDateRent { get; set; }
        public string EndDateRent { get; set; }
    }
    public class RentCarResponse
    {
        public int NumberOfDays { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
   
