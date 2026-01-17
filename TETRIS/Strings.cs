namespace MyApp;

public static class Strings
{
    static Strings()
    {
        BlockInfo = new Dictionary<BlockType, BlockInfo>
        {
            { BlockType.I, new BlockInfo(BlockType.I, TetrisColor.Blue, BlockI) },
            { BlockType.O, new BlockInfo(BlockType.O, TetrisColor.Yellow, BlockO) },
            { BlockType.Z, new BlockInfo(BlockType.Z, TetrisColor.Red, BlockZ) },
            { BlockType.S, new BlockInfo(BlockType.S, TetrisColor.Green, BlockS) },
            { BlockType.J, new BlockInfo(BlockType.J, TetrisColor.Blue, BlockJ) },
            { BlockType.L, new BlockInfo(BlockType.L, TetrisColor.Orange, BlockL) },
            { BlockType.T, new BlockInfo(BlockType.T, TetrisColor.Purple, BlockT) },
        };
    }

    public static Dictionary<BlockType, BlockInfo> BlockInfo;

    public static readonly string[] Map =
    [
        "█-Hold-████████████-Next-█",
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

    private static readonly string[][] BlockI = new string[][]
    {
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