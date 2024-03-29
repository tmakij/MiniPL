﻿using System;
using System.IO;
using MiniPL.Parser;
using MiniPL.Parser.AST;
using MiniPL.Lexer;

namespace MiniPL
{
    public static class Program
    {
        private static int Main(string[] args)
        {
#if !DEBUG
            if (args.Length != 1)
            {
                return Error("The program accepts one, and only one, argument, which is the path to the source");
            }
#endif
            try
            {
#if DEBUG
                const string sourcePath = "test.txt";
#else
                string sourcePath = args[0];
#endif
                SourceStream source = new SourceStream(sourcePath);
                Scanner scanner = new Scanner(source);
                TokenStream tokens = scanner.GenerateTokens();
                var parser = new MiniPL.Parser.Parser(tokens);
                AbstractSyntaxTree tree = parser.Parse();
                tree.CheckIdentifiers();
                tree.CheckTypes();
                Console.WriteLine("Valid program!");
                Console.WriteLine("Executing...");
                Console.WriteLine();
                tree.Execute();
#if DEBUG
                Console.ReadKey(false);
#endif
                return 0;
            }
            catch (FileNotFoundException)
            {
                return Error("The given argument path was not found");
            }
            catch (LexerException ex)
            {
                return Error(ex.Message);
            }
            catch (SyntaxException ex)
            {
                return Error(ex.Message);
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
                return Error("Given value \"" + ex.ParseAttempt + "\" is not an integer");
            }
            catch (ImmutableVariableException ex)
            {
                return Error("Identifier \"" + ex.Identifier + "\" cannot be changed, when it is used as iterator");
            }
            catch (Exception ex)
            {
                return Error("Internal compiler errors:\n" + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private static int Error(string Message)
        {
            Console.Error.WriteLine(Message);
#if DEBUG
            Console.ReadKey(false);
#endif
            return -1;
        }
    }
}
