namespace Event.Domain.Models.EventAggregate
{
    public class Location : ValueObject
    {
        public string Name { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public Location() { }

        public Location(string name, string city, string country, string zipcode, decimal latitude, decimal longitude)
        {
            Name = name;
            City = city;
            Country = country;
            ZipCode = zipcode;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Name;
            yield return City;
            yield return Country;
            yield return ZipCode;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
