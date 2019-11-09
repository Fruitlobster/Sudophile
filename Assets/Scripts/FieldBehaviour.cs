using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    public GameObject smallgrid;
    public GameObject smallgridInstance;
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
        // OnMouseDown
        if (Input.GetMouseButtonDown(0))
        {
            if(smallgridInstance == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                if (hit.collider != null && hit.collider.tag == "SudokuField")
                {
                    smallgridInstance = Instantiate(smallgrid, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.75f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.75f, 0), Quaternion.identity);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                if (hit.collider != null && hit.collider.tag == "SelectiveNumber")
                {
                    int value = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().Set_number(mypos, hit.collider.GetComponent<SelectiveBehavior>().mynumber);
                    ChangeSprite(value);
                    Destroy(smallgridInstance);
                }
                else
                {
                    Destroy(smallgridInstance);
                }
                
            }

        }
    }
    //Event on Mouse Down
    void ChangeSprite(int number)
    {
        switch (number)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().one;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().two;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().three;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().four;
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().five;
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().six;
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().seven;
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().eight;
                break;
            case 9:
                GetComponent<SpriteRenderer>().sprite = transform.parent.parent.gameObject.GetComponent<Sudoku_Quiz>().nine;
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = null;
                break;
        }
    }
}
