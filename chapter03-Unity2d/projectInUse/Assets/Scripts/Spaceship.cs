using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    //[SerializeField] private Text scoreboardText;
    [SerializeField] private Transform shotPrefab;
    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
            Instantiate(shotPrefab,
                transform.position,
                Quaternion.identity);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //scoreboardText.text = "Hit!";
        game.PlayerHit();
    }
}
