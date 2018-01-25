namespace ContactManager.Domain.SeedOfWork
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}