using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Quiz : MonoBehaviour
{
    // the numbers array is the grid of the sudoku with the following mapping position in sequence = position on grid
    // 1 = top left ; 2 = top middle ; 3 = top right ; 4 = middle left etc.
    int[] numbers = new int[9];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Set_number(int pos,int value)
    {
        if(numbers[pos] == value)
        {
            numbers[pos] = 0;
        }
        else
        {
            numbers[pos] = value;
        }
    }
}
