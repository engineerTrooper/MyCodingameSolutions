//https://www.codingame.com/ide/puzzle/snail-run

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
        const int MAX_FIELD_SIZE = 99;

        int numberSnails = int.Parse(Console.ReadLine());
        int[] speedSnails = new int[numberSnails];
        int[,] locSnails = new int[numberSnails, 2];    // { X , Y } Coords
        int[,] distGoalToSnail = new int [numberSnails, 2];     // { X , Y } Coords
        int[] distGoalToSnail2 = new int[numberSnails];     // { X , Y } Coords
        

        //Collect Snail Speed
        for (int i = 0; i < numberSnails; i++)
        {
            int speedSnail = int.Parse(Console.ReadLine());
            speedSnails[i] = speedSnail;
            //Console.WriteLine("speed: " + speedSnails[i]);
        }

        //Collect Map 
        int mapHeight = int.Parse(Console.ReadLine());
        int mapWidth = int.Parse(Console.ReadLine());
        int[,] locGoals = new int[mapHeight,2];

        string[] rows = new string[mapHeight];
        for (int i = 0; i < mapHeight; i++)
        {
            string ROW = Console.ReadLine();
            rows[i] = ROW;
            //Console.WriteLine(ROW);
        }


        
        //Find snails in map
        for (int i = 0; i < numberSnails; i++)
        {
            for(int j = 0; j < mapHeight; j++)
            {
                int snail = i + 1;
                string strSnail = Convert.ToString(snail);
                //Console.WriteLine(strSnail[0]);
                //Console.WriteLine(rows[j].Contains(strSnail[0]));
                if(rows[j].Contains(strSnail[0]))
                {
                    locSnails[i, 1] = rows[j].IndexOf(strSnail[0]);
                    locSnails[i, 0] = j;
                    //Console.WriteLine("locSnail " + i + "   X: " + locSnails[i,0] + " |  Y: " + locSnails[i,1]);
                }
                else
                {
                    //Console.WriteLine("not found");
                }
            }
        }



        //Find Goals
        for(int j = 0; j < mapHeight; j++)
        {
            if(rows[j].Contains('#'))
            {
                locGoals[j,1] = rows[j].IndexOf('#');
                locGoals[j,0] = j;
            }
            else
            {
                locGoals[j,1] = MAX_FIELD_SIZE +1;
                locGoals[j,0] = MAX_FIELD_SIZE +1;
            }
            //Console.WriteLine("Goal: " + "   X: " + locGoals[j,0] + " |  Y: " + locGoals[j,1]);
        }


        

        //set goal to snail distances to {0,0}
        for(int i = 0; i < numberSnails; i++)
        {
            distGoalToSnail[i,0] = MAX_FIELD_SIZE +1;
            distGoalToSnail[i,1] = MAX_FIELD_SIZE +1;

            distGoalToSnail2[i] = MAX_FIELD_SIZE +1;
        }



        //find closest finish line for each snail
        for(int i = 0; i < numberSnails; i++)
        {
            int sumDist = 0;
            //Console.WriteLine("Search for Snail: " + i);

            for(int j = 0; j < (locGoals.Length/2); j++)
            {
                //jump to next if Goals coordinates = MAX_FIELD_SIZE +1
                if(locGoals[j,0] == (MAX_FIELD_SIZE +1) && locGoals[j,1] == (MAX_FIELD_SIZE +1)) { continue; }

                //Calculation
                int distX = 0;
                int distY = 0;

                //case if goal coordinates bigger then snail coordinates then

                    //X
                    if(locGoals[j,0] > locSnails[i,0])
                    {
                        distX = locGoals[j,0] - locSnails[i,0];
                        //Console.WriteLine("distX = " + locGoals[j,0] + " - " + locSnails[i,0] + " = " + distX);
                    }
                    else if (locGoals[j,0] == locSnails[i,0])
                    {
                        distX = 0;
                        //Console.WriteLine("distX = 0");
                    }
                    else
                    {
                        distX = locSnails[i,0] - locGoals[j,0];
                        //Console.WriteLine("distX = " + locSnails[i,0] + " - " + locGoals[j,0] + " = " + distX);
                    }

                    //Y
                    if(locGoals[j,1] > locSnails[i,1])
                    {
                        distY = locGoals[j,1] - locSnails[i,1];
                        //Console.WriteLine("distY = " + locGoals[j,1] + " - " + locSnails[i,1] + " = " + distY);
                    }
                    else if(locGoals[j,1] == locSnails[i,1])
                    {
                        distY = 0;
                        //Console.WriteLine("distY = 0");
                    }
                    else
                    {
                        distY = locSnails[i,1] - locGoals[j,1];
                        //Console.WriteLine("distY = " + locGoals[j,1] + " - " + locSnails[i,1] + " = " + distY);
                    }

                //set new distance, if smaller
                sumDist = distX + distY;
                //Console.WriteLine(distX + " - " + distY + " = " + sumDist);
                if(distGoalToSnail2[i] > sumDist) 
                {
                    //Console.WriteLine("Snail: " + i + "    Old Dist: " + distGoalToSnail2[i]);
                    distGoalToSnail2[i] = sumDist;
                    //Console.WriteLine("Snail: " + i + "    New Dist: " + sumDist);
                }
            }
        }



        //calc: who is the fastest snail?
        int winner = 0;

        double[,] results = new double[numberSnails,2];

        for(int i = 0; i < distGoalToSnail2.Length; i++)
        {
            results[i,0] = Convert.ToDouble(i);
            results[i,1] = Convert.ToDouble(distGoalToSnail2[i]) / Convert.ToDouble(speedSnails[i]);
            //Console.WriteLine("Snail " + results[i,0] + " needs " + results[i,1]);
        }

        for(int i = 0; i < (results.Length/2 - 1); i++)
        {
            //Console.WriteLine("Compare Snail " + i + " and Snail " + (i+1));
            if(results[winner,1] >= results[i+1,1])
            {
                winner = i + 1;
                //Console.WriteLine("Winner is: " + winner);
            }
        }

        //Print winner snail
        Console.WriteLine(winner + 1);
    }
}