using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public Transform fruit;
    int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > 100)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), -6.4f, 3.56f);
            Transform newFruit = Instantiate(fruit, transform.position, Quaternion.identity);
            newFruit.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600);
            newFruit.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(-300,300));
            timer = 0;
        }
        
    }
}
