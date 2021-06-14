using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;    
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * speed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if(col.CompareTag("Al"))
        {            
            //niszczy pocisk
            Destroy(gameObject);
            // zmienia obrazek
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            //niszczy obraz wybuchu kosmity po chwili
            Destroy(col.gameObject, 0.03f); //zmienic czas?

            SoundManagement.Instance.PlayOneShot(SoundManagement.Instance.alienDies);
        }
        if(col.CompareTag("Fish"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        } 
    }
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }    
}
