namespace MyApp;

public static class Strings
{
    static Strings()
    {
        Block = new Dictionary<BlockType, BlockInfo>
        {
            { BlockType.I, new BlockInfo(BlockType.T, TetrisColor.None) }
        };
    }

    public static Dictionary<BlockType, BlockInfo> Block;

    public static readonly string[] Map =
    [
        "█-Save-████████████-Next-█",
        "█      █          █      █",
        "█      █          █      █",
        "█      █          █      █",
        "█      █          █      █  Level : 0",
        "████████          ████████  Score : 0",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          █      █",
        "       █          ████████",
        "       █          █",
        "       █          █",
        "       █          █",
        "       ████████████",
    ];

    public static readonly string[][] Logo = new string[][]
    {
        ["████████╗", "███████╗", "████████╗", "██████╗ ", "██╗", " ██████╗"],
        ["╚══██╔══╝", "██╔════╝", "╚══██╔══╝", "██╔══██╗", "██║", "██╔════╝"],
        ["   ██║   ", "█████╗  ", "   ██║   ", "██████╔╝", "██║", "╚█████╗ "],
        ["   ██║   ", "██╔══╝  ", "   ██║   ", "██╔══██╗", "██║", " ╚═══██╗"],
        ["   ██║   ", "███████╗", "   ██║   ", "██║  ██║", "██║", "██████╔╝"],
        ["   ╚═╝   ", "╚══════╝", "   ╚═╝   ", "╚═╝  ╚═╝", "╚═╝", "╚═════╝ "],
    };

    private static readonly string[][] BlockI = new string[][] {
        
        [
            "    ",
            "▣▣▣▣", 
            "    ", 
        ],
        [
            " ▣", 
            " ▣",
            " ▣",
            " ▣",
        ],
    };

    private static readonly string[][] BlockO = new string[][]
    {
        [
            "▣▣",
            "▣▣",
        ],
    };
    private static readonly string[][] BlockZ = new string[][]
    {
        [
            "▣▣ ",
            " ▣▣",
        ],
        [
            " ▣",
            "▣▣",
            "▣",
        ],
    };
    private static readonly string[][] BlockS = new string[][]
    {
        [
            " ▣▣",
            "▣▣",
        ],
        [
            "▣",
            "▣▣",
            " ▣",
        ],
    };
    private static readonly string[][] BlockJ = new string[][]
    {
        [
            "▣  ",
            "▣▣▣",
        ],
        [
            " ▣▣",
            " ▣",
            " ▣",
        ],
        [
            "▣▣▣",
            "  ▣",
        ],
        [
            " ▣",
            " ▣",
            "▣▣",
        ],
    };
    private static readonly string[][] BlockL = new string[][]
    {
        [
            "  ▣",
            "▣▣▣",
        ],
        [
            "▣",
            "▣",
            "▣▣",
        ],
        [
            "▣▣▣",
            "▣",
        ],
        [
            "▣▣",
            " ▣",
            " ▣",
        ],
    };
    private static readonly string[][] BlockT = new string[][]
    {
        [
            " ▣",
            " ▣▣",
            " ▣",
        ],
        [
            "   ",
            "▣▣▣",
            " ▣",
        ],
        [
            " ▣",
            "▣▣",
            " ▣",
        ],
        [
            " ▣ ",
            "▣▣▣",
        ],
    };
}