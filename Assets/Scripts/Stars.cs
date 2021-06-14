using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public GameObject theBullet;   
    public float positionY, positionX;
    public float speed = 30;

    void Start()
    {
        Vector2 ve = new Vector2(0.06f, 0.06f);
        theBullet.GetComponent<Transform>().localScale = ve;
    }

    void Update()
    {
        positionX = Random.Range(-400, 1200);
        positionY = Random.Range(0, 500);

        Vector2 temp = new Vector2(positionX, positionY);
       
        //theBullet.GetComponent<Renderer>().sortingLayerName = "Default";
        Instantiate(theBullet, temp, Quaternion.identity);
    }
}
