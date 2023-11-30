using EfCoreCompareSample;

Console.WriteLine("Hello, World!");

// Create and add two entities
using (DatabaseContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    byte[] timestamp = new byte[] { 1, 2, 3, 4, 5 };
    MyEntity entity = new()
    {
        Name = "Test",
        Timestamp = timestamp
    };
    MyEntity entity2 = new()
    {
        Name = "Test2",
        Timestamp = timestamp
    };
    context.MyEntities.Add(entity);
    context.MyEntities.Add(entity2);

    context.SaveChanges();
}

try
{
    using (DatabaseContext context = new())
    {
        // get the first timestamp
        byte[] myTimestamp = context.MyEntities.First().Timestamp;

        // load all entities with the same timestamp (both of them)
        MyEntity[] entities = context.MyEntities.Where(e => MyMethods.Compare(e.Timestamp, myTimestamp) == 0).ToArray();

        Console.WriteLine($"Found {entities.Length} entities with the same timestamp");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Exception thrown: {0}", ex.Message);
    return;
}