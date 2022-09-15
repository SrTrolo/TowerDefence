using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i > -10; i--)
        {
            GameObject newQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            newQuad.transform.position = new Vector2(i, i);
        }
        
    }
    private void CheckInfo()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
