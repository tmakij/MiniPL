using System;
using MiniPL.AST;

namespace MiniPL
{
    public static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                SourceStream source = new SourceStream(@"D:\Timo\MiniPL Samples\b.txt");
                Scanner scanner = new Scanner(source);
                TokenStream tokens = scanner.GenerateTokens();
                Parser parser = new Parser(tokens);
                AbstractSyntaxTree tree = parser.Parse();
                tree.CheckIdentifiers();
                tree.CheckTypes();
                Console.WriteLine("Valid program!\nExecuting...");
                tree.Execute();
                Console.ReadKey(false);
                return 0;
            }
            catch (LexerException ex)
            {
                return Error("LexicalError: " + ex.Message);
            }
            catch (SyntaxException ex)
            {
                return Error("SyntaxError: " + ex.Message);
            }
            catch (UninitializedVariableException ex)
            {
                return Error("Uninitialized variable " + ex.Identifier);
            }
            catch (TypeMismatchException ex)
            {
                return Error("Type mismatch: Expected " + ex.Expected + " but " + ex.Found + " was found");
            }
            catch (VariableNameDefinedException ex)
            {
                return Error("Variable \"" + ex.Identifier + "\" is defined more than once");
            }
            catch (Exception ex)
            {
                return Error("Internal compiler error ¯\\_(ツ)_/¯:\n" + ex.Message);
            }
        }

        private static int Error(string Message)
        {
            Console.Error.WriteLine(Message);
            Console.ReadKey(false);
            return -1;
        }
    }
}
