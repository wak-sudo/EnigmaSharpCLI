# EnigmaSharpCLI

C# implementation of Enigma M3 (plug board supported) as a command-line tool.

## Details

Supports:
- Wheel order (Walzenlage) (three-rotor machine)
- Starting position of the rotors (Grundstellung) 
- Ring settings (Ringstellung)
- Plug connections (Steckerverbindungen)

Supported wiring tables:
```
Rotors:

I   EKMFLGDQVZNTOWYHXUSPAIBRCJ
II  AJDKSIRUXBLHWTMCQGZNPYFVOE
III BDFHJLCPRTXVZNYEIWGAKMUSQO
IV  ESOVPZJAYQUIRHXLNFTGKDCMWB
V   VZBRGITYUPSDNHLXAWMJQOFECK

Reflectors:

ETW ABCDEFGHIJKLMNOPQRSTUVWXYZ
B   YRUHQSLDPXNGOKMIEBFZCWVJAT
C   FVPJIAOYEDRZXWGCTKUQSBNMHL
```

Starting positions and ring settings are defined by an alphabet:
```
A B C D E F G H I J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z
| | | | | | | | | |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
```

## Help

```
Enigma M3 CLI (plug board supported):

-e -> Encrypt
EnigmaSharpCLI.exe -e [file path] [reflector B/C/ETW] 3x [rotor number I-V] 3x [rotor initial position] 3x [rotor ring setting] (optional plug board connections max. 13)

-h -> Display this help

Example:
EnigmaSharpCLI.exe -e "C:\crypto\text.txt" B I II III C B D F G D AZ BC
```
## How to build

Build using Visual Studio and .NET Core 3.1.

### Dependencies

* LibEnigmaSharp [GitHub](https://github.com/wak-sudo/LibEnigmaSharp)
