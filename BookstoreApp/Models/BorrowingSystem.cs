using BookstoreApp.Services;

namespace BookstoreApp.Models
{
    public class BorrowingSystem
    {
        private readonly ILogger<BorrowingSystem> logger;
        private readonly ITimeService timeService;

        public BorrowingSystem(ILogger<BorrowingSystem> logger, ITimeService timeService)
        {
            this.logger = logger;
            this.timeService = timeService;
        }

        public void Borrow(Book book)
        {
            Borrow borrow = new(book, timeService.GetUtcTime());

            logger.LogInformation("{b} by {t}", borrow, timeService.GetType().Name);
        }
    }
}
