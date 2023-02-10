using PetMatch.Application.Common.Interfaces.Services;

namespace PetMatch.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}