namespace Cipher
{
    public class Program
    {
        public static void Main()
        {
            string c = "";
            Console.WriteLine(c = CaesarsCipher.Encipher("Hello world KYS", 15)); // j g nn q
            Console.WriteLine(CaesarsCipher.Decipher(c, 15));

            Console.ReadLine();

            string v = "";
            Console.WriteLine(v = VinereCipher.Encipher("Hello World", "key"));
            Console.WriteLine(VinereCipher.Decipher(v, "key"));
        }
    }

    public class CaesarsCipher
    { 

        public static string Encipher(string input, int key)
        {
            string res = "";

            foreach (char ch in input)
                res += Cipher(ch, key);

            return res;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

            
        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch)) return ch;
            char offset = char.IsUpper(ch) ? 'A' : 'a';

            return  (char)((((ch + key) - offset ) % 26) + offset);
        }
    }


    public class VinereCipher
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
                res += Cipher(input[i],52 - (int)key[keyIndex]);
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