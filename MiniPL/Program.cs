using System;
using System.Collections.Generic;

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
                IList<Token> tokens = scanner.GenerateTokens();
                Parser parser = new Parser(tokens);
                parser.Parse();
                Console.ReadKey();
                return 0;
            }
            catch (LexerException ex)
            {
                Console.WriteLine("LexicalError: " + ex.Message);
                Console.ReadKey();
                return -1;
            }
            catch (SyntaxException ex)
            {
                Console.WriteLine("SyntaxError: " + ex.Message);
                Console.ReadKey();
                return -1;
            }
        }
    }
}
