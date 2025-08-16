using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
               timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y-heightOffset;
        float heightPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,heightPoint),0), transform.rotation);
    }
}
