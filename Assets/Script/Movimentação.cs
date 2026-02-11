using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Andar : MonoBehaviour

{

    public float velocidade;

    public Vector2 dir;

    public Rigidbody2D rb2d;

    public float JumpForce;

    public bool chao;

    public int vida;

    public int coins=0;

    public TextMeshProUGUI TextoMoedas;

    public TextMeshProUGUI vidatexto;

    // Start is called before the first frame update

    void Start()

    {
        TextoMoedas.text = "Coins : " + coins;
        vidatexto.text = "Vidas :" + vida;
    }

    // Update is called once per frame

    void Update()

    {

        if (Input.GetKey(KeyCode.D))

        {

            dir = new Vector2(+1 * velocidade, rb2d.velocity.y);


        }

        else if (Input.GetKey(KeyCode.A))

        {

            dir = new Vector2(-1 * velocidade, rb2d.velocity.y);

    

        }

        else

        {

            dir = new Vector2(0 * velocidade, rb2d.velocity.y);

        }

        dir = new Vector2(dir.x, rb2d.velocity.y);

        rb2d.velocity = dir;

        if (Input.GetKeyDown(KeyCode.W))

        {
            if (chao == true)
            {
                rb2d.AddForce(new Vector2(rb2d.velocity.x, JumpForce));
              
            }
        }

 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            chao = true;

        }
        else if (collision.gameObject.CompareTag("inimigo"))
        {
            TmDano(collision.gameObject.GetComponent<Inimigo>().dano);
            Destroy(collision.gameObject);
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            chao = false;
            
        }
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.gameObject.CompareTag("coin"))
        {
            coins = coins + 1;
            Destroy(collision.gameObject);
            TextoMoedas.text = "Coins : " + coins;
        }
    }
    public void TmDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            vidatexto.text = "Vidas : " + vida;
        }
        else
        {
            vidatexto.text = "Vidas :"+ vida;
        }
    }


}



