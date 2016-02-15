/*
 * |-----------------------|
 * |                       |
 * |                       | 
 * |-----|-----|-----|     |
 *       |     |     |     |
 *       |     |     |     |
 *       |     |-----|-----|-----|
 *       |                       |
 *       |                       |
 *       |-----------------------|
 *
 * ==========================================
 * ConsoleFonts.class created for Conaole Games
 * made by Shor_van(Espedito)
 * for GameDev Assignment
 * coolest thing I ever made!(In console programing)
 * 
 * ConsoleText V1.00
 * ==========================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTexts
{
    class ConsoleText
    {
        public static void RanderText(int left, int top, string text, ConsoleColor fColor, ConsoleColor bColor)
        {
            char[] letter = new char[50];
            letter = text.ToCharArray(0, text.Length);
            Console.ForegroundColor = fColor;
            Console.BackgroundColor = bColor;
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    switch (letter[i])
                    {
                        //LowerCase
                        case 'a':
                            break;
                        case 'b':
                            break;
                        case 'c':
                            break;
                        case 'd':
                            break;
                        case 'e':
                            break;
                        case 'f':
                            break;
                        case 'g':
                            break;
                        case 'h':
                            break;
                        case 'i':
                            break;
                        case 'j':
                            break;
                        case 'k':
                            break;
                        case 'l':
                            break;
                        case 'm':
                            break;
                        case 'n':
                            break;
                        case 'o':
                            break;
                        case 'p':
                            break;
                        case 'q':
                            break;
                        case 'r':
                            break;
                        case 's':
                            break;
                        case 't':
                            break;
                        case 'u':
                            break;
                        case 'v':
                            break;
                        case 'w':
                            break;
                        case 'x':
                            break;
                        case 'y':
                            break;
                        case 'z':
                            break;
                        //UpperCase
                        case 'A':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███ ");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'B':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'C':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'D':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'E':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case 'F':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█");
                            left = left + 5;
                            break;
                        case 'G':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'H':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'I':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        case 'J':
                            Console.SetCursorPosition(left, top);
                            Console.Write("  ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ██");
                            left = left + 6;
                            break;
                        case 'K':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█  █");
                            left = left + 5;
                            break;
                        case 'L':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case 'M':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("██ ██");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'N':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("██  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'O':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███ ");
                            left = left + 6;
                            break;
                        case 'P':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█");
                            left = left + 6;
                            break;
                        case 'Q':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ██");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ████");
                            left = left + 6;
                            break;
                        case 'R':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'S':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("    █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 6;
                            break;
                        case 'T':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" █");
                            left = left + 4;
                            break;
                        case 'U':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case 'V':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("  █");
                            left = left + 6;
                            break;
                        case 'W':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("██ ██");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'X':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("█   █");
                            left = left + 6;
                            break;
                        case 'Y':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █ █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("  █");
                            left = left + 6;
                            break;
                        case 'Z':
                            Console.SetCursorPosition(left, top);
                            Console.Write("███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        //Numbers
                        case '0':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  ██");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("█ █ █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("██  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case '1':
                            Console.SetCursorPosition(left, top);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write(" █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("███");
                            left = left + 4;
                            break;
                        case '2':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '3':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '4':
                            Console.SetCursorPosition(left, top);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("   █");
                            left = left + 5;
                            break;
                        case '5':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   ");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '6':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        case '7':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("   █");
                            left = left + 5;
                            break;
                        case '8':
                            Console.SetCursorPosition(left, top);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write(" ███");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("█   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write(" ███");
                            left = left + 6;
                            break;
                        case '9':
                            Console.SetCursorPosition(left, top);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("█  █");
                            Console.SetCursorPosition(left, top + 2);
                            Console.Write("████");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("   █");
                            Console.SetCursorPosition(left, top + 4);
                            Console.Write("████");
                            left = left + 5;
                            break;
                        //Special Chars
                        case ' ':
                            left = left + 3;
                            break;
                        case '\'':
                            Console.SetCursorPosition(left, top-1);
                            Console.Write(" ██");
                            Console.SetCursorPosition(left,top);
                            Console.Write("  █");
                            Console.SetCursorPosition(left, top+1);
                            Console.Write(" █");
                            left = left + 4;
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Holy Cr*p on a stick, somethings wrong!");
                    Console.WriteLine();
                    Console.WriteLine("Error:ArgumentOutOfRangeException was thrown while drawing text:" + text);
                    Console.WriteLine();
                    Console.WriteLine("Variable information");
                    Console.WriteLine("=====================");
                    Console.WriteLine("left:" + left + " top:" + top + " letter dawing:" + letter[i]);
                    Console.WriteLine();
                    Console.WriteLine("*End of report*");
                    Console.WriteLine("Press any key to close.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
            Console.ResetColor();
        }
    }
}
