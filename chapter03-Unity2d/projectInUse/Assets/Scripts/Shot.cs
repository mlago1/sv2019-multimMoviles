using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] float shotSpeed = 100;
    [SerializeField] private Transform explosionPrefab;
    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameController>();
        gameObject.GetComponent<Rigidbody2D>().
            velocity = new Vector2(0, shotSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            game.EnemyHit();
            Transform explosion = Instantiate(explosionPrefab,
                transform.position,
                Quaternion.identity);
            Destroy(explosion.gameObject, 1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
