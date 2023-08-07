using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1
{
    internal class Encrypter
    {
        private char[] alfabet;
        private char[] offsetAlfabet;
        private int alfabetOffset;
        public Encrypter(int alfabetOffset)
        {
            this.alfabetOffset = alfabetOffset;
            List<char> tempAlfabet = new List<char>();
            //alfabet = new char[26];
            int indexer = 0;
            for (char c = 'A'; c <= 'z'; c++)
            {
                //alfabet[indexer++] = (char)c;
                tempAlfabet.Add((char)c);
            }
            alfabet = tempAlfabet.ToArray();
            offsetAlfabet = new char[alfabet.Length];
            for (int i = 0; i < alfabet.Length; i++)
            {
                int offset = i + alfabetOffset;
                if (i + alfabetOffset >= alfabet.Length)
                {
                    offset = i + alfabetOffset - alfabet.Length;
                }
                offsetAlfabet[i] = alfabet[offset];
            }
        }

        public string Encrypt(string stringToEncrypt)
        {
            char[] charsToEncrypt = stringToEncrypt.ToCharArray();
            char[] encryptedChars = new char[charsToEncrypt.Length];
            for (int i = 0; i < charsToEncrypt.Length; i++)
            {
                int alfabetIndex = Array.IndexOf(alfabet, charsToEncrypt[i]);
                if (alfabetIndex > -1)
                {
                    encryptedChars[i] = offsetAlfabet[alfabetIndex];
                }
                else
                {
                    encryptedChars[i] = charsToEncrypt[i];
                } 

            }
            return string.Join(string.Empty, encryptedChars);
        }

        public string Decrypt(string stringToDecrypt) {
            char[] charsToDecrypt = stringToDecrypt.ToCharArray();
            char[] decryptedChars = new char[charsToDecrypt.Length];
            for (int i = 0; i < charsToDecrypt.Length; i++)
            {
                int alfabetIndex = Array.IndexOf(alfabet, charsToDecrypt[i]);
                if (alfabetIndex > -1)
                {
                    int offsetAlfabetIndex = alfabetIndex - alfabetOffset;
                    if (offsetAlfabetIndex < 0)
                    {
                        int test = Math.Abs(offsetAlfabetIndex);
                        offsetAlfabetIndex = offsetAlfabet.Length - Math.Abs(offsetAlfabetIndex);
                    }
                    decryptedChars[i] = alfabet[offsetAlfabetIndex];
                }
                else
                {
                    decryptedChars[i] = charsToDecrypt[i];
                }

            }
            return string.Join(string.Empty, decryptedChars);
        }
    }
}
