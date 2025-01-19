using System;
using System.Text;

namespace VigenereCiphers {
    class Program {
        public static string Encrypt(string text, string key) {
            StringBuilder newText = new StringBuilder("");
            string newKey = KeyFormat(text, key).ToLower();
            
            for (int i = 0, j = 0; i < text.Length; i++) {
                if (char.IsLetter(text[i])) {
                    
                    
                    if (text[i] <= 90) {
                        char newLetter =(char) (text[i] + (char.ToUpper(newKey[j]) - 65));
                        newText.Append((char) ((newLetter > 90) ? (newLetter - 26) : newLetter));
                    }

                    else if (text[i] > 90) {
                        char newLetter = (char) (text[i] + (char.ToLower(newKey[j]) - 97));
                        newText.Append((char) ((newLetter > 122) ? (newLetter - 26) : newLetter));
                    }
                    j++;
                }
                else {
                    newText.Append(text[i]);
                }
            }

            return newText.ToString();
        }

        public static string Decrypt(string text, string key) {
            StringBuilder newText = new StringBuilder("");
            string newKey = KeyFormat(text, key).ToLower();
            
            for (int i = 0, j = 0; i < text.Length; i++) {
                if (char.IsLetter(text[i])) {
                    if (text[i] <= 90) {
                        char newLetter = (char) (text[i] - (char.ToUpper(newKey[j]) - 65));
                        newText.Append((char) ((newLetter < 65) ? (newLetter + 26) : newLetter));
                    }

                    else if (text[i] > 90) {
                        char newLetter = (char) (text[i] - (char.ToLower(newKey[j]) - 97));
                        newText.Append((char) ((newLetter < 97) ? (newLetter + 26) : newLetter));
                    }
                    j++;
                }
                else {
                    newText.Append(text[i]);
                }
            }

            return newText.ToString();
        }

        public static string KeyFormat(string text, string key) {
            StringBuilder newKey = new StringBuilder("");
            StringBuilder newText = new StringBuilder(text);

            if (key.Length < text.Length) {
                int j = 0;
                for (int i = 0; i < key.Length; i++) {
                    newKey.Append(key[i]);
                }

                for (int i = key.Length; i < text.Length; i++) {
                    newKey.Append(newKey[j]);
                    j++;
                }

            }
            else if (key.Length >= text.Length) {
                for (int i = 0; i < text.Length; i++) {
                    newKey.Append(key[i]);
                }
            }

            return newKey.ToString();
        }
    }
}