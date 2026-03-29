namespace MagicDbContext;

public interface ISeed
{
    public int Priority();
    public void Seed();
}
