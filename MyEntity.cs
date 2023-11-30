namespace EfCoreCompareSample;

using System.ComponentModel.DataAnnotations;

public class MyEntity
{
    [Key]
    public string Name { get; set; }

    public byte[] Timestamp { get; set; }
}