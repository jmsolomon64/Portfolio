using Common;

namespace MagicDbContext;

public class Seeder
{
    public IEnumerable<IGrouping<int, ISeed?>> Seeds {get; set;}
    private readonly MagicDbContext _ctx;
    private static Type ISeedType = typeof(ISeed);

    public Seeder(MagicDbContext ctx)
    {
        _ctx = ctx;
        PopulateISeedTypes();
    }

    public async Task Seed()
    {
        foreach(IGrouping<int, ISeed?> seed in Seeds)
        {
            List<Task> tasksToDo = seed.Where(x => x != null)
                .Select(x => x.Seed()).ToList();
            await Task.WhenAll(tasksToDo);
            _ctx.SaveChanges();
        }
    }

    private void PopulateISeedTypes()
    {
        Seeds = ReflectionHelper.GetInstancesImplementingInterface<ISeed>(ISeedType, _ctx)
            .GroupBy(x => x.Priority());
    }
}
