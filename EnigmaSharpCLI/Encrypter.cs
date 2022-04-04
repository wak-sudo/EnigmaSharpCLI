using System;
using System.IO;
using System.Diagnostics;
using LibEnigmaSharp;

namespace EnigmaSharpCLI
{
    /// <summary>
    /// The logic behind the "-e" command
    /// </summary>
    class Encrypter
    {
        const string errorMessage = "Pass valid arguments.";

        readonly string[] args;

        /// <summary>
        /// Takes main class arguments.
        /// </summary>
        /// <param name="args">Main class arguments</param>
        public Encrypter(string[] args)
        {
            this.args = args;
        }

        /// <summary>
        /// Main logic, encrpyt text and ask user for actions.
        /// </summary>
        public void Encrypt()
        {
            if (args.Length >= 12 && args.Length <= 25)
            {
                UserSettings Settings = BuildUserSettings();
                if (Settings.CanBeConverted() && File.Exists(args[1]))
                {
                    Encoder Enigma = new Encoder(Settings);
                    Stopwatch stopwatch = new Stopwatch();

                    Console.WriteLine("Creating encrypted message...");

                    stopwatch.Start();

                    string encryptedText = Enigma.EncryptText(File.ReadAllText(args[1]));

                    stopwatch.Stop();

                    char[] rotorsPosition = Enigma.ReturnRotorsPosition();

                    Console.WriteLine("Final rotors position: {0}{1}{2} ({3} {4} {5})",
                    rotorsPosition[0], rotorsPosition[1], rotorsPosition[2],
                    (int)rotorsPosition[0] - 'A', (int)(rotorsPosition[1] - 'A'), (int)(rotorsPosition[2] - 'A'));

                    Console.WriteLine("Encrypted in: " + stopwatch.ElapsedMilliseconds + " (ms)");
                    Console.WriteLine("Do you want to see the encrypted text in the command line? [Y/n]: ");
                    string input = Console.ReadLine();
                    if (input == "Y")
                    {
                        Console.WriteLine("Encrypted text: ");
                        Console.WriteLine(encryptedText);
                    }

                    Console.WriteLine("Do you want to save the encrypted text as a file in the original directory? [Y/n]: ");
                    input = Console.ReadLine();
                    if (input == "Y")
                        FileHandler.CreateEncryptedFile(args[1], encryptedText);

                    Console.WriteLine("Encryption executed successfully.");
                }
                else Console.WriteLine(errorMessage);
            }
            else Console.WriteLine(errorMessage);
        }

        /// <summary>
        /// Builds UserSettings object
        /// </summary>
        /// <returns>UserSettings object</returns>
        private UserSettings BuildUserSettings()
        {
            int numberOfConnections = args.Length - 12;
            string[] plugboardConnections = new string[numberOfConnections];
            for (int i = 0; i < numberOfConnections; i++)
                plugboardConnections[i] = args[i + 12];

            UserRotor[] Rotors =
            {
                new UserRotor(args[3],args[6],args[9]),
                new UserRotor(args[4],args[7],args[10]),
                new UserRotor(args[5],args[8],args[11])
            };

            return new UserSettings(args[2], Rotors, plugboardConnections);
        }
    }
}
