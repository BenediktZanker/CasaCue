using CasaCue.Data;
using CasaCue.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaCue.Services
{
    public class WaitlistService
    {
        private readonly ApplicationDbContext _context;

        public WaitlistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddGuest(Guid id, string name, int groupSize)
        {
            var guest = new Guest { Id = id, Name = name, GroupSize = groupSize };
            _context.Guests.Add(guest);
            UpdatePositions();
            _context.SaveChanges(); // Speichert die Daten in der Datenbank
        }

        public List<Guest> GetWaitlist()
        {
            UpdatePositions();
            return _context.Guests.OrderBy(g => g.QueuePosition).ToList(); // Holt die Daten aus der Datenbank
        }

        public Guest GetGuestById(Guid id)
        {
            return _context.Guests.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Guest> GetGuestsByName(string name)
        {
            return _context.Guests.Where(g => g.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Guest GetGuestByPosition(int position)
        {
            return _context.Guests.FirstOrDefault(g => g.QueuePosition == position);
        }

        public void RemoveGuest(Guid id)
        {
            var guest = _context.Guests.FirstOrDefault(g => g.Id == id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                UpdatePositions();
                 _context.SaveChanges(); // Speichert die Änderungen in der Datenbank
            }
        }

        public void UpdatePositions()
        {
            var guests = _context.Guests.OrderBy(g => g.QueuePosition).ToList();
            for (int i = 0; i < guests.Count; i++)
            {
                guests[i].QueuePosition = i + 1;
            }
            _context.SaveChanges(); // Speichert die aktualisierten Positionen
        }


        
        public void ClearWaitlist()
        {
            _context.Guests.RemoveRange(_context.Guests);
            _context.SaveChanges(); // Löscht alle Daten in der Datenbank
        }
    }
}
