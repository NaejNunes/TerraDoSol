using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida;
    float velH, velV;
    float scaleX, scaleY, scaleZ;
    public static float X, Y;
    public static bool direcao;
    public GameObject tiro1, tiro2;
    public bool pulo;

    // Start is called before the first frame update
    void Start()
    {
        vida = 10;
        direcao = true;

        velV = 0.15f;
        velH = 0.05f;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        X = transform.position.x;
        Y = transform.position.y;

        if (Input.GetAxis("Direita") > 0)
        {
            transform.Translate(Vector3.right * velH);
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);

            direcao = true;
        }

        if (Input.GetAxis("Direita") < 0)
        {
            transform.Translate(Vector3.left * velH);
            transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);

            direcao = false;
        }
        if (Input.GetAxis("Cima") > 0)
        {
            transform.Translate(Vector3.up * velV);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && direcao == true)
        {
            Instantiate(this.tiro1, new Vector2(Player.X + 0.5f, Player.Y - 0.2f), Quaternion.identity);
        }
    } 
    private void OnCollisionEnter2D(Collision2D Pulo)
    {
        if (Pulo.gameObject.CompareTag("Pe"))
        {
            pulo = true;
        }
    }
}
