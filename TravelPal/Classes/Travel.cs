using TravelPal.Enum;

namespace TravelPal.Classes
{
    public class Travel
    {


        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int Travellers { get; set; }

        // lägg parametrarna.
        public Travel(string destination, Countries country, int travellers)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
        }
        public virtual string GetInfo()
        {
            return null;
        }
    }
}
