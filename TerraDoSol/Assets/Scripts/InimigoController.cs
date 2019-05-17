using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    private int vida, maxVida, velocidade, direcao, milesimos, segundos, qtsSpown, segundosDeSpown, qtdMaximaInimigos, qtdAtualInimigos;

    public GameObject[] vidaObjeto;

    public GameObject InimgiosObjeto;
    
    private static float x, y;

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
        direcao = Random.Range(0, 6);

        //Inicia a variavel de quantidade de inimigos.
        qtdAtualInimigos = 1;

        qtdMaximaInimigos = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Recebe a posição 
        x = transform.position.x;
        y = transform.position.y;

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

        //Recebe um tempo aleatorio
        if (milesimos == 0)
        {
            segundosDeSpown = Random.Range(1, 5);
        }
        //Condição para gerar um número aleatorio para se movimentar.
        if (segundos == 0)
        {
            direcao = Random.Range(0, 4);
            segundos = 3;         
        }

        //Condicao para instanciar o inimigo 
        if (segundosDeSpown == 0)
        {
            if (qtdAtualInimigos < qtdMaximaInimigos)
            {
                Instantiate(this.InimgiosObjeto, new Vector2(InimigoController.x + 3f, InimigoController.y + 2.5f), Quaternion.identity);
                qtdAtualInimigos = qtdAtualInimigos + 1;
            }            
        }

        //Nao deixa spownar inimigos mais que a quantidade maxima permitida.
        if (qtdAtualInimigos >= qtdMaximaInimigos)
        {
            qtdAtualInimigos = qtdMaximaInimigos;
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

        Debug.Log(direcao);
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

    public void SpawrInimigos()
    {
        qtsSpown = Random.Range(0, 4);

        switch (qtsSpown)
        {
            case 0:
                segundosDeSpown = 10;
                break;

            case 1:
                segundosDeSpown = 30;
                break;

            case 2:
                segundosDeSpown = 40;
                break;

            case 3:
                segundosDeSpown = 60;
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
