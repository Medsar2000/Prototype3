using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObsticlePrefabs;
    public float startDelay = 2f;
    public float repeatRate = 2;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private Playercontroller playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObsticle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnObsticle()
    {
        int index = Random.Range(0, ObsticlePrefabs.Length);
        if (!playerControllerScript.isGameOver)
            Instantiate(ObsticlePrefabs[index], spawnPosition, ObsticlePrefabs[index].transform.rotation);
    }
}
