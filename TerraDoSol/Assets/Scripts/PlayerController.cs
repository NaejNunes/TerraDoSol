using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //Variavel que da a velocidade em que o player ira andar.
    private float velocidade;

    public GameObject TabelaDoHeroi;

    // Start is called before the first frame update.
    void Start()
    {
        //Inicia a variavel para falar que está desligado.

    }

    // Update is called once per frame.
    void Update()
    {
        //Chama a funcao para movimentar o player.
        MovimentaçãoPlayer();
    }

    //Movimentação do player.
    public void MovimentaçãoPlayer()
    {
        //Função que faz a movimentação do player na direita e esquerda.
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

        CarregarTabelaDoHeroi();
    }
    //Função que carrega a tela do herois com todos os atributos do heroi.
    public void CarregarTabelaDoHeroi()
    {

        //Condição que se o botão "C" do teclado for acionbado ele abre a tela da Tabela do Herói.
        if (Input.GetKeyDown(KeyCode.C))
        {
            TabelaDoHeroi.SetActive(true);
        }
    }
}
