using TravelPal.Enums;

namespace TravelPal.Classes
{
    public class Trip : Travel
    {
        public TripTypes TripType;

        // lägg parametrarna.
        public Trip(TripTypes tripType, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            TripType = tripType;
        }

        public string GetInfo()
        {
            return "din info";
        }
    }
}
