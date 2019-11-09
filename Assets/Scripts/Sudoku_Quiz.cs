using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku_Quiz : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    // the numbers array is the grid of the sudoku with the following mapping position in sequence = position on grid
    // 1 = top left ; 2 = top middle ; 3 = top right ; 4 = middle left etc.
    int[,] numbers = new int[9, 9];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Set_number(Vector2Int pos,int value)
    {
        if(numbers[pos.x, pos.y] == value)
        {
            numbers[pos.x, pos.y] = 0;
            Debug.Log(numbers[pos.x, pos.y]);
            return 0;
        }
        else
        {
            numbers[pos.x, pos.y] = value;
            return value;
        }
    }
}
