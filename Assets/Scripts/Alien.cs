using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    public float speed = 10, secBeforeSpriteChange = 0.5f, minFireRateTime = 1.0f, maxFireRateTime = 3.0f, baseFireWaitTime = 3.0f;

    public Sprite startingImage, altImage, explodedShipImage;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidBody; 

    public GameObject alienBullet;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeAlienSprite());

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);    
    }

    // turn in opp
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    // move down afer hitting wall
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 2;
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        if(collision.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }
        if (collision.gameObject.name == "Bullet")
        {            
            SoundManagement.Instance.PlayOneShot(SoundManagement.Instance.alienDies);
            Destroy(gameObject);                     
        }
    }
    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(secBeforeSpriteChange);

            if (spriteRenderer.sprite == startingImage)
            {
                //zmien obrazek
                spriteRenderer.sprite = altImage;
            }
            else
            {
                //nie zmieniaj bo jest ok
                spriteRenderer.sprite = startingImage;

                SoundManagement.Instance.PlayOneShot(
                 SoundManagement.Instance.alienBuzz2
                );
            }
        }
    }
    void Update()
    {
        //metoda zeby czas sie liczyl od poczatku tej sceny
        if (Time.timeSinceLevelLoad > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Debug.Log("trafiony");
            GameState.score += 5;
        }
        if(col.gameObject.tag == "Player")
        {
            SoundManagement.Instance.PlayOneShot(SoundManagement.Instance.shipExplosion);
            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);
            //niszczy statek po chwili
            Destroy(col.gameObject, 0.5f);
        }
    }
}
