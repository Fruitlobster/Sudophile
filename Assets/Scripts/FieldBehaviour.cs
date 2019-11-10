using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    public Vector2Int mypos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Camera.main.ScreenPointToRay(Input.mousePosition)
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
 
    }
    public void SetMyPos(Vector2Int number)
    {
        mypos = number;
    }
    public void ChangeSprite(int number)
    {
        switch (number)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().one;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().two;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().three;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().four;
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().five;
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().six;
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().seven;
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().eight;
                break;
            case 9:
                GetComponent<SpriteRenderer>().sprite = transform.parent.gameObject.GetComponent<Sudoku_Quiz>().nine;
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = null;
                break;
        }
    }
}
