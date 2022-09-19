//https://www.codingame.com/ide/puzzle/logic-gates

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;



class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        LogicGates logicGates = new LogicGates();

         Dictionary<string, InputSignal> dicInputs = new Dictionary<string, InputSignal>();
         Dictionary<string, OutputSignal> dicOutputs = new Dictionary<string, OutputSignal>();


        string[] inputs;
        
        for (int i = 0; i < n; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            dicInputs.Add(inputs[0], new InputSignal(inputs[0],inputs[1]));
        }
        for (int i = 0; i < m; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            dicOutputs.Add(inputs[0], new OutputSignal(inputs[0], inputs[1], inputs[2], inputs[3]));
        }

        foreach(var entry in dicOutputs)
        {
            //Console.WriteLine(entry.Value.TypeLogicGate);
            //Console.WriteLine(dicInputs[entry.Value.FirstNameInput].Signal);
            //Console.WriteLine(dicInputs[entry.Value.SecondNameInput].Signal);

            Console.WriteLine(entry.Value.Name + " "+ logicGates.Organizer(entry.Value.TypeLogicGate, 
                                dicInputs[entry.Value.FirstNameInput].Signal, 
                                dicInputs[entry.Value.SecondNameInput].Signal));
        }


    }
}

public class InputSignal
{
    public InputSignal(string name, string signal)
    {
        this.Name = name;
        this.Signal = signal;
    }

    public string Name;
    public string Signal;
}

public class OutputSignal
{
    public OutputSignal(string name, string typeLogicGate, string firstInputName, string secondInputName)
    {
        this.Name = name;
        this.TypeLogicGate = typeLogicGate;
        this.FirstNameInput = firstInputName;
        this.SecondNameInput = secondInputName;
    }

    public string Name;
    public string TypeLogicGate;
    public string FirstNameInput;
    public string SecondNameInput;
}

public class LogicGates
{

    public string Organizer(string typeLogicGate, string inputOne, string inputTwo)
    {
        string data = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        // inputOne = transformer.ToNumbers(inputOne);
        // inputTwo = transformer.ToNumbers(inputTwo);

        switch (typeLogicGate)
        {
            case "AND":
                data = And(inputOne, inputTwo);
                break;
            case "OR":
                data = Or(inputOne, inputTwo);
                break;
            case "XOR":
                data = Xor(inputOne, inputTwo);
                break;
            case "NAND":
                data = Nand(inputOne, inputTwo);
                break;
            case "NOR":
                data = Nor(inputOne, inputTwo);
                break;
            case "NXOR":
                data = Nxor(inputOne, inputTwo);
                break;


            default:
                Console.WriteLine("Name of Gate *" + typeLogicGate + "* not found.");
                data = "null";
                break;
        }
        //Console.WriteLine(data);
        return data;
    }

    public string And(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if(inputOne[i] == inputTwo[i] &&
                inputOne[i] != '_' &&
                inputTwo[i] != '_')
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }

    public string Or(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if(inputOne[i] == '-' ||
                inputTwo[i] == '-')
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }

    public string Xor(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if((inputOne[i] == '_' && inputTwo[i] == '-') ||
                (inputOne[i] == '-' && inputTwo[i] == '_'))
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }

    public string Nand(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if((inputOne[i] == '_' && inputTwo[i] == '_') ||
                (inputOne[i] == '_' && inputTwo[i] == '-') ||
                (inputOne[i] == '-' && inputTwo[i] == '_')) 
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }

        public string Nor(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if(!(inputOne[i] == '-' ||
                inputTwo[i] == '-'))
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }

    public string Nxor(string inputOne, string inputTwo)
    {
        string output = "";

        // Console.WriteLine(inputOne);
        // Console.WriteLine(inputTwo);

        for(int i = 0; i < inputOne.Length; i++)
        {
            if((inputOne[i] == '-' && inputTwo[i] == '-') ||
                (inputOne[i] == '_' && inputTwo[i] == '_'))
                {
                    output += ("-");
                }
                else
                {
                     output += ("_");
                }
            //Console.WriteLine(output);
        }
        return output;
    }
}