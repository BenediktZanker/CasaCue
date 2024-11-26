using CasaCue.Models;
using System.Collections.Generic;
using System.Linq;

namespace CasaCue.Services
{
    public class WaitlistService
    {
        private readonly List<Guest> _waitlist = new List<Guest>();

        public void AddGuest(Guid id, string name, int groupSize)
        {
            _waitlist.Add(new Guest { Id = id, Name = name, GroupSize = groupSize });
            UpdatePositions();
        }

        public List<Guest> GetWaitlist()
        {
            UpdatePositions();
            return _waitlist;
        }

        public Guest GetGuestById(Guid id)
        {
            return _waitlist.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Guest> GetGuestsByName(string name)
        {
            return _waitlist.Where(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Guest GetGuestByPosition(int position)
        {
            return _waitlist.FirstOrDefault(g => g.QueuePosition == position);
        }

        public void RemoveGuest(Guid id)
        {
            var guest = _waitlist.FirstOrDefault(g => g.Id == id);
            if (guest != null)
            {
                _waitlist.Remove(guest);
                UpdatePositions();
            }
        }

        private void UpdatePositions()
        {
            for (int i = 0; i < _waitlist.Count; i++)
            {
                _waitlist[i].QueuePosition = i + 1;
            }
        }
        
        public void ClearWaitlist()
        {
            _waitlist.Clear();
        }

    }
}


