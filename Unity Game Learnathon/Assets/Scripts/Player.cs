using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 targetPos;
    public float Moveup;
    public float speed;
    public float heightMax;
    public float heightMin;
    public int health;
    public Text healthDisplay;
    public GameObject upEffect; // the movement up/down particle effect
    public GameObject downEffect;
    public GameObject gameOver;
    //public GameObject gameStart;

    private void Update()
    {
        //gameStart.SetActive(true);

        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime); // do we need deltaTime? Small group, not widely distributed. :) 

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < heightMax)
        {
            Instantiate(upEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Moveup);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > heightMin)
        {
            Instantiate(downEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Moveup);
        }
    }

    // Update is called once per frame

}
