namespace NumberToWord.Api.Domains.Entities;

public class NumericalOrder
{
    public int Sequence { get; set; }

    public int TotalDigit { get; set; }

    public string Word { get; set; } = string.Empty;
}
