namespace CleanCodeAssignments.Config;

public class ProcessingConfig
{
    public bool Validate { get; set; } = true;
    public bool Transform { get; set; } = true;
    public string DateFormat { get; set; } = "yyyy-MM-dd";
}