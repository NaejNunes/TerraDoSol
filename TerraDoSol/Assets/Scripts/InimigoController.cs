using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    private int vida, maxVida, velocidade, numero, milesimos, segundos;

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
        segundos = 10;

        //Inicia o player andando.
        numero = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(segundos + "/" + milesimos);
        //Chama a função do tempo.
        Tempo();

        //Chama a função para o inimigo se movimentar
        MovimentacaoInimigo();

        //Sempre iguala a vida ao maximo se ela passar do maximo
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

            Destroy(this.gameObject);
        }

        //Condição para gerar um número aleatorio para se movimentar.
        if (segundos == 0)
        {
            numero = Random.Range(0, 4);
            segundos = 10;
            Debug.Log(numero);
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
                  
        switch (numero)
        {
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
                transform.Translate(Vector2.down * velocidade * Time.deltaTime);            
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
