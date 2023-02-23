namespace FoodDelivery.Dtos.Address
{
    public class AddressReadDto
    {
        public int UnitNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
    }
}
