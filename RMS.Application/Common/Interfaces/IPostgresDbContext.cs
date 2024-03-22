namespace RMS.Application.Common.Interfaces;

public interface IPostgresDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}