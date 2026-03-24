namespace MagicDbContext;

public interface ISeed
{
    public int Priority();
    public Task Seed();
}
