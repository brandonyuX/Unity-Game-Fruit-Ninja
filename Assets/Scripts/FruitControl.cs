using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitControl : MonoBehaviour
{
    float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(-2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
        if (transform.position.y < -6.5)
        {
            Destroy(transform.gameObject);
        }
    }
}
