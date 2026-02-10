using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float vel;
    public int dano;
    public float vida;
    public Rigidbody2D rb2d;
    public Transform psa;
    public Transform psb;
    public bool chegou;
    public float dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(vel, rb2d.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Md()
    {
        dir *= -1;
        rb2d.velocity = new Vector2( vel*dir, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("md"))
        {
           
            Md();
        }
    }
}