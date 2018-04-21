using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    private float speed = -0.2f;

    private float deadLine = -10;

    // Use this for initialization
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(this.speed, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CubeTag" || col.gameObject.tag == "GroundTag")
        { 
            GetComponent<AudioSource>().Play();
        }

    }

}

