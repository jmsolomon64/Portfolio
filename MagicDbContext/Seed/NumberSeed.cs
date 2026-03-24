namespace MagicDbContext;

internal class NumberSeed : ISeed
{
    private readonly MagicDbContext _ctx;
    private static int NumberOfMajorArcana = 22;

    public NumberSeed(MagicDbContext ctx)
    {
        _ctx = ctx;
    }

    public int Priority() => 1;

    public Task Seed()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Seeding Numbers...");
            SeedNumbersForMajorArcana();
        });
    }

    private void SeedNumbersForMajorArcana()
    {
        for(int i = 0; i < NumberOfMajorArcana; i++)
            SeedNumber(i);
    }


    private void SeedNumber(int number, string? description = null)
    {
        Number? temp = _ctx.Numbers.FirstOrDefault(x => x.NumberId == number);

        if(temp == null)
            temp = new Number() { NumberId = number };

        if(!string.IsNullOrEmpty(description))
            temp.Description = description;
        
        _ctx.Update(temp);
    }
}
