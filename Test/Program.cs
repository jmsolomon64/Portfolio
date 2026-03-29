using Common;
using MagicDbContext;

using(MagicDbContext.MagicDbContext context = new MagicDbContext.MagicDbContext())
{
    IEnumerable<IGrouping<int, ISeed?>> seeds  = Common.ReflectionHelper.GetInstancesImplementingInterface<ISeed>(context)
        .GroupBy(x => x.Priority())
        .OrderBy(x => x.Key);

    foreach(IGrouping<int, ISeed?> group in seeds)
    {
        foreach(ISeed? seed in group)
        {
            Console.WriteLine($"{seed?.GetType().Name} has priority: {group.Key}");
        }
    }
}


Console.ReadLine();