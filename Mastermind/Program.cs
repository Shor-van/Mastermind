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
 * Mastermind game made by Shor_van(Espedito)
 * for GameDev Assignment
 * 
 * Mastermind V2.00
 * ==========================================
 * Notes
 * 
 * Colors and there numbers
 * Red=1
 * Lime=2
 * Yellow=3
 * Blue=4
 * White=5
 * Cyan=6
 * Magenta=7
 * Gray=8
 * 
 * Key pegs
 * 
 * 0=incorrect everything (black/blank)
 * 1=correct color only (White)
 * 2=correct everything (Red)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Mastermind
{
    class Program
    {
        public static int difficulty = 0;
        public static int[] code = new int[4];
        public static Random rand = new Random();
        public static int tSec = 0;
        public static int tMin = 0;
        public static int[] highscores = new int[10];
        public static string[] names = new string[10];
        public static int[] scoreDiff = new int[10];
        public static int[] hCode = new int[4];
        public static int[] userGuess = new int[4];
        public static int[] fBack = new int[4];
        public static int win = 0;
        public static int guesses = 0;
        public static int mColors = 4;
        public static int mGuesses = 14;
        public static int mTime = 0;
        public static bool WhitePegs = true;
        public static bool timeLimit = false;
        public static System.Threading.Thread CoreThreadID;
        public static readonly object _locker = new object();
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 34);
            Console.Title = "Mastermind V2.0";
            Console.CursorVisible = false;
            Console.BufferWidth = 100;
            Console.BufferHeight = 34;
            CoreThreadID = System.Threading.Thread.CurrentThread;
            ShowIntro();
            ShowMenu();
        }
        #region Core Mathods
//=============================[Core-Mathods]==============================
        public static void ShowIntro()
        {
            //Draw Intro here (Mabey use animations)
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            RanderLogoAnim();
            RanderMastermindText(20, 3);
            RanderShorvanText(26, 25);
            System.Threading.Thread.Sleep(1500);
        }
        public static void ShowMenu()
        {
            //Draw Menu here layout see bottom of page
            //To return the option selected 1-3 (Start Game,Help,Exit)
            ConsoleKeyInfo key;
            int selection = 1;
            Console.ResetColor();
            Console.Clear();
            RanderMenuSelection(selection);
            Console.ResetColor();
            Console.SetCursorPosition(1, 33);
            Console.Write("EXIT:ESC");
            Console.SetCursorPosition(87, 33);
            Console.Write("SELECT:ENTER");
            Console.SetCursorPosition(45, 33);
            Console.Write("UP:W DOWN:S");
            RanderMastermindText(23, 2);
            SplashText(63, 7);
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 's')
                {
                    //move selection down
                    if (selection == 3)
                    {
                        //go to first of the list
                        selection = 1;
                    }
                    else
                    {
                        selection++;
                    }
                    RanderMenuSelection(selection);
                    //Console.Beep(1500,20);
                    //Console.Beep(1000, 50);
                }
                else if (key.KeyChar == 'w')
                {
                    //move selection up
                    if (selection == 1)
                    {
                        //go to last of the list
                        selection = 3;
                    }
                    else
                    {
                        selection--;
                    }
                    RanderMenuSelection(selection);
                    //Console.Beep(1500, 20);
                    //Console.Beep(1000, 50);
                }
                else if (key.KeyChar == 13)
                {
                    //do task dased on selection
                    switch (selection)
                    {
                        case 1:
                            ShowDifficultyMenu();
                            break;
                        case 2:
                            ShowHelp();
                            break;
                        case 3:
                            ShowHighScore();
                            break;
                        default:
                            //ErrorReport(0012, selection);
                            break;
                    }
                }
                else if (key.KeyChar == 27)
                {
                    ShowHighScore();
                }
            }
            while (key.KeyChar != 27);
        }
        public static void ShowDifficultyMenu()
        {
            //Drwa Difficlty Menu layout see botton of page
            //To retuen the difficulty setected 1-3 (Easy,Normal,Hard)
            ConsoleKeyInfo key;
            int selection = 1;
            int preset = 1;
            Console.Clear();
            RanderDifficultySelection(selection,preset);
            PresetSettings(preset);
            RanderDifficultySettings(preset, mGuesses, mColors, timeLimit, mTime, WhitePegs);
            Console.ResetColor();
            Console.SetCursorPosition(1, 33);
            Console.Write("BACK:ESC");
            Console.SetCursorPosition(88, 33);
            Console.Write("START:ENTER");
            Console.SetCursorPosition(45, 32);
            Console.Write("UP:W DOWN:S");
            Console.SetCursorPosition(43, 33);
            Console.Write("LEFT:A  RIGHT:D");
            Console.SetCursorPosition(37, 12);
            Console.Write("Chose Level of Difficulty");
            Console.SetCursorPosition(30,26);
            Console.Write("Press enter when done to start the game.");
            RanderNewGameText(29, 2);
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 'w')
                {
                    //move up
                    //Console.Beep();
                    if (preset == 4)
                    {

                        if (selection == 1)
                        {
                            selection = 6;
                        }
                        else
                        {
                            selection--;
                        }
                    }
                    RanderDifficultySelection(selection,preset);
                }
                else if (key.KeyChar == 's')
                {
                    //move down
                    //Console.Beep();
                    if (preset == 4)
                    {

                        if (selection == 6)
                        {
                            selection = 1;
                        }
                        else
                        {
                            selection++;
                        }
                    }
                    RanderDifficultySelection(selection,preset);
                }
                else if (key.KeyChar == 'a')
                {
                    //move left
                    switch (selection)
                    {
                        case 1:
                            if (preset == 1)
                            {
                                preset = 4;
                            }
                            else
                            {
                                preset--;
                            }
                            break;
                        case 2:
                            if(mGuesses == 1)
                            {
                                mGuesses = 1;
                            }
                            else
                            {
                                mGuesses--;
                            }
                            break;
                        case 3:
                            if(mColors == 4)
                            {
                                mColors = 4;
                            }
                            else
                            {
                                mColors--;
                            }
                            break;
                        case 4:
                            if(WhitePegs == false)
                            {
                                WhitePegs = true;
                            }
                            break;
                        case 5:
                            if(timeLimit == false)
                            {
                                timeLimit = true;
                            }
                            break;
                        case 6:
                            if(mTime == 1)
                            { 
                                mTime = 1; 
                            }
                            else
                            {
                                mTime--;
                            }
                            break;

                    }
                    RanderDifficultySelection(selection, preset);
                    PresetSettings(preset);
                    RanderDifficultySettings(preset,mGuesses,mColors,timeLimit,mTime,WhitePegs);
                }
                else if (key.KeyChar == 'd')
                {
                    //move right
                    switch (selection)
                    {
                        case 1:
                            if(preset == 4)
                            {
                                preset = 1;
                            }
                            else
                            {
                                preset++;
                            }
                            break;
                        case 2:
                            if (mGuesses == 14)
                            {
                                mGuesses = 14;
                            }
                            else
                            {
                                mGuesses++;
                            }
                            break;
                        case 3:
                            if (mColors == 8)
                            {
                                mColors = 8;
                            }
                            else
                            {
                                mColors++;
                            }
                            break;
                        case 4:
                            if(WhitePegs == true)
                            {
                                WhitePegs = false;
                            }
                            break;
                        case 5:
                            if(timeLimit == true)
                            {
                                timeLimit = false;
                            }
                            break;
                        case 6:
                            if(mTime == 10)
                            {
                                mTime = 10;
                            }
                            else
                            {
                                mTime++;
                            }
                            break;
                    }
                    RanderDifficultySelection(selection, preset);
                    PresetSettings(preset);
                    RanderDifficultySettings(preset, mGuesses, mColors, timeLimit, mTime, WhitePegs);
                }
                else if (key.KeyChar == 13)
                {
                    difficulty = preset;
                    DrawGameBorad();
                }
                else if (key.KeyChar == 27)
                {
                    ShowMenu();
                }
            }
            while (key.KeyChar != 27);
        }
        public static void ShowHelp()
        {
            Console.ResetColor();
            Console.Clear();
            Console.SetCursorPosition(41, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Mastermind Info");
            Console.SetCursorPosition(0, 3);
            Console.ResetColor();
            Console.WriteLine("Mastermind by Shor_van(Espedito) V2.00");
            Console.WriteLine();
            Console.Write("Mastermind is a game that is played by two people, one who is the codecreator and the other who is  ");
            Console.Write("the codebreaker in this computer version of the game you(the player) is always the codebreaker the  ");
            Console.Write("game will create the code and you have to crack it.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The game will create a code of four colors picked from a set of colors, the number of diffrent      ");
            Console.Write("colors depends on the diffuclty easy is 4 and hard is 8. The number of guesses also depends on the  ");
            Console.Write("difficulty easy more guesses hard less.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("The objective");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The objective of Mastermind is to guess the hiddien code in the lowest number of guesses, the lower ");
            Console.Write("number of guesses the bigger your score will be.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Different difficulty");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("This version of mastermind hes three levels of difficulty: Easy, Normal and Hard. the difficulty    ");
            Console.Write("is changed by increasing the number of colors and the maximum number of guesses.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Easy ");
            Console.ResetColor();
            Console.Write("has four different colors: Red, Green, Yellow and Blue, and 14 maximum number of guesses");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Normal ");
            Console.ResetColor();
            Console.Write("has six different colors easy colors + cyan and white, and 10 maximum number of guesses");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hard ");
            Console.ResetColor();
            Console.Write("has eight different colors easy and normal + magenta and gray and 6 maximum number of guesses ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("NOTE:V2.0 introducted custom difficulty settings that let you customize the game settings.");
            Console.SetCursorPosition(12, 29);
            Console.Write("Press Enter to go to the next page or esc to go back to the main menu.");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 13)
                {
                    DrawSecondHelpPage();
                }
            }
            while (key.KeyChar != 27);
            ShowMenu();
        }
        public static void DrawSecondHelpPage()
        {
            Console.Clear();
            Console.SetCursorPosition(41, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Mastermind Info");
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Instructions");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("You move on the current guess by A and D and place colors by pressing the letter that the color     ");
            Console.Write("starts with Ex: for Red you would press r and for blue you would press b");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("the game will give you feedback based on the guess you just enterd in the for of red and white      ");
            Console.Write("colored peg called keypegs");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red ");
            Console.ResetColor();
            Console.Write("if you get this keypeg that means that both the color and the position of the peg that is       ");
            Console.Write("connected to are correct Ex: here there second peg is correct in color and position");
            Console.SetCursorPosition(39, 14);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(37, 15);
            Console.Write("----------------------");
            Console.SetCursorPosition(39, 16);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(59, 16);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" ▄ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▄ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("▄ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("▄ ");
            Console.SetCursorPosition(0, 18);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("White ");
            Console.ResetColor();
            Console.Write("if you get this keypag that means that the color is correct but not the position of the peg   ");
            Console.Write("that it is connected to Ex:Here the red is a correct color but its not in the correct position");
            Console.SetCursorPosition(39, 21);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(37, 22);
            Console.Write("----------------------");
            Console.SetCursorPosition(39, 23);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("███  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(59, 23);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ▄ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("▄ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("▄ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("▄ ");
            Console.SetCursorPosition(0, 25);
            Console.ResetColor();
            Console.Write("Black/Blank if you get this it means that nothing is correct remeber that in hard mode white keypegs");
            Console.Write("are not drawn");
            Console.SetCursorPosition(12, 29);
            Console.Write("Press Enter to go to the main menu or esc to go back to the first page.");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 13)
                {
                    ShowMenu();
                }
            }
            while (key.KeyChar != 27);
            ShowHelp();
        }
        //no need for another page 
        /*public static void DrawThirdHelpPage()
        {
            Console.Clear();
            Console.SetCursorPosition(41, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Mastermind Info");
            Console.SetCursorPosition(0, 3);
            Console.ResetColor();
            Console.WriteLine("Custom Difficulty");
            Console.WriteLine();
            Console.Write("This is a new mode that lets you change all the setting that are normaly controlled by the game.    ");
            Console.Write("like the number of guesses or the number of different colors that are used");
            Console.SetCursorPosition(12, 29);
            Console.Write("Press Enter to go to the main menu or esc to go back to the seconed page.");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 13)
                {
                    ShowMenu();
                }
            }
            while (key.KeyChar != 27);
            DrawSecondHelpPage();
        }*/
        public static void ShowHighScore()
        {
            //Draw high score
            Console.Clear();
            Console.ResetColor();
            RanderHighScoreText(25, 2);
            Console.ForegroundColor = ConsoleColor.White;
            string diff = null;
            int idx = 0;
            int pos = 1;
            for (int i = 9; i >= 0; i--)
            {
                if (names[i] != null)
                {
                    switch(scoreDiff[i])
                    {
                        case 1:
                            diff = "Easy";
                            break;
                        case 2:
                            diff = "Normal";
                            break;
                        case 3:
                            diff = "Hard";
                            break;
                        case 4:
                            diff = "Custom";
                            break;
                        default:
                            diff = "Unknown";
                            break;
                    }
                    Console.SetCursorPosition(7, 9 + idx);
                    Console.Write(pos + " " + diff + " " + names[i]);
                    int left = Console.CursorLeft;
                    do
                    {
                        Console.Write(".");
                        left = Console.CursorLeft;
                    }
                    while(left != 86);
                    Console.Write(highscores[i]);
                    idx++;
                    pos++;
                }
            }
            Console.SetCursorPosition(34, 30);
            Console.Write("Press any key to quit the game.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void StartGame()
        {
            for (int i = 0; i < 4; i++)
            {
                hCode[i] = RandomNum(1, mColors + 1);
            }
            GameMain();
        }
        public static void GameMain()
        {
            //infinateloop
            TimerThread timer = new TimerThread();
            System.Threading.Thread timerThread = new System.Threading.Thread(new System.Threading.ThreadStart(timer.Timer));
            timerThread.Start();
            while (!timerThread.IsAlive);
            ConsoleKeyInfo key;
            int selection = 1;
            int idx = 0;
            RanderPegSelection(selection, idx);
            do
            {
                while(Console.KeyAvailable == false) 
                {
                    if(tMin == mTime && timeLimit == true)
                    {
                        while (timerThread.IsAlive);
                        lock(_locker)
                        { 
                            Console.SetCursorPosition(11,15);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("You are out of time! :-(");
                        }
                        RanderHiddienCode();
                        win = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            fBack[i] = 0;
                            userGuess[i] = 0;
                        }
                        PlaySongLose();
                        System.Threading.Thread.Sleep(1500);
                        GameOver();
                    }
                    if (tMin == 99 && tSec == 59)
                    {
                        while (timerThread.IsAlive);
                        Console.SetCursorPosition(6, 15);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Do you really need that much time?");
                        RanderHiddienCode();
                        win = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            fBack[i] = 0;
                            userGuess[i] = 0;
                        }
                        PlaySongLose();
                        System.Threading.Thread.Sleep(1500);
                        GameOver();
                    }
                }
                key = Console.ReadKey(true);
                if (key.KeyChar == 'a')
                {
                    //move select left
                    if (selection == 1)
                    {
                        selection = 1;
                    }
                    else
                    {
                        selection--;
                    }
                    RanderPegSelection(selection, idx);
                }
                else if (key.KeyChar == 'd')
                {
                    //move select right
                    if (selection == 4)
                    {
                        selection = 4;
                    }
                    else
                    {
                        selection++;
                    }
                    RanderPegSelection(selection, idx);

                }
                else if (key.KeyChar == 'r')
                {
                    //draw red in cur selection
                    userGuess[selection - 1] = 1;
                    RanderPlayerGuess(idx);
                }
                else if (key.KeyChar == 'l')
                {
                    //draw lime in cur selection
                    userGuess[selection - 1] = 2;
                    RanderPlayerGuess(idx);
                }
                else if (key.KeyChar == 'y')
                {
                    //draw yellow in cur selection
                    userGuess[selection - 1] = 3;
                    RanderPlayerGuess(idx);
                }
                else if (key.KeyChar == 'b')
                {
                    //draw blue in cur selection
                    userGuess[selection - 1] = 4;
                    RanderPlayerGuess(idx);
                }
                else if (key.KeyChar == 'w')
                {
                    //check if normal dif if not do noting
                    //draw white in cur selection
                    if (mColors >= 5)
                    {
                        userGuess[selection - 1] = 5;
                        RanderPlayerGuess(idx);
                    }
                }
                else if (key.KeyChar == 'c')
                {
                    //check if normal dif if not do nothing
                    //draw cyan in cur selection
                    if (mColors >= 6)
                    {
                        userGuess[selection - 1] = 6;
                        RanderPlayerGuess(idx);
                    }
                }
                else if (key.KeyChar == 'm')
                {
                    //check if hard dif if not do nothing
                    //draw magenta in cur selection
                    if (mColors >= 7)
                    {
                        userGuess[selection - 1] = 7;
                        RanderPlayerGuess(idx);
                    }
                }
                else if (key.KeyChar == 'g')
                {
                    //check if hard dif if not do nothing
                    //draw gray in cur selection
                    if (mColors == 8)
                    {
                        userGuess[selection - 1] = 8;
                        RanderPlayerGuess(idx);
                    }
                }
                else if (key.KeyChar == 13)
                {
                    //check to see if the guess is complete
                    if (userGuess[0] != 0 && userGuess[1] != 0 && userGuess[2] != 0 && userGuess[3] != 0)
                    {
                        //compere guess whit hiddien code
                        //show feedback
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (Identical(userGuess[i], hCode[j]))
                                {
                                    if (i == j)
                                    {
                                        fBack[i] = 2;
                                        break;
                                    }
                                    else
                                    {
                                        fBack[i] = 1;
                                    }
                                }
                            }
                        }
                        guesses++;
                        RanderKeyPegs(idx);
                        RanderPlayerGuess(idx);
                        if (fBack[0] == 2 && fBack[1] == 2 && fBack[2] == 2 && fBack[3] == 2)
                        {
                            timerThread.Abort();
                            timerThread.Join();
                            RanderHiddienCode();
                            win = 1;
                            for (int i = 0; i < 4; i++)
                            {
                                fBack[i] = 0;
                                userGuess[i] = 0;
                            }
                            PlaySongWin();
                            System.Threading.Thread.Sleep(1500);
                            GameOver();
                        }
                        else if (guesses == mGuesses)
                        {
                            timerThread.Abort();
                            timerThread.Join();
                            RanderHiddienCode();
                            win = 0;
                            for (int i = 0; i < 4; i++)
                            {
                                fBack[i] = 0;
                                userGuess[i] = 0;
                            }
                            PlaySongLose();
                            System.Threading.Thread.Sleep(1500);
                            GameOver();
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            fBack[i] = 0;
                            userGuess[i] = 0;
                        }
                        idx = idx - 2;
                        selection = 1;
                        RanderPegSelection(selection, idx);
                    }
                }
                else if (key.KeyChar == 'n')
                {
                    //used for testing
                    RanderHiddienCode();
                }
            }
            while (1 != 2);
        }
        public static void GameOver()
        {
            Console.ResetColor();
            Console.Clear();
            RanderGameOverText(26, 2);
            if (win == 1)
            {
                RanderWinText(32, 8);
                double scoreTmp = CalculateScore();
                int score = Convert.ToInt32(scoreTmp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(40, 15);
                Console.Write("your score was:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(score);
                int hScoreIdx = CheckScore(score);
                if (hScoreIdx != -1)
                {
                    SortHighScore(hScoreIdx);
                    Console.SetCursorPosition(38, 18);
                    Console.Write("You Got a New Highscore");
                    Console.SetCursorPosition(42, 20);
                    Console.Write("Enter your name:");
                    Console.SetCursorPosition(42, 23);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("----------------");
                    Console.SetCursorPosition(42, 22);
                    Console.CursorVisible = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    names[hScoreIdx] = Console.ReadLine();
                    //names[hScoreIdx] = GetUserName();
                    //Console.Write(names[hScoreIdx]);
                    highscores[hScoreIdx] = score;
                    scoreDiff[hScoreIdx] = difficulty;
                    //difficulty = 1;
                    Console.CursorVisible = false;
                }
            }
            else
            {
                RanderLoseText(30, 8);
            }
            guesses = 0;
            tMin = 0;
            tSec = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(29, 27);
            Console.Write("Press any key to go back to the main menu.");
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey();
            ShowMenu();
        }
        #endregion
        #region Graphics
//==================================[Graphics]=================================
        public static void DrawGameBorad()
        {
            //Draw Game board here
            Console.Clear();
            Console.ResetColor();
            Console.SetCursorPosition(46, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            for (int i = 0; i < 32; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(46, 1 + i);
                Console.Write("█                                ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("█");
            }
            Console.SetCursorPosition(46, 33);
            Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            int cord = 31;
            for (int i = 0; i < 14; i++)
            {
                Console.SetCursorPosition(48, cord - i);
                Console.ForegroundColor = ConsoleColor.Black;
                if (mGuesses <= i )
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                int idx = i + 1;
                Console.Write(idx);
                Console.SetCursorPosition(51, cord - i);
                Console.Write("███  ███  ███  ███  ▄ ▄ ▄ ▄");
                cord--;
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(54, 2);
            Console.Write("??   ??   ??   ??");
            Console.SetCursorPosition(47, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("________________________________");
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(70, 4 + i);
                Console.Write("|");
            }
            RanderInGameInfoBox(1, 18);
            StartGame();
        }
        public static void RanderMenuSelection(int selection)
        {
            switch (selection)
            {
                case 1:
                    Console.ResetColor();
                    Console.SetCursorPosition(41, 16);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->START NEW GAME");
                    Console.ResetColor();
                    Console.SetCursorPosition(43, 17);
                    Console.Write("  HOW TO PLAY");
                    Console.SetCursorPosition(46, 18);
                    Console.Write("  EXIT");
                    break;
                case 2:
                    Console.ResetColor();
                    Console.SetCursorPosition(41, 16);
                    Console.Write("  START NEW GAME");
                    Console.SetCursorPosition(43, 17);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->HOW TO PLAY");
                    Console.ResetColor();
                    Console.SetCursorPosition(46, 18);
                    Console.Write("  EXIT");
                    break;
                case 3:
                    Console.ResetColor();
                    Console.SetCursorPosition(41, 16);
                    Console.Write("  START NEW GAME");
                    Console.SetCursorPosition(43, 17);
                    Console.Write("  HOW TO PLAY");
                    Console.SetCursorPosition(46, 18);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->EXIT");
                    Console.ResetColor();
                    break;
                default:
                    //ErrorReport(0010, selection);
                    break;
            }
        }
        public static void RanderDifficultySelection(int selection,int preset)
        {
            //to change difficulty selection here
            switch (selection)
            {
                case 1:
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Presets");
                    Console.ResetColor();
                    if(preset != 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.SetCursorPosition(40, 17);
                    Console.Write("  Max Guesses");
                    Console.SetCursorPosition(40, 18);
                    Console.Write("  Max Colors");
                    Console.SetCursorPosition(40, 19);
                    Console.Write("  Show White Pegs");
                    Console.SetCursorPosition(40, 20);
                    Console.Write("  Time Limit");
                    Console.SetCursorPosition(40, 21);
                    Console.Write("  Max Time Limit");
                    break;
                case 2:
                    //narmal selected
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.Write("  Presets");
                    Console.SetCursorPosition(40, 17);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Max Guesses");
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 18);
                    Console.Write("  Max Colors");
                    Console.SetCursorPosition(40, 19);
                    Console.Write("  Show White Pegs");
                    Console.SetCursorPosition(40, 20);
                    Console.Write("  Time Limit");
                    Console.SetCursorPosition(40, 21);
                    Console.Write("  Max Time Limit");
                    break;
                case 3:
                    //hard selected
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.Write("  Presets");
                    Console.SetCursorPosition(40, 17);
                    Console.Write("  Max Guesses");
                    Console.SetCursorPosition(40, 18);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Max Colors");
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 19);
                    Console.Write("  Show White Pegs");
                    Console.SetCursorPosition(40, 20);
                    Console.Write("  Time Limit");
                    Console.SetCursorPosition(40, 21);
                    Console.Write("  Max Time Limit");
                    break;
                case 4:
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.Write("  Presets");
                    Console.SetCursorPosition(40, 17);
                    Console.Write("  Max Guesses");
                    Console.SetCursorPosition(40, 18);
                    Console.Write("  Max Colors");
                    Console.SetCursorPosition(40, 19);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Show White Pegs");
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 20);
                    Console.Write("  Time Limit");
                    Console.SetCursorPosition(40, 21);
                    Console.Write("  Max Time Limit");
                    break;
                case 5:
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.Write("  Presets");
                    Console.SetCursorPosition(40, 17);
                    Console.Write("  Max Guesses");
                    Console.SetCursorPosition(40, 18);
                    Console.Write("  Max Colors");
                    Console.SetCursorPosition(40, 19);
                    Console.Write("  Show White Pegs");
                    Console.SetCursorPosition(40, 20);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Time Limit");
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 21);
                    Console.Write("  Max Time Limit");
                    break;
                case 6:
                    Console.ResetColor();
                    Console.SetCursorPosition(40, 16);
                    Console.Write("  Presets");
                    Console.SetCursorPosition(40, 17);
                    Console.Write("  Max Guesses");
                    Console.SetCursorPosition(40, 18);
                    Console.Write("  Max Colors");
                    Console.SetCursorPosition(40, 19);
                    Console.Write("  Show White Pegs");
                    Console.SetCursorPosition(40, 20);
                    Console.Write("  Time Limit");
                    Console.SetCursorPosition(40, 21);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("->Max Time Limit");
                    Console.ResetColor();
                    break;
                default:
                    //send error report if enterd(SHOULD NOT ENTER)
                    //ErrorReport(0011, selection);
                    break;
            }
        }
        public static void RanderDifficultySettings(int pre,int guess,int color,bool time,int tLimt,bool keypegs)
        {
            Console.ResetColor();
            switch(pre)
            {
                case 1:
                    Console.SetCursorPosition(49, 16);
                    Console.Write(":Easy  ");
                    break;
                case 2:
                    Console.SetCursorPosition(49, 16);
                    Console.Write(":Normal");
                    break;
                case 3:
                    Console.SetCursorPosition(49,16);
                    Console.Write(":Hard  ");
                    break;
                case 4:
                    Console.SetCursorPosition(49, 16);
                    Console.Write(":Custom");
                    break;
            }
            Console.SetCursorPosition(53, 17);
            Console.Write(":");
            if(mGuesses <= 14 && mGuesses > 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (mGuesses <= 10 && mGuesses > 6)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(mGuesses+" ");
            Console.SetCursorPosition(52,18);
            Console.ResetColor();
            Console.Write(":");
            if(mColors >= 4 && mColors < 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if(mColors >= 6 && mColors < 8)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(mColors+" ");
            Console.ResetColor();
            Console.SetCursorPosition(57,19);
            Console.Write(":");
            switch(keypegs)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Yes");
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("No ");
                    break;
            }
            Console.ResetColor();
            Console.SetCursorPosition(52, 20);
            Console.Write(":");
            switch (time)
            {
                case false:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("No ");
                    break;
                case true:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Yes");
                    break;
            }
            Console.ResetColor();
            Console.SetCursorPosition(56,21);
            Console.Write(":");
            if(tLimt <= 10 && tLimt > 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (tLimt <= 6 && tLimt > 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(tLimt + " " + "Min ");
        }
        public static void RanderInGameInfoBox(int left, int top)
        {
            //Console.ResetColor();
            Console.SetCursorPosition(left, top - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write("█");
                Console.Write("                                          ");
                Console.Write("█");
            }
            Console.SetCursorPosition(left, top + 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left + 2, top + 1);
            Console.Write("Game info           Controls Info");
            Console.SetCursorPosition(left + 2, top + 3);
            Console.Write("Difficulty:");
            switch (difficulty)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Easy");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Nromal");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Hard");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Custom");
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left + 22, top + 3);
            Console.Write("Move Left=A");
            Console.SetCursorPosition(left + 2, top + 4);
            Console.Write("Max Guesses:" + mGuesses);
            Console.SetCursorPosition(left + 22, top + 4);
            Console.Write("Move Right=D");
            Console.SetCursorPosition(left + 2, top + 5);
            Console.Write("Max Colors:" + mColors);
            Console.SetCursorPosition(left + 22, top + 5);
            Console.Write("Confirm Guess=Enter");
            Console.SetCursorPosition(left + 2, top + 7);
            Console.Write("Color Info and Keys");
            Console.SetCursorPosition(left + 2, top + 9);
            Console.Write("Easy       Normal          Hard");
            Console.SetCursorPosition(left + 2, top + 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red=R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("      Easy Colors     Normal Colors");
            Console.SetCursorPosition(left + 2, top + 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Lime=L");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("     White=W");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("         Magenta=M");
            Console.SetCursorPosition(left + 2, top + 12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Yellow=Y");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("   Cyan=C");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("          Gray=G");
            Console.SetCursorPosition(left + 2, top + 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Blue=B");
        }
        public static void RanderKeyPegs(int idx)
        {
            lock (_locker)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                int cords = 71;
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(cords + i, 31 + idx);
                    switch (fBack[i])
                    {
                        case 1:
                            if (WhitePegs == true)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("▄");
                            }
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("▄");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("▄");
                            break;
                    }
                    cords++;
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        public static void RanderPegSelection(int selection, int idx)
        {
            lock (_locker)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                switch (selection)
                {
                    case 1:
                        RanderPlayerGuess(idx);
                        Console.SetCursorPosition(51, 31 + idx);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("███");
                        break;
                    case 2:
                        RanderPlayerGuess(idx);
                        Console.SetCursorPosition(56, 31 + idx);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("███");
                        break;
                    case 3:
                        RanderPlayerGuess(idx);
                        Console.SetCursorPosition(61, 31 + idx);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("███");
                        break;
                    case 4:
                        RanderPlayerGuess(idx);
                        Console.SetCursorPosition(66, 31 + idx);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("███");
                        break;
                    default:
                        break;
                }
            }
        }
        public static void RanderPlayerGuess(int idx)
        {
            lock (_locker)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                int cords = 51;
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(cords + i, 31 + idx);
                    switch (userGuess[i])
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("███");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("███");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("███");
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("███");
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("███");
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("███");
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("███");
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("███");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("███");
                            break;
                    }
                    cords = cords + 4;
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        public static void RanderHiddienCode()
        {
            lock (_locker)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                int cords = 54;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        Console.SetCursorPosition(cords + i, 2);
                        switch (hCode[i])
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("███");
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("███");
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("███");
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("███");
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("███");
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("███");
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write("███");
                                break;
                            case 8:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("███");
                                break;
                        }
                        cords = cords + 4;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        public static void RanderGameOverText(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ████  ███  █   █ ████  ███  █   █ ████ ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write("█     █   █ ██ ██ █    █   █ █   █ █    █   █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("█  ██ █████ █ █ █ ███  █   █ █   █ ███  ████");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("█   █ █   █ █   █ █    █   █  █ █  █    █   █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write(" ████ █   █ █   █ ████  ███    █   ████ █   █");
        }
        public static void RanderWinText(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█   █  ███  █   █  █   █ ███ █   █");
            Console.SetCursorPosition(left, top + 1);
            Console.Write(" █ █  █   █ █   █  █   █  █  ██  █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("  █   █   █ █   █  █ █ █  █  █ █ █");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("  █   █   █ █   █  ██ ██  █  █  ██");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("  █    ███   ███   █   █ ███ █   █");
        }
        public static void RanderLoseText(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█   █  ███  █   █  █     ███  ████ ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write(" █ █  █   █ █   █  █    █   █ █    █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("  █   █   █ █   █  █    █   █ ███  ████");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("  █   █   █ █   █  █    █   █ █       █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("  █    ███   ███   ████  ███  ████ ████ ");
        }
        public static void RanderShorvanText(int left, int top)
        {
            //Console.ResetColor();
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("████ █     ███  ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write("█    █    █   █ █   █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("████ ████ █   █ ████");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("   █ █  █ █   █ █   █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("████ █  █  ███  █   █");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left + 28, top);
            Console.Write("█   █  ███  █   █");
            Console.SetCursorPosition(left + 28, top + 1);
            Console.Write("█   █ █   █ ██  █");
            Console.SetCursorPosition(left + 28, top + 2);
            Console.Write("█   █ █████ █ █ █");
            Console.SetCursorPosition(left + 28, top + 3);
            Console.Write(" █ █  █   █ █  ██");
            Console.SetCursorPosition(left + 28, top + 4);
            Console.Write("  █   █   █ █   █");
        }
        public static void RanderHighScoreText(int left, int top)
        {
            //Console.ResetColor();
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█   █ ███  ████ █   █ ████  ███  ███  ████  ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write("█   █  █  █     █   █ █    █    █   █ █   █ █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("█████  █  █  ██ █████ ████ █    █   █ ████  ███");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("█   █  █  █   █ █   █    █ █    █   █ █   █ █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("█   █ ███  ████ █   █ ████  ███  ███  █   █ ████");
        }
        public static void RanderNewGameText(int left, int top)
        {
            //Console.ResetColor();
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█   █ ████ █   █    ████  ███  █   █ ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write("██  █ █    █   █   █     █   █ ██ ██ █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("█ █ █ ███  █ █ █   █  ██ █████ █ █ █ ███");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("█  ██ █    ██ ██   █   █ █   █ █   █ █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("█   █ ████ █   █    ████ █   █ █   █ ████");
        }
        public static void RanderMastermindText(int left, int top)
        {
            //Console.ResetColor();
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("█   █  ███  ████ ███ ████ ████  █   █ ███ █   █ ████");
            Console.SetCursorPosition(left, top + 1);
            Console.Write("██ ██ █   █ █     █  █    █   █ ██ ██  █  ██  █ █   █");
            Console.SetCursorPosition(left, top + 2);
            Console.Write("█ █ █ █████ ████  █  ███  ████  █ █ █  █  █ █ █ █   █");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("█   █ █   █    █  █  █    █   █ █   █  █  █  ██ █   █");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("█   █ █   █ ████  █  ████ █   █ █   █ ███ █   █ ████");
        }
        public static void RanderTime(int left, int top, string text, ConsoleColor fColor, ConsoleColor bColor)
        {
            lock (_locker)
            {
                char[] letter = new char[10];
                letter = text.ToCharArray(0, text.Length);
                Console.ForegroundColor = fColor;
                Console.BackgroundColor = bColor;
                for (int i = 0; i < text.Length; i++)
                {
                    switch (letter[i])
                    {
                        case ':':
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write("██");
                            Console.SetCursorPosition(left, top + 3);
                            Console.Write("██");
                            left = left + 3;
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
                    }
                }
            }
        }
        public static void RanderClockBox(int left, int top)
        {
            lock (_locker)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(left, top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                for (int i = 0; i < 8; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(left, top + 1 + i);
                    Console.Write("█                             █");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(left, top + 8);
                Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            }
        }
        public static void SplashText(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Yellow;
            int text = RandomNum(1, 27);
            switch (text)
            {
                case 1:
                    Console.Write("Get out of my head!");
                    break;
                case 2:
                    Console.Write("Mind reading!");
                    break;
                case 3:
                    Console.Write("Text-mode Graphics!");
                    break;
                case 4:
                    Console.Write("You some kind of psychic!");
                    break;
                case 5:
                    Console.Write("Made by Shor_van!");
                    break;
                case 6:
                    Console.Write("Made in Malta!");
                    break;
                case 7:
                    Console.Write("16 Colors!");
                    break;
                case 8:
                    Console.Write("Retro!");
                    break;
                case 9:
                    Console.Write("On a Stick!");
                    break;
                case 10:
                    Console.Write("INFREAKINDEED!");
                    break;
                case 11:
                    Console.Write("Epic Splash Text!");
                    break;
                case 12:
                    Console.Write("NyanNyanNyanNyanNyan!");
                    break;
                case 13:
                    Console.Write("DOS Gaming!");
                    break;
                case 14:
                    Console.Write("Old skool gaming son!");
                    break;
                case 15:
                    Console.Write("Theres a glitch in the Matrix!");
                    break;
                case 16:
                    Console.Write("for(int i = 0; i < 15; i--)!");
                    break;
                case 17:
                    Console.Write("Get a Rock job!");
                    break;
                case 18:
                    Console.Write("Etho it!");
                    break;
                case 19:
                    Console.Write("The force is strong with this one!");
                    break;
                case 20:
                    Console.Write("Trollololololololol!");
                    break;
                case 21:
                    Console.Write("Console app!");
                    break;
                case 22:
                    Console.Write("Console.Write();!");
                    break;
                case 23:
                    Console.Write("2000 Lines of code!");
                    break;
                case 24:
                    Console.Write("OPPA GANGNAM STYLE!");
                    break;
                case 25:
                    Console.Write("Pi = 3.141592653589!");
                    break;
                case 26:
                    Console.Write("B-Team B Bomin!");
                    break;
                default:
                    //ErrorReport(0013, text);
                    break;
            }
        }
        public static void RanderLogoAnim()
        {
            for (int j = 0; j < 36; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0 + j, 10 + i);
                    Console.Write("█");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(99 - j, 18 + i);
                    Console.Write("█");
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                System.Threading.Thread.Sleep(10);
            }
            for (int i = 0; i < 26; i++)
            {
                Console.MoveBufferArea(0 + i, 10, 36, 4, i + 1, 10);
                Console.MoveBufferArea(64 - i, 18, 36, 4, 64 - i - 1, 18);
                System.Threading.Thread.Sleep(15);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(24 + i, 10);
                Console.Write(" ");
                Console.SetCursorPosition(24 + i, 10 + 1);
                Console.Write(" ");
                Console.SetCursorPosition(24 + i, 10 + 2);
                Console.Write(" ");
                Console.SetCursorPosition(24 + i, 10 + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(54, 14 + i);
                Console.Write("████████");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(73 - i, 18);
                Console.Write(" ");
                Console.SetCursorPosition(73 - i, 18 + 1);
                Console.Write(" ");
                Console.SetCursorPosition(73 - i, 18 + 2);
                Console.Write(" ");
                Console.SetCursorPosition(73 - i, 18 + 3);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(38, 17 - i);
                Console.Write("████████");
                System.Threading.Thread.Sleep(15);
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        #endregion
//====================================[Music]=========================================
        public static void PlaySongWin()
        {
            Console.Beep(500, 200);
            Console.Beep(600, 200);
            Console.Beep(700, 200);
            Console.Beep(800, 400);
            Console.Beep(600, 100);
            Console.Beep(700, 200);
        }
        public static void PlaySongLose()
        {
            Console.Beep(700, 200);
            Console.Beep(500, 200);
            Console.Beep(300, 200);
            Console.Beep(100, 200);
        }
//==============================[Techincal]=============================================
        public static void PresetSettings(int pre)
        {
            switch(pre)
            {
                case 1:
                    mGuesses = 14;
                    mColors = 4;
                    WhitePegs = true;
                    timeLimit = false;
                    mTime = 0;
                    break;
                case 2:
                    mGuesses = 10;
                    mColors = 6;
                    WhitePegs = true;
                    timeLimit = false;
                    mTime = 0;
                    break;
                case 3:
                    mGuesses = 6;
                    mColors = 8;
                    WhitePegs = false;
                    timeLimit = true;
                    mTime = 4;
                    break;
            }
        }
        public static int CheckScore(int score)
        {
            try
            {
                for (int i = highscores.Length - 1; i >= 0; i--)
                {
                    if (score >= highscores[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static void SortHighScore(int idx)
        {
            for (int i = 0; i < idx + 1; i++)
            {
                try
                {
                    names[i] = names[i + 1];
                    highscores[i] = highscores[i + 1];
                    scoreDiff[i] = scoreDiff[i + 1];
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        public static string GetUserName()
        {
            ConsoleKeyInfo key;
            char[] letters = new char[25];
            string userName = "1";
            string tmpStr = "";
            double oddEven = 0;
            int idx = 0;
            do
            {
                try
                {

                    key = Console.ReadKey(true);
                    if (key.KeyChar >= 32 && key.KeyChar <= 126)
                    {
                        letters[idx] = key.KeyChar;
                        idx++;
                        oddEven = idx % 2;
                        if (oddEven == 0)
                        {
                            //moveright ,needs work with randering
                            Console.Write(letters[idx - 1]);
                            //Console.MoveBufferArea(49,22,idx,1,49+1,22);
                            Console.SetCursorPosition(48+idx,22);
                        }
                        else
                        {
                            //moveleft ,needs work with randering
                            Console.Write(letters[idx - 1]);
                            //Console.MoveBufferArea(49 - idx, 22, idx, 1, 49 - 1, 22);
                            Console.SetCursorPosition(49+idx,22);
                        }
                    }
                    if(key.KeyChar == 8)
                    {
                        letters[idx] = ' ';
                        idx--;
                        if (oddEven == 0.0)
                        {
                            //moveright
                        }
                        else
                        {
                            //moveleft
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    return "OutOfRange";
                }
            }
            while (key.KeyChar != 13);
            for (int i = 0; i < idx; i++)
            {
                tmpStr = Convert.ToString(letters[i]);
                userName = userName.Insert(i, tmpStr);
            }
            userName = userName.Remove(userName.Length - 1, 1);
            return userName;
        }
        public static double CalculateScore()
        {
            //base score if no guess used = 1400
            double score = 0;
            double guessScore = 0;
            double timeMulti = 10 - tMin;
            double tLimitBounes = 0;
            double colorScore = mColors * 200;
            double guessMulti = guesses - guesses - guesses * 100; // should create a negative of the number of guesses and turnd it into a houndred
            guessMulti = guessMulti - guessMulti - guessMulti; // sets the number back to a positive
            double whitePegMulti = 1;
            if(timeMulti < 1)
            {
                timeMulti = 1;
            }
            if(timeLimit == true)
            {
                tLimitBounes = 100;
            }
            if(WhitePegs == false)
            {
                whitePegMulti = 1.5;
            }
            guessScore = 1400 - guessMulti;
            score = guessScore + colorScore * whitePegMulti * timeMulti + tLimitBounes;
            return score;
        }
        public static bool Identical(int a, int b)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int RandomNum(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
//=================================[TimerThread]===============================
public class TimerThread
{
    public void Timer()
    {
        do
        {
            if (Game_Mastermind.Program.tSec == 59)
            {
                Game_Mastermind.Program.tMin++;
                Game_Mastermind.Program.tSec = 0;
            }
            else
            {
                Game_Mastermind.Program.tSec++;
            }
            string min = Convert.ToString(Game_Mastermind.Program.tMin);
            string sec = Convert.ToString(Game_Mastermind.Program.tSec);
            if (Game_Mastermind.Program.tMin < 10)
            {
                min = "0" + min;
            }
            if (Game_Mastermind.Program.tSec < 10)
            {
                sec = "0" + sec;
            }
            string strTime = min + ":" + sec;
            Game_Mastermind.Program.RanderClockBox(7, 5);
            if (Game_Mastermind.Program.tMin + 1 == Game_Mastermind.Program.mTime && Game_Mastermind.Program.timeLimit == true)
            {
                if (Game_Mastermind.Program.tSec >= 40)
                {
                    Console.Beep(500, 100);
                }
                Game_Mastermind.Program.RanderTime(10, 7, strTime, ConsoleColor.Red, ConsoleColor.DarkGreen);
            }
            else
            {
                Game_Mastermind.Program.RanderTime(10, 7, strTime, ConsoleColor.White, ConsoleColor.DarkGreen);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            if (Game_Mastermind.Program.tMin == Game_Mastermind.Program.mTime && Game_Mastermind.Program.timeLimit == true)
            {
                break;
            }
            if (Game_Mastermind.Program.tMin == 99 && Game_Mastermind.Program.tSec == 59)
            {
                break;
            }
            if (Game_Mastermind.Program.tSec >= 40)
            {
                System.Threading.Thread.Sleep(900);
            }
            else
            { System.Threading.Thread.Sleep(1000); }
        }
        while (1 != 2);
    }
}