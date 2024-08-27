using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KnifeControl : MonoBehaviour
{
    public Transform splash;
    public Transform fruit_top;
    public Transform fruit_bottom;
    public TMP_Text score_txt;
    public Transform explosion_effect;
    private bool isTouch;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchSupported)
        {
            isTouch = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch) 
        {
            Vector3 knifePos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(knifePos);
            transform.position = worldPos;
        }
        else
        {
            Vector3 knifePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(knifePos);
            transform.position = worldPos;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "fruit")
        {
            score++;
            score_txt.text = score.ToString();
            Destroy(collision.gameObject);
            Transform newSplash = Instantiate(splash, collision.transform.position, Quaternion.identity);
            Transform halfFruit_first = Instantiate(fruit_top, collision.transform.position, Quaternion.identity);
            halfFruit_first.GetComponent<Rigidbody2D>().AddForce(Vector3.left*400);
            Transform halfFruit_second = Instantiate(fruit_bottom, collision.transform.position, Quaternion.identity);
            halfFruit_second.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 400);
            Destroy(newSplash.gameObject, 5);
        }
        if (collision.transform.tag == "bomb")
        {
            score = score -2;
            score_txt.text = score.ToString();
            Destroy(collision.gameObject);
            Transform newExplode = Instantiate(explosion_effect, collision.transform.position, Quaternion.identity);
            Destroy(newExplode.gameObject, 3);
        }
    }
}
