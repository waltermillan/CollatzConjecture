namespace Core.Entities;

public class CollatzConjecture : BaseEntity
{
    public long StartingNumber { get; set; }
    public List<long> Sequence { get; set; }
    public int NumSteps { get; set; }
    public DateTime Timestamp { get; set; }
}
