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
 * to Unity the options are hard coded in a conevenient location for changing. 
 */
public class Hacker : MonoBehaviour
{

    private string[] modeList = {"Huddersfield University", // easy mode
                                 "Huddersfield Town Hall", // medium mode
                                 "MI5 - Hidden Terminal" }; // hard mode

    // Start is called before the first frame update
    void Start()
    {
        writeBanner();
        showMainMenu(modeList[0], modeList[1], modeList[2]);
    }

    void writeBanner()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("######## Hax0r OS : 2019 ########");
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("");
    }

    void showMainMenu(string op1, string op2, string op3)
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
        try
        {
            int selection = Convert.ToInt32(input);

            if(selection > modeList.Length || selection <= 0)
            {
                Terminal.WriteLine("Error 001: " + input + " is OutOfBounds");
            }
            else
            {
                
            }
        }
        catch(FormatException fe)
        {
            Terminal.WriteLine("Invalid Input!");
            print(fe.ToString());
        }
    }
}
