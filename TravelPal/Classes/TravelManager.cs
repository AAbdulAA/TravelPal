using System.Collections.Generic;

namespace TravelPal.Classes
{
    public class TravelManager
    {

        // ny lista av Travel som ska användas för att lägga till o ta bort 

        public List<Travel> travels = new();


        public void AddTravel(Travel travel)
        {
            travels.Add(travel);
        }

        // Ta bort resa!!
        public void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);

            if (travel is Vacation)
            {
                travels.Remove(travel as Vacation);
            }
            else if (travel is Trip)
            {
                travels.Remove(travel as Trip);
            }
        }
    }
}
