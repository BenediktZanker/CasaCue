// Waitlist.cs
using System.Collections.Generic;

namespace CasaCue.Services
{
    public class Waitlist
    {
        private List<string> guests;

        public Waitlist()
        {
            guests = new List<string>();
        }

        // Methode, um einen Gast hinzuzufügen
        public void AddGuest(string guestName)
        {
            guests.Add(guestName);
        }

        // Methode, um die Anzahl der Gäste in der Warteliste zurückzugeben
        public int GetWaitlistCount()
        {
            return guests.Count;
        }
    }
}

