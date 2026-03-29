using Common;
using Microsoft.EntityFrameworkCore;

namespace MagicDbContext;

public class Seeder
{
    public IEnumerable<IGrouping<int, ISeed?>> Seeds {get; set;}
    private readonly MagicDbContext _ctx;

    public Seeder(string connString)
    {
        _ctx = PopulateDbContext(connString);
        PopulateISeedTypes();
    }

    public void Seed()
    {
        foreach(IGrouping<int, ISeed?> group in Seeds)
        {
            foreach(ISeed? seed in group)
                if(seed != null) seed.Seed();
            
            _ctx.SaveChanges();
        }
    }


    private void PopulateISeedTypes()
    {
        Seeds = ReflectionHelper.GetInstancesImplementingInterface<ISeed>(_ctx)
            .GroupBy(x => x.Priority())
            .OrderBy(x => x.Key);
    }

    private static MagicDbContext PopulateDbContext(string connString)
    {
        var dbOptions = new DbContextOptionsBuilder()
            .UseSqlServer(connString);
        return new MagicDbContext(dbOptions.Options);
    }
}
