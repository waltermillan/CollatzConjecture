namespace Core.Entities;

public class CollatzConjecture : BaseEntity
{
    public int StartingNumber { get; set; }
    public List<int> Sequence { get; set; }
    public int NumSteps { get; set; }
    public DateTime Timestamp { get; set; }
}
