
public class Triple
{
    public int AllCounts
    {
        get { return (NegCounts + PosCounts + DontCareCounts); }
    }
    public int NegCounts { get; set; }
    public int PosCounts { get; set; }
    public int DontCareCounts { get; set; }
}