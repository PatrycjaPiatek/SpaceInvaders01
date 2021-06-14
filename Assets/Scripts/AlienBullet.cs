using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienBullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 30;
    public Sprite explodedShipImage;
   
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * speed;        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            SoundManagement.Instance.PlayOneShot(SoundManagement.Instance.shipExplosion);
            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;

            Destroy(gameObject);
            Destroy(col.gameObject, 0.5f);
           
            //przegrana
            Debug.Log("YouLose");
            SceneManager.LoadScene("Lose");
            GameState.score = 0;
            
        }
        if (col.tag == "Fish")
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
