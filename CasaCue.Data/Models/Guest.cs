using CasaCue.Data.Enums;

namespace CasaCue.Data.Models
{
    public class Guest : BaseModel<Guid>
    {
        public required string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public GuestStatus Status { get; set; }
    }
}
