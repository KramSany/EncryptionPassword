using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    public static class Password
    {
        private static readonly Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
        {
            {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."}, {'f', "..-."},
            {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"}, {'k', "-.-"}, {'l', ".-.."},
            {'m', "--"}, {'n', "-."}, {'o', "---"}, {'p', ".--."}, {'q', "--.-"}, {'r', ".-."},
            {'s', "..."}, {'t', "-"}, {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"},
            {'y', "-.--"}, {'z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
            {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
            {'8', "---.."}, {'9', "----."}, {' ', "/"}
        };
        
        public static string EncodePasswordWithCaesarAndMorse(string password)
        {
            string outputCaesarPassword = ""; // trash
            int shift = 2; // count shift of  Caesar
            string outputMorsePassword = "";
            string encoderPassword = "";
            foreach (char c in password) // encoding in cipher of Caesar
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(((char.ToLower(c) - 'a') + shift) % 26 + 'a');
                    if (char.IsUpper(c))
                    {
                        shifted = char.ToUpper(shifted);
                    }
                    outputCaesarPassword += shifted;
                }
                else
                {
                    outputCaesarPassword += c;
                }
            }
            foreach (char ch in outputCaesarPassword) // encoding in alphabet Morse
            {
                if (morseAlphabet.ContainsKey(char.ToLower(ch)))
                {
                    outputMorsePassword += morseAlphabet[char.ToLower(ch)] + " ";
                }
            }
            foreach (char ch in outputMorsePassword) // encoding in of binary system
            {
                encoderPassword += Convert.ToString(ch, 2);
            }
            return encoderPassword;
        }
        // in further i will add uncoding method
    }
}
