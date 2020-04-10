using System;

namespace DeveloperNews.UI.Services
{
    using DeveloperNews.UI.Interfaces;

    public class DateTimeService : IDateTimeService
    {
        public DateTime Today
            => DateTime.Today.Date;
    }
}