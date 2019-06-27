using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

/*
 * Terminal Hacker Game
 * 
 * Author: Luke McCann
 * 
 * It is not recommended to hard code anything, however as this is just a short exercise to get used
 * to Unity the options are hard coded in a conevenient location for changing. In a real project
 * it is better to utilise getters and setters. 
 */
public class Hacker : MonoBehaviour
{

    private string[] modeList = {"Huddersfield University", // easy mode
                                 "Huddersfield Town Hall", // medium mode
                                 "MI5 - Hidden Terminal" }; // hard mode

    private string[] easyPasswords = { "module", "books", "lecture", "project", "curriculum" };
    private string[] midPasswords = { "mayoral", "municipality", "council", "metropolitan", "senate" };
    private string[] hardPasswords = { "anthropoid", "blechley", "valkyrie", "azorian", "walther" };

    // Current Game State
    public int level;
    private string answer;
    private string location;
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        Terminal.ClearScreen();
        this.currentScreen = Screen.MainMenu;
        WriteBanner();
        ShowMainMenu(modeList[0], modeList[1], modeList[2]);
    }

    void WriteBanner()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("######## Hax0r OS : 2019 ########");
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("");
    }

    void ShowMainMenu(string op1, string op2, string op3)
    {
        Terminal.WriteLine("Wireless Connections:");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for: " + op1);
        Terminal.WriteLine("Press 2 for: " + op2);
        Terminal.WriteLine("Press 3 for: " + op3);
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if(input.ToLower() == "menu") // Always possible to access menu
        {
            Start();
        }

        if(currentScreen == Screen.MainMenu && input.ToLower() != "menu")
        {
            if (input == "007") // Easter egg only for MainMenu
            {
                Terminal.WriteLine("Please select a level Mr. Bond.");
            }
            else
            {
                RunMainMenu(input);
            }
        }
        else if(currentScreen == Screen.Password)
        {
            RunPasswordValidation(input);
        }

    }

    void RunMainMenu(string input)
    {
        try
        {
            int selection = Convert.ToInt32(input);
            if ((selection > modeList.Length || selection <= 0) && currentScreen == Screen.MainMenu)
            {
                Error001(selection);
            }
            else
            {
                StartLevel(selection);
            }
        }
        catch (FormatException fe)
        {
            Terminal.WriteLine("Invalid Input!");
            print(fe.ToString());
        }
    }

    void Error001(int input)
    {
        Terminal.WriteLine("Error 001: " + input + " is OutOfBounds");
    }

    void StartLevel(int input)
    {
        this.level = input;
        this.currentScreen = Screen.Password;
        RunPasswordGuess(input);
    }

    void RunPasswordGuess(int input)
    {
        this.location = modeList[input - 1];
        if(currentScreen == Screen.Password)
        {
            SetAnswer();

            Terminal.ClearScreen();
            Terminal.WriteLine("Welcome to " + location + "!");
            Terminal.WriteLine("");

            Terminal.WriteLine("Hint: " + Scramble(this.answer));
            Terminal.WriteLine("Please enter your password: ");
        }
    }

    void SetAnswer()
    {
        System.Random rnd = new System.Random();
   
        if (this.level == 1)
        {
            int index = rnd.Next(easyPasswords.Length);
            this.answer = easyPasswords[index];
        }
        else if (this.level == 2)
        {
            int index = rnd.Next(midPasswords.Length);
            this.answer = midPasswords[index];
        }
        else
        {
            int index = rnd.Next(hardPasswords.Length);
            this.answer = hardPasswords[index];
        }
    }

    public string Scramble(string word)
    {
        char[] chars = new char[word.Length];
        System.Random rand = new System.Random(10000);

        int index = 0;

        while (word.Length > 0)
        {
            // Get a random number between 0 and the length of the word.
            int next = rand.Next(0, word.Length - 1);

            // Take the character from the random position and add to our char array.
            chars[index] = word[next];

            // Remove the character from the word.
            word = word.Substring(0, next) + word.Substring(next + 1);

            ++index;
        }

        return new String(chars);
    }

    void RunPasswordValidation(string input)
    {
        try
        {
            if(input == this.answer)
            {
                currentScreen = Screen.Win;
                RunWinScreen();
            }
            else
            {
                RunLoseScreen();
            }
        }
        catch (Exception e)
        {
            print(e.ToString());
        }
    }

    void RunWinScreen()
    {
        if(currentScreen == Screen.Win)
        {
            Terminal.WriteLine("Logging in...");
            System.Threading.Thread.Sleep(300);
            Terminal.ClearScreen();

            Terminal.WriteLine(this.location + " - Admin Terminal");
            System.Threading.Thread.Sleep(1000);
            Terminal.WriteLine("Accessing remote data...");
            System.Threading.Thread.Sleep(1000);
            Terminal.WriteLine("===================>");
            System.Threading.Thread.Sleep(2000);
            Terminal.WriteLine("Downloading drives...");
            System.Threading.Thread.Sleep(1500);
            Terminal.WriteLine("Releasing records...");
            System.Threading.Thread.Sleep(1000);
            Terminal.WriteLine("Done!");
        }
    }

    void RunLoseScreen()
    {
        Terminal.WriteLine("Logging in...");
        System.Threading.Thread.Sleep(300);
        Terminal.WriteLine("Password Incorrect! Please try again!");
    }
 
}
