using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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

    // Current Game State
    public int level;
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
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
        if (input == "007" && currentScreen == Screen.MainMenu) // Easter egg only for MainMenu
        {
            Terminal.WriteLine("Please select a level Mr. Bond.");
        }
        else if(input.ToLower() == "menu") // Always possible to access menu
        {
            Start();
        }
        else
        {
            RunMainMenu(input);
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
        if(currentScreen == Screen.Password)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Welcome to " + modeList[input-1] + "!");
            Terminal.WriteLine("");
            Terminal.WriteLine("Hint: ");
            Terminal.WriteLine("Please enter your password: ");
        }
    }
}
