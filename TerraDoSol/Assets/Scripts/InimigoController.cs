using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    private static float x, y;

    private int vida, maxVida, velocidade, direcao, milesimos, segundos;

    public GameObject[] vidaObjeto;
     
    // Start is called before the first frame update
    void Start()
    {
        //Inicia as variaveis
        velocidade = 2;
        vida = 3;
        maxVida = 3;

        //Inicia as variaveis do tempo.
        milesimos = 60;
        segundos = 1;

        //Inicia o player andando.
        direcao = Random.Range(0, 5);      
    }

    // Update is called once per frame
    void Update()
    {
        //Recebe a posição 
        x = transform.position.x;
        y = transform.position.y;

        //Chama a função do tempo.
        Tempo();

        //Sempre iguala a vida ao maximo se ela passar
        if (vida >= maxVida)
        {
            vida = maxVida;
        }

        //Ativa e desativa a imagem da vida na tela
        if (vida <= 2)
        {
            vidaObjeto[0].SetActive(false);
        }
        else if (vida == 3)
        {
            vidaObjeto[0].SetActive(true);
        }
        //____________________________________________________________________________

        if (vida <= 1)
        {
            vidaObjeto[1].SetActive(false);
        }
        else if (vida == 2)
        {
            vidaObjeto[1].SetActive(true);
        }

        //Condição para morrer       
        if (vida <= 0)
        {
            vidaObjeto[2].SetActive(false);
            GameController.qtdAtualInimigos = GameController.qtdAtualInimigos - 1;
            GameController.SpawnInimigos();

            Destroy(this.gameObject);
        }

        //Chama a função para o inimigo se movimentar
        MovimentacaoInimigo();

        //Condição para gerar um número aleatorio para se movimentar.
        if (segundos == 0)
        {
            direcao = Random.Range(0, 5);
            segundos = 3;         
        }   
    }

    public void OnTriggerEnter2D(Collider2D colisor)
    {
        //Quando colidido com a flecha, perde 1 vida.
        if (colisor.gameObject.CompareTag("FlechaDeGelo"))
        {
            vida = vida - 1;
        }
    }

    //Função para se movimentar.x
    public void MovimentacaoInimigo()
    {
        if (y >= 4)
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
        else if (y <= -1.9f)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }
        else if (x <= -6)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        else if (x >= 6)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        switch (direcao)
        {
            case 0:
                transform.Translate(Vector2.down * velocidade * Time.deltaTime);
                break;

            case 1:
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);                          
                break;

            case 2:
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);          
                break;              

            case 3:
                transform.Translate(Vector2.up * velocidade * Time.deltaTime);
                break;

            case 4:
               //Para
                break;
        }
    }

    //Fução que conta o tempo;
    public void Tempo()
    {
        milesimos = milesimos - 1;

        if (milesimos == 0)
        {
            segundos = segundos - 1;
            milesimos = 60;
        }
    }
}
