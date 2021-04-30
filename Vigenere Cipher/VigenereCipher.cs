using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vigenere_Cipher
{
    public static class VigenereCipher
    {
        private static string russianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public static string Encrypt(string text, string key)
        {            
            char[] chars = text.ToCharArray();
            key = key.ToUpper();
            int keyInd = 0;
            
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), "[А-Яа-яЁё]"))
                {
                    if (keyInd == key.Length)
                    {
                        keyInd = 0;
                    }

                    int shift = russianAlphabet.IndexOf(key[keyInd]);
                    int letter = russianAlphabet.IndexOf(Char.ToUpper(chars[i]));
                    int index = letter + shift;

                    if (index > 32)
                    {
                        index -= 33; 
                    }

                    if (Char.IsUpper(chars[i]))
                    {
                        chars[i] = russianAlphabet[index];
                    }
                    else
                    {
                        chars[i] = Char.ToLower(russianAlphabet[index]);
                    }

                    keyInd++;
                }
            }
            return new string(chars);
        }
        public static string Decrypt(string text, string key)
        {            
            char[] chars = text.ToCharArray();
            key = key.ToUpper();
            int keyInd = 0;
            
            for (int i = 0; i < chars.Length; i++)
            {
                if (Regex.IsMatch(chars[i].ToString(), "[А-Яа-яЁё]"))
                {
                    if (keyInd == key.Length)
                    {
                        keyInd = 0;
                    }

                    int shift = russianAlphabet.IndexOf(key[keyInd]);
                    int letter = russianAlphabet.IndexOf(Char.ToUpper(chars[i]));
                    int index = letter - shift;

                    if (index < 0)
                    {
                        index = 33 + index;
                    }

                    if (Char.IsUpper(chars[i]))
                    {
                        chars[i] = russianAlphabet[index];
                    }
                    else
                    {
                        chars[i] = Char.ToLower(russianAlphabet[index]);
                    }

                    keyInd++;
                }
            }
            return new string(chars);
        }
    }
}
