using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BuildSudoku;
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
    public GameObject smallgrid;
    private GameObject smallgridInstance;
    private GameObject currentField;
    // the numbers array is the grid of the sudoku with the following mapping position in sequence = position on grid
    // 1 = top left ; 2 = top middle ; 3 = top right ; 4 = middle left etc.
    int[,] numbers = new int[9, 9];
    // Start is called before the first frame update
    void Start()
    {
        int[] grid = BuildSudoku.Build();
        GameObject[] fields = GameObject.FindGameObjectsWithTag("SudokuField");
        for(int i=0; i<fields.Length;i++){
            fields[i].GetComponent<FieldBehaviour>().ChangeSprite(grid[i]);
        }
        
        
        //initialize numbers array
        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                numbers[i, j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // OnMouseDown
        if (Input.GetMouseButtonDown(0))
        {
            if (smallgridInstance == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                currentField = hit.collider.gameObject;
                if (currentField != null && currentField.tag == "SudokuField")
                {
                    smallgridInstance = Instantiate(smallgrid, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.75f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.75f, 0), Quaternion.identity);
                    Debug.Log(currentField.GetComponent<FieldBehaviour>().mypos);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                if (hit.collider != null && hit.collider.tag == "SelectiveNumber")
                {
                    int value = Set_number(currentField.GetComponent<FieldBehaviour>().mypos, hit.collider.GetComponent<SelectiveBehavior>().mynumber);
                    currentField.GetComponent<FieldBehaviour>().ChangeSprite(value);
                    Destroy(smallgridInstance);
                }
                else
                {
                    Destroy(smallgridInstance);
                }

            }
        }
    }

    public int Set_number(Vector2Int pos,int value)
    {
        if(numbers[pos.x, pos.y] == value)
        {
            numbers[pos.x, pos.y] = 0;
            return 0;
        }
        else
        {
            numbers[pos.x, pos.y] = value;
            return value;
        }
    }
}
