using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public float speed = 30;
    public GameObject theBullet;
    public float timer;
    //public float time;
    //public AudioClip bulletFire;

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }
   
   async void Update()
   { 
        //odstep pomiedzy pociskami
        StartCoroutine(Wait());
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        textUIComp.text = GameState.score.ToString();

        if (Input.GetButtonDown("Jump"))
        {
            InsBullet();
            //odstep pomiedzy pociskami
            StartCoroutine(Wait());
        }
        if (GameState.score==200)
        {
            Debug.Log("YouWon");
            SceneManager.LoadScene("Won");
            GameState.score = 0;
            //////////////////////////////////////
            Player.time = Time.timeSinceLevelLoad;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }    
    IEnumerator Wait()
    {        
        yield return new WaitForSeconds(timer);
    }
    public void InsBullet()
    {
        Instantiate(theBullet, transform.position, Quaternion.identity);
        SoundManagement.Instance.PlayOneShot(SoundManagement.Instance.bulletFire);
    }    
}
