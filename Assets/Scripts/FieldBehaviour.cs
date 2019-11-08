using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehaviour : MonoBehaviour
{
    public GameObject smallgrid;
    public GameObject smallgridInstance;
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
                    //smallgridInstance = Instantiate(smallgrid, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.75f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.75f, 0), Quaternion.identity);

                }
                Destroy(smallgridInstance);
            }

        }
    }
    //Event on Mouse Down
    void onMouseDown()
    {

    }
}
