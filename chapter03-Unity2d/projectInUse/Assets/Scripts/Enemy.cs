using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speedX = 3;
    private float speedY = 3;
    private float shotSpeed = 100;
    [SerializeField] Transform shotPrefab;

    private void Start()
    {
        StartCoroutine( Shoot() );
    }

    void Update()
    {
        if (transform.position.x < -5 || transform.position.x > 5)
            speedX = -speedX;
        if (transform.position.y < -3 || transform.position.y > 3)
            speedY = -speedY;
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    IEnumerator Shoot()
    {
        float pause = Random.Range(3.0f, 8.0f);
        yield return new WaitForSeconds(pause);
        Transform shot = Instantiate(shotPrefab, 
            transform.position, Quaternion.identity);
        shot.gameObject.GetComponent<Rigidbody2D>().velocity = 
            new Vector3(0, -shotSpeed*Time.deltaTime, 0);
        Destroy(shot.gameObject, 3);
        StartCoroutine(Shoot());
    }
}
