using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject fieldObject;
    public GameObject sudokuField;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 1; x < 10; x++)
        {
            for (int y = 1; y < 10; y++)
            {
                GameObject fieldObjectInstance = Instantiate(fieldObject, new Vector3(0, 0, 0f), Quaternion.identity);
                fieldObjectInstance.transform.parent = sudokuField.transform;
                fieldObjectInstance.GetComponent<FieldBehaviour>().SetMyPos(new Vector2Int(y-1, x-1));
                fieldObjectInstance.transform.position = new Vector3(-4.1f + (x-1) * 1.015f, 4.1f - (y-1) * 1.015f, 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
