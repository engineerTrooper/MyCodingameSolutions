//https://www.codingame.com/training/puzzle/ascii-art


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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpper();

        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";

        string[,] myArr = new String[H,27];

        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            for (int j = 0; j < 27; j = j + 1){
                if(j < 27) {
                    myArr[i,j] = ROW.Substring(j*L, L);
                }
            }
        }

        for(int k = 0; k < H; k++){
        for(int i = 0; i < T.Length; i++)
        {
            int found = 0;
            if(alpha.Contains(T[i])){
                found = alpha.IndexOf(T[i]);
            }
            else{
                found = 26;
            }
            Console.Write(myArr[k, found]);
        }
        Console.WriteLine();
        }
    }
}