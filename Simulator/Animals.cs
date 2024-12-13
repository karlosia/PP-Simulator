namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    public string Description
    {
        get => description;
        init
        {
            var trimmed = value?.Trim();

            if (string.IsNullOrWhiteSpace(trimmed))
            {
                description = "Unknown";
            }
            else
            {
                if (trimmed.Length>15)
                {
                    trimmed = trimmed.Substring(0, 15);
                }
                trimmed = trimmed.TrimEnd();
                if (trimmed.Length<3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }
                description = trimmed;
            }
        }
    }
    public uint Size { get; set; } = 3;
    public string Info => $"{Description} <{Size}>";
}
