namespace Cipher
{
    //65 - 90 cap; 97-122 lower
    public class Program
    {
        public static void Main()
        {
            string c = "";
            Console.Write("Ciphered: ");

            Console.WriteLine(c = CaesarsCipher.Encipher("caesar test", 80)); 
            Console.WriteLine("Deciphered: " + CaesarsCipher.Decipher(c, 80));

            Console.ReadLine();

            string v = "";
            Console.WriteLine(v = VignereCipher.Encipher("vignere test", "key"));
            Console.WriteLine(VignereCipher.Decipher(v, "key"));
        }
    }

    public class CaesarsCipher
    {
        public static string Encipher(string input, int key)
        {
            string res = "";
            input = input.ToLower();

            foreach (char ch in input)
                res += Cipher(ch, key);

            return res;
        }

        public static string Decipher(string input, int key)
        {
            string res = "";
            input = input.ToLower();

            foreach (char ch in input)
                res += Cipher(ch, key, true);

            return res;
        }


        private static char Cipher(char ch, int key, bool reverse = false)
        {
            if (!char.IsLetter(ch)) return ch;


            key = key % 26;
            if (!reverse) return (char)(((ch + key - 97) % 26) + 97);
            else return (char)(((ch + 26 - key - 97) % 26) + 97 );

        }

    }

    public class VignereCipher
    {
        public static string Encipher(string input, string key)
        {
            string res = "";
            int keyIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                res += Cipher(input[i], (int)key[keyIndex]);
                keyIndex = keyIndex == key.Length - 1 ? 0 : keyIndex + 1;
            }

            return res;
        }


        public static string Decipher(string input, string key)
        {
            string res = "";
            int keyIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                res += Cipher(input[i], (int)key[keyIndex], true);
                keyIndex = keyIndex == key.Length - 1 ? 0 : keyIndex + 1;
            }

            return res;
        }

        private static char Cipher(char ch, int key, bool reverse = false)
        {
            if (!char.IsLetter(ch)) return ch;


            key = key % 26;
            if (!reverse) return (char)(((ch + key - 97) % 26) + 97);
            else return (char)(((ch + 26 - key - 97) % 26) + 97);

        }
    }
}