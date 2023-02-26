//https://www.codingame.com/training/puzzle/7-segment-scanner

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        const int LETTER_WIDTH = 3;
        const int REF_CHAR_COUNT = 10;
        const int DISPLAY_HEIGHT = 3;

        DisplayInput displayInput = new DisplayInput(LETTER_WIDTH, REF_CHAR_COUNT, DISPLAY_HEIGHT);

        List<string> input = new List<string>();
        input.Add(Console.ReadLine());
        input.Add(Console.ReadLine());
        input.Add(Console.ReadLine());
        Console.WriteLine(displayInput.ConvertToNumbers(input));
    }
}


public class DisplayInput
{
    private List<string> RefListHori = new List<string>();
    private List<string> RefListVert = new List<string>();

    private int LetterWidth;
    private int RefCharCount;
    private int DisplayHeight;



    public DisplayInput(int letterWidth, int charCount, int displayHeight)
    {
        RefListHori.Add(" _     _  _     _  _  _  _  _ ");
        RefListHori.Add("| |  | _| _||_||_ |_   ||_||_|");
        RefListHori.Add("|_|  ||_  _|  | _||_|  ||_| _|");

        this.LetterWidth = letterWidth;
        this.RefCharCount = charCount;
        this.DisplayHeight = displayHeight;

        RefListVert.AddRange(new string[charCount]);
        RefListVert = ConvertToVertical(RefListHori);
    }

    public List<string> ConvertToVertical(List<string> container)
    {
        List<string> verti = new List<string>();
        int countChars = container[0].Length/LetterWidth;
        verti.AddRange(new string[countChars]);
        for(int j = 0; j < DisplayHeight; j++) 
        {
            //Console.WriteLine("j = " + j);
            for(int i = 0; i < container[j].Length ; i += LetterWidth)
            {
                //Console.WriteLine("i = " + i);                
                verti[(i/LetterWidth)] = verti[i/LetterWidth] + container[j].Substring(i,LetterWidth);
                //Console.WriteLine(container[j].Substring(i,LetterWidth));
                //Console.WriteLine(verti[(i/LetterWidth)]);
            }
        }
        return verti;
    }


    public string ConvertToNumbers(List<string> input)
    {
        List<string> inputVert = ConvertToVertical(input);
        string converted = "";

        foreach(string k in inputVert)
        {
            converted = converted + RefListVert.IndexOf(k);
        }

        return converted;
    }
}