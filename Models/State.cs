namespace Holism.Ticketing.Models
{
    public enum State
    {
        Unknwon = 0,
        New = 1,
        WaitingForBusinessResponse = 2,
        WaitingForUserResponse = 3,
        UnderInvestigation = 4,
        Closed = 5,
    }
}
