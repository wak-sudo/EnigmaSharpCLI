using System;

namespace EnigmaSharpCLI
{
    class HelpFunctions
    {
        static public void DisplayHelp()
        {
            Console.WriteLine("Enigma M3 CLI (plug board supported):\n");
            Console.WriteLine("-e -> Encrypt");
            Console.WriteLine("EnigmaSharpCLI.exe -e [file path] [reflector B/C/ETW] 3x [rotor number I-V] 3x [rotor initial position]"
            + " 3x [rotor ring setting] (optional plug board connections max. 13)\n");
            Console.WriteLine("-h -> Display this help\n");
            Console.WriteLine("Example:");
            Console.WriteLine("EnigmaSharpCLI.exe -e \"C:\\crypto\\text.txt\" B I II III C B D F G D AZ BC");
        }
    }
}
