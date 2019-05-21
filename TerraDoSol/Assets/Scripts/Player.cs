using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida;
    public float VelocidadePlayer, forcaPulo;
    float scaleX, scaleY, scaleZ;
    public static float X, Y;
    public static bool direcao;
    public GameObject tiro1;

    // Start is called before the first frame update
    void Start()
    {
        vida = 10;      
      
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        X = transform.position.x;
        Y = transform.position.y;

        //Faz a Movimentação do player
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * VelocidadePlayer * Time.deltaTime);
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * VelocidadePlayer * Time.deltaTime);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            transform.Translate(Vector3.up * forcaPulo);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(this.tiro1, new Vector2(Player.X + 0.5f, Player.Y - 0.2f), Quaternion.identity);
        }
    }    
}
