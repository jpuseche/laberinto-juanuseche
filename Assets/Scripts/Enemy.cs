using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Move", 0f, 2f);
    }

    // Update is called once per frame
    void Move()
    {
        float step = speed * Time.deltaTime;
        Vector2 next = BoardManager.Instance.nextStep((int)transform.position.x, (int)transform.position.y, (int)player.transform.position.x, (int)player.transform.position.y);
        Debug.Log(next);
        transform.position = next;
    }
}
