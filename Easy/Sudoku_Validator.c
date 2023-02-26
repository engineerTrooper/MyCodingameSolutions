//https://www.codingame.com/training/puzzle/sudoku-validator

#include <stdlib.h>     //defines four variable types, several macros, and various functions for performing general functions
#include <stdio.h>      //defines three variable types, several macros, and various functions for performing input and output.
#include <string.h>     //defines one variable type, one macro, and various functions for manipulating arrays of characters.
#include <stdbool.h>    //purpose in C of this header is to add a bool type and the true and false values as macro definitions.



int comparefunc (const void * a, const void * b) {
   return ( *(int*)a - *(int*)b );
}

void validate(int *data, int length, bool *flag)
{
    for(int l = 0+1; l<length+1; l++)
    {
        if(!(l== data[l-1]))
        {
            *flag = true;
            //printf("flagstop=true;");
            break;
        }
    }
}

void printArrToConsole(int *base, int baseLength)
{
    char buf[1+1];
    for(int i = 0; i < 9; i++)
    {
        sprintf(buf, "%d", base[i]);
        printf(buf);
    }
}


int main()
{
    char buf[64+1];   //small buffer to tranform numbers to strings
    int data[9][9]; 
    int n;
    int tempArr[9];
    bool flagAnswer = false;
    bool flagStop = false;


    //Input data from stream
    for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
            scanf("%d", &n);
            //sprintf(buf, "%d", n);
            data[i][j] = n;
        }
    }


    //check row by row.
    if(flagStop != true)
    {
        for(int i = 0; i<9; i++)
        {
            for(int j = 0; j<9; j++)
            {
                tempArr[j] = data[i][j];    
            }
            qsort(&tempArr, 9, sizeof(int), comparefunc);
            validate(&tempArr[0], 9, &flagStop);
            if(flagStop == true){break;}
        }
    }


    //check column by column.
    if(flagStop != true)
    {
        for(int j = 0; j<9; j++)
        {
            for(int i = 0; i<9; i++)
            {
                tempArr[i] = data[i][j];
            }
            qsort(&tempArr, 9, sizeof(int), comparefunc);
            validate(&tempArr[0], 9, &flagStop);
            if(flagStop == true){break;}
        }
    }


    //check subgrid 3x3
    if(flagStop != true)
    {
        for(int gridY = 0; gridY<9; gridY=gridY+3)
        {
            for(int gridX = 0; gridX<9; gridX=gridX+3)
            {
                int pos = 0;
                for(int i = 0; i<3; i++)
                {
                    for(int j = 0; j<3; j++)
                    {
                        tempArr[pos] = data[gridX+i][gridY+j];
                        pos++;
                    }
                }
                qsort(&tempArr, 9, sizeof(int), comparefunc);
                validate(&tempArr[0], 9, &flagStop);
            }
        }
        
    }

    //write answer
    if(flagStop == false){flagAnswer = true;}
    if(flagAnswer == true) {
        printf("true");
    }
    else {
        printf("false");
    }
    return 0;
}