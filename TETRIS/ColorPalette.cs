
public static class ColorPalette
{
    static ColorPalette()
    {
        colors.Add(ColorType.Red,"");
        colors.Add(ColorType.Pink,"");
        colors.Add(ColorType.Orange,"");
        colors.Add(ColorType.Yellow,"");
        colors.Add(ColorType.Green,"");
        colors.Add(ColorType.Blue,"");
        colors.Add(ColorType.Purple,"");
    }
    static Dictionary<ColorType,string> colors = new();
}

public enum ColorType
{
    Red,
    Pink,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple,
}