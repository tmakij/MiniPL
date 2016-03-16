using System;

namespace MiniPL
{
    public static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                SourceStream source = new SourceStream(@"D:\Timo\MiniPL Samples\a.txt");
                Scanner scanner = new Scanner(source);
                scanner.GenerateTokens();
                foreach (Token token in scanner.Tokens)
                {
                    Console.WriteLine(token);
                }
                Console.ReadKey();
                return 0;
            }
            catch (LexerException ex)
            {
                Console.WriteLine("LexerException: " + ex.Message);
                Console.ReadKey();
                return -1;
            }
        }
    }
}
