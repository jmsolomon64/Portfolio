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

    public void Seed()
    {
        Console.WriteLine("Seeding Numbers...");
        SeedNumbersForMajorArcana();
    }

    private void SeedNumbersForMajorArcana()
    {
        for(int i = 0; i < NumberOfMajorArcana; i++)
            SeedNumber(i);
    }


    private void SeedNumber(int number, string? description = null)
    {
        Number? temp = _ctx.Numbers.FirstOrDefault(x => x.Value  == number);
        bool isNew = temp == null;

        if(isNew)
            temp = new Number() { Value = number };

        temp.Description = description ?? string.Empty;
        
        if(isNew) _ctx.Add(temp);
        else _ctx.Update(temp);
    }
}
