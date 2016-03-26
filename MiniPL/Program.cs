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
                SourceStream source = new SourceStream(@"D:\Timo\MiniPL Samples\a.txt");
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
                return Error("Type mismatch: Expected \"" + ex.Expected + "\" but \"" + ex.Found + "\" was found");
            }
            catch (VariableNameDefinedException ex)
            {
                return Error("Variable \"" + ex.Identifier + "\" is defined more than once");
            }
            catch (UndefinedOperatorException ex)
            {
                return Error("Operator \"" + ex.Operator + "\" is not defined for the type " + ex.Type);
            }
            catch (AssertationExecption)
            {
                return Error("Assertation failure");
            }
            catch (IntegerParseOverflowException ex)
            {
                return Error("Given integer (" + ex.Value + ") is not in the valid range [" + int.MinValue + " - +" + int.MaxValue + "]");
            }
            catch (IntegerFormatException ex)
            {
                return Error("Given value (\"" + ex.ParseAttempt + "\") is not an integer");
            }
            catch (Exception ex)
            {
                return Error("Internal compiler error ¯\\_(ツ)_/¯:\n" + ex.Message + "\n" + ex.StackTrace);
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
