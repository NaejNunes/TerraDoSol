using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoController : MonoBehaviour
{
    public static float x, y, velocidade; 

    private int vida, maxVida, direcao, milesimos, segundos;

    public GameObject[] vidaObjeto;

    private Animator animacao;

    // Start is called before the first frame update
    void Start()
    {
        //Inicia as variaveis
        velocidade = 2f;
        vida = 3;
        maxVida = 3;

        //Inicia as variaveis do tempo.
        milesimos = 60;
        segundos = 3 ;

        //Inicia o player andando.
        GerarNumero();      
    }

    // Update is called once per frame
    void Update()
    {       
        //Recebe a posição 
        x = transform.position.x;
        y = transform.position.y;

        //Chama a função do tempo.
        Tempo();

        //Movimenta o objeto
        Movimentacao();

        //Limita a area que o objeto possa andar
        

        //gera a qual direçao ira se mover
        GerarNumero();
      
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
            PlayerController.experiencia += 60f;

            Destroy(this.gameObject);         
        }

        if (transform.position.y == 10f)
        {
            velocidade = 0; 
            AndarBaixo();
        }
        if (transform.position.y == -1.5f)
        {
            velocidade = 0;

            AndarCima();
        }
        if (transform.position.x == -10f)
        {
            velocidade = 0;

            AndarDireita();
        }
        if (transform.position.x == 6f)
        {
            velocidade = 0;

            AndarEsquerda();
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

    //Metodos que recebem valores para movimentar-se
    public void AndarCima()
    {
        if (velocidade >= 1)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
           // animacao.SetInteger("Andar", 2);
          //  animacao.SetBool("Parado", false);
        }
        else if (velocidade <= 0)
        {
         //   animacao.SetBool("Parado", true);
        }
    }
    public void AndarBaixo()
    {
        if (velocidade >= 1)
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
            //animacao.SetInteger("Andar", 0);
         //  animacao.SetBool("Parado", false);
        }
        else if (velocidade <= 0)
        {
         //   animacao.SetBool("Parado", true);
        }
    }
    public void AndarEsquerda()
    {
        if (velocidade >= 1)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            //animacao.SetInteger("Andar", 3);
        //   animacao.SetBool("Parado", false);
        }
        else if (velocidade <= 0)
        {
        //    animacao.SetBool("Parado", true);
        }
    }
    public void AndarDireita()
    {
        if (velocidade >= 1)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
          // animacao.SetInteger("Andar", 1);
        //   animacao.SetBool("Parado", false);
        }
        else if (velocidade <= 0)
        {
        //    animacao.SetBool("Parado", true);
        }
    }
    public void Parado()
    {
        if (velocidade <= 0)
        {
        //   animacao.SetBool("Parado", true);
        }
    }

    //Metodo que escolhe a direção que andará
    public void Movimentacao()
    {
        switch (direcao)
        {
            case 0:
                velocidade = 2;
                AndarCima();
                break;

            case 1:
                velocidade = 2;
                AndarBaixo();
                break;

            case 2:
                velocidade = 2;
                AndarEsquerda();
                break;

            case 3:
                velocidade = 2;
                AndarDireita();
                break;

            case 4:
                velocidade = 0;
                Parado();
                break;
        }
    }

    //Limitando area para se movimentar
    
    public void GerarNumero()
    {
        //Condição para gerar um número aleatorio para se movimentar.
        if (segundos == 0)
        {
            direcao = Random.Range(0, 5);
            segundos = 3;
        }
    }
    
    //Fução que conta o tempo;
    public void Tempo()
    {
        milesimos = milesimos - 1;

        if (milesimos <= 0)
        {
            segundos = segundos - 1;
            milesimos = 60;
        }
    }
}
