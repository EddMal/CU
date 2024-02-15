using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU.Logic.InputKeys
{
    enum Action
    {
        ChangeColor = ConsoleKey.Tab,
        MoveCursor = ConsoleKey.M,
        Paint = ConsoleKey.Spacebar,
        SaveFile = ConsoleKey.S,
        LoadFile = ConsoleKey.L,
        ExitProgram = ConsoleKey.Escape
    }
}
