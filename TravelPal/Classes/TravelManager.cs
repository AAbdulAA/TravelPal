using System.Collections.Generic;

namespace TravelPal.Classes
{
    public class TravelManager
    {
        List<Travel> travels = new();

        public void AddTravel(Travel travel)
        {
            travels.Add(travel);
        }
        public void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
    }
}
