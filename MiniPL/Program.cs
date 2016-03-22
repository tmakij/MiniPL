using System;
using System.Collections.Generic;
using MiniPL.AST;

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
                AbstractSyntaxTree tree = parser.Parse();
                tree.CheckIdentifiers();
                tree.CheckTypes();
                Console.WriteLine("Valid program!");
                Console.ReadKey(false);
                return 0;
            }
            catch (LexerException ex)
            {
                Console.WriteLine("LexicalError: " + ex.Message);
                Console.ReadKey(false);
                return -1;
            }
            catch (SyntaxException ex)
            {
                Console.WriteLine("SyntaxError: " + ex.Message);
                Console.ReadKey(false);
                return -1;
            }
            catch (UninitializedVariableException ex)
            {
                Console.WriteLine("Uninitialized variable " + ex.Identifier);
                Console.ReadKey(false);
                return -1;
            }
            catch (TypeMismatchException ex)
            {
                Console.WriteLine("Type mismatch: Expected " + ex.Expected + " but " + ex.Found + " was found");
                Console.ReadKey(false);
                return -1;
            }
            catch (VariableNameDefinedException ex)
            {
                Console.WriteLine("Variable \"" + ex.Identifier + "\" is defined twice in the program");
                Console.ReadKey(false);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Internal compiler error ¯\\_(ツ)_/¯:\n" + ex.Message);
                Console.ReadKey(false);
                return -1;
            }
        }
    }
}
