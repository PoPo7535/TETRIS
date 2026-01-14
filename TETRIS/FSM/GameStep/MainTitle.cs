namespace MyApp.FSM;

public class MainTitle : IGameStep
{
    public void Enter()
    {
        for (int row = 0; row < logo.Length; ++row)
        {
            for (int cal = 0; cal < logo[row].Length; ++cal)
            {
                ConsoleHelper.Write(logo[row][cal], logoColor[cal]);
            }
            ConsoleHelper.WriteLine("");
        }

        ConsoleHelper.Flush();
    }

    public void Exit()
    {
    }

    private ColorType[] logoColor =
    [
        ColorType.Red,
        ColorType.Orange,
        ColorType.Yellow,
        ColorType.Green,
        ColorType.Blue,
        ColorType.Purple
    ];

    private string[][] logo = new string[][]
    {
        [" ███████████ ", " ██████████ ", " ███████████ ", " ███████████   ", " █████ ", "  █████████  "],
        ["▒█▒▒▒███▒▒▒█ ", "▒▒███▒▒▒▒▒█ ", "▒█▒▒▒███▒▒▒█ ", "▒▒███▒▒▒▒▒███  ", "▒▒███  ", " ███▒▒▒▒▒███ "],
        ["▒   ▒███  ▒  ", " ▒███  █ ▒  ", "▒   ▒███  ▒  ", " ▒███    ▒███  ", " ▒███  ", "▒███    ▒▒▒  "],
        ["    ▒███     ", " ▒██████    ", "    ▒███     ", " ▒██████████   ", " ▒███  ", "▒▒█████████  "],
        ["    ▒███     ", " ▒███▒▒█    ", "    ▒███     ", " ▒███▒▒▒▒▒███  ", " ▒███  ", " ▒▒▒▒▒▒▒▒███ "],
        ["    ▒███     ", " ▒███ ▒   █ ", "    ▒███     ", " ▒███    ▒███  ", " ▒███  ", " ███    ▒███ "],
        ["    █████    ", " ██████████ ", "    █████    ", " █████   █████ ", " █████ ", "▒▒█████████  "],
        ["   ▒▒▒▒▒     ", "▒▒▒▒▒▒▒▒▒▒  ", "   ▒▒▒▒▒     ", "▒▒▒▒▒   ▒▒▒▒▒  ", "▒▒▒▒▒  ", " ▒▒▒▒▒▒▒▒▒   "]
    };
}