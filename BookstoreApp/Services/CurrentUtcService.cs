namespace BookstoreApp.Services
{
    public class CurrentUtcService : ITimeService
    {
        public DateTime GetUtcTime() => DateTime.UtcNow;
    }
}
