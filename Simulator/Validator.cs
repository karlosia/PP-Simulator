namespace Simulator;
public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        return Math.Clamp(value, min, max);
    }
    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value == null) value = string.Empty;

        string trimmed = value.Trim();

        if (trimmed.Length < min)
        {

            return trimmed.PadRight(min, placeholder);
        }
        else if (trimmed.Length > max)
        {

            return trimmed.Substring(0, max);
        }

        return trimmed;
    }

}

