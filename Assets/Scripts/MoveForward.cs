using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Playercontroller playerControllerScript;
    public float speed=25;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            if(playerControllerScript.nitroMode)
            transform.Translate(Vector3.left * speed*2 * Time.deltaTime);
            else transform.Translate(Vector3.left * speed  * Time.deltaTime);
        }
        if (transform.position.x < -15 && gameObject.CompareTag("Obsticle"))
            Destroy(gameObject);
        
    }
    
}
