using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1;
    public float switchTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;    
        InvokeRepeating("Switch", 0, switchTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Switch() {
        GetComponent<Rigidbody2D>().velocity *= -1;    
    }
}
