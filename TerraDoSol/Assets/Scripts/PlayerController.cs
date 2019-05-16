using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //Variavel que da a velocidade em que o player ira andar.
    public float velocidade;

    
    [SerializeField]
    //Variavel para atribuir as vidas do player
    public static int vida, maxVida, fome;

    //Variavel para lincar a tabela de atributos do player
    public GameObject TabelaDoHeroi;

    //Variavel que liga o texto da vida na tabela do heroi.
    public Text txtVida, txtFome;

    // Start is called before the first frame update.
    void Start()
    {
        vida = 3;
        maxVida = 3;
        fome = 10;
    }

    // Update is called once per frame.
    void Update()
    {
        //Chama a funcao para movimentar o player.
        MovimentaçãoPlayer();

        txtVida.text = "" + vida + "/" + maxVida;

        txtFome.text = "" + fome + "/" + "10";
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

    //Detecta a colisao com algo solido em cena
    public void OnCollisionEnter2D(Collision2D colidir)
    {

        //Condição para checar se o player colidiu com o inimigo e tirar 1 de vida.
        if (colidir.gameObject.CompareTag("Inimigo"))
        {
            vida = vida - 1;
        }
    }
}
