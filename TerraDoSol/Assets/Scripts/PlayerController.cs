using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentaçãoPlayer();
    }

    //Movimentação do player
    public void MovimentaçãoPlayer()
    {
        //Movimentção do player na direita e esquerda
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        //Movimentação do player para cima e baixo.
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }
}
