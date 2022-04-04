using System;

namespace EnigmaSharpCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "-e":
                        {
                            Encrypter Enigma = new Encrypter(args);
                            Enigma.Encrypt();
                        }
                        break;

                    case "-h":
                        HelpFunctions.DisplayHelp();
                        break;

                    default:
                        HelpFunctions.DisplayHelp();
                        break;
                }
            }
            else
                HelpFunctions.DisplayHelp();
        }
    }
}
