using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 startPos;
    public float offsetX = 55;
    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        offsetX = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - offsetX )
        {
            transform.position = startPos;
        }
        
    }
}
