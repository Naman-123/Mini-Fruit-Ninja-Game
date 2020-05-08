using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject fruitScliced;
    public float StartForce = 15f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * StartForce , ForceMode2D.Impulse);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blade")
        {
            Vector3 Direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Direction);

            GameObject SliceFruit = Instantiate(fruitScliced, transform.position, rotation);
            Destroy(gameObject);
            Destroy(SliceFruit, 4f); 
        }
    }
}
