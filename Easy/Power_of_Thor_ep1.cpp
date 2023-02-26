//https://www.codingame.com/training/puzzle/power-of-thor-episode-1

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
int main()
{
    int lightX; 
    int lightY; 
    int initialTX; 
    int initialTY; 
    cin >> lightX >> lightY >> initialTX >> initialTY; cin.ignore();

    int thorX = initialTX;
    int thorY = initialTY;
    
    string x = "";
    string y = "";

    // game loop
    while (1) {
        int remainingTurns;
        cin >> remainingTurns; cin.ignore();

        string directionX = "";
        string directionY = "";

        if (thorX > lightX) {
            directionX = "W";
            thorX--;
        } else if (thorX < lightX) {
            directionX = "E";
            thorX++;
        }
        
        if (thorY > lightY) {
            directionY = "N";
            thorY--;
        } else if (thorY < lightY) {
            directionY = "S";
            thorY++;
        }
        
        cout << directionY << directionX << endl;
    }
            
    
}