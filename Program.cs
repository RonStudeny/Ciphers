namespace Cipher
{
    //65 - 90 cap; 97-122 lower
    public class Program
    {
        public static void Main()
        {
            string c = "";
            Console.Write("Ciphered: ");
            Console.WriteLine(c = CaesarsCipher.Encipher("Hello world KYS", 15)); // j g nn q
            Console.WriteLine("Deciphered: " + CaesarsCipher.Decipher(c, 15));

            Console.ReadLine();

            //string v = "";
            //Console.WriteLine(v = VignereCipher.Encipher("Hello World", "key"));
            //Console.WriteLine(VignereCipher.Decipher(v, "key"));
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


        private static char Cipher(char ch, int key, bool decipher = false)
        {
            if (!char.IsLetter(ch)) return ch;

            if (!decipher)
            {
                if (ch + key > 122) return (char)((ch + key) - 26);
                else return (char)(ch + key);
            }
            else
            {
                if (ch - key < 97) return (char)((ch - key) + 26);
                else return (char)(ch - key);
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
                    res += Cipher(input[i], 52 - (int)key[keyIndex]);
                    keyIndex = keyIndex == key.Length - 1 ? 0 : keyIndex + 1;
                }

                return res;
            }

            private static char Cipher(char ch, int key)
            {
                if (!char.IsLetter(ch)) return ch;
                char offset = char.IsUpper(ch) ? 'A' : 'a';

                return (char)((((ch + key) - offset) % 26) + offset);
            }
        }

    }
}