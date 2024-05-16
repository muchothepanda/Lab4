using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Text;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player; 
    private Transform current;
    private Rigidbody2D rb;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    
    private void Movement()
    {

       
        Vector2 point = current.position - transform.position;
        if (current == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0);

        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, current.position) < 0.5f && current == pointB.transform)
        {
            current = pointA.transform;
           
        }
        if (Vector2.Distance(transform.position, current.position) < 0.5f && current == pointA.transform)
        {
            current = pointB.transform;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hitp");
            Destroy(player);
            Text.SetActive(true);
        }
        
    }

    
}
