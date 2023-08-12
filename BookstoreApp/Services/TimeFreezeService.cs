namespace BookstoreApp.Services
{
    public class TimeFreezeService : ITimeService
    {
        private readonly DateTime time;

        public TimeFreezeService(DateTime utcTime)
        {
            time = utcTime.Kind == DateTimeKind.Utc ? utcTime
                : throw new ArgumentException("DateTimeKind must be UTC!", nameof(utcTime));
        }

        public TimeFreezeService(ITimeService timeService) => time = timeService.GetUtcTime();

        public DateTime GetUtcTime() => time;
    }
}
