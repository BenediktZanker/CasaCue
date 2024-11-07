namespace CasaCue.Data.Enums
{
    /// <summary>
    /// Statuses of 
    /// </summary>
    public enum GuestStatus
    {
        /// <summary>
        /// Waiting in queue
        /// </summary>
        Waiting = 1,

        /// <summary>
        /// Has been provided the seat
        /// </summary>
        Attended = 2,

        /// <summary>
        /// Left the venue without assigning a seat
        /// </summary>
        LeftTheVenue = 3,
    }
}
