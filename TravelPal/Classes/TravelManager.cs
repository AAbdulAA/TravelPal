using System.Collections.Generic;

namespace TravelPal.Classes
{
    public class TravelManager
    {

        // ny lista av Travel som ska användas för att lägga till o ta bort 

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
