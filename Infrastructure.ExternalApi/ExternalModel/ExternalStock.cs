using System;

namespace Infrastructure.ExternalApi.ExternalModel;

public class ExternalStock
{
    public string symbol { get; set; } = null!;
    public double price { get; set; }
    public double change { get; set; }
    public int volume { get; set; }
}
