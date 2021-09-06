using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public Transform target;
    public GameObject spawnPoint;
    public GameObject obstacle;
    public GameObject obstacle2;
    public GameObject ground;
    float spawnTime = 1f;
    float lastSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateSpawnTime();
    }

    void updateSpawnTime(){
        lastSpawnTime = Time.time;
    }

    void Spawn(){
        Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y+15, transform.position.z), Quaternion.identity);
        Instantiate(obstacle2, new Vector3(transform.position.x, transform.position.y+3, transform.position.z), Quaternion.identity);

        Instantiate(ground, spawnPoint.transform.position, Quaternion.identity);
        updateSpawnTime();
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x + 5, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastSpawnTime + spawnTime && Vector3.Distance(target.position, transform.position) < 1000){
            Spawn();
        }
    }
}
