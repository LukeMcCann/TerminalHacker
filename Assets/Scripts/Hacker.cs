using System.Collections;
using System.Collections.Generic;
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

    private string op1 = "Huddersfield University"; // eays mode
    private string op2 = "Huddersfield Town Hall"; // medium mode
    private string op3 = "MI5 - Hidden Terminal"; // hard mode

    // Start is called before the first frame update
    void Start()
    {
        writeBanner();
        writeInstruction(this.op1, this.op2, this.op3);
    }

    private void writeBanner()
    {
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("######## Hax0r OS : 2019 ########");
        Terminal.WriteLine("###############################");
        Terminal.WriteLine("");
    }

    private void writeInstruction(string op1, string op2, string op3)
    {
        Terminal.WriteLine("Wireless Connections:");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for: " + op1);
        Terminal.WriteLine("Press 2 for: " + op2);
        Terminal.WriteLine("Press 3 for: " + op3);
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
