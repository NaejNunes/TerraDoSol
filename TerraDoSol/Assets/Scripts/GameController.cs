using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Variaveis para contar o tempo
    public static int minutos, milesimos, segundos, qtdMaximaInimigos, qtdAtualInimigos, qtdSpown, segundosDeSpown;

    private static float x, y;

    public GameObject InimgiosObjeto;

   

    // Start is called before the first frame update
    void Start()
    {
        //Iniciando as variaveis para conta de tempo.
        milesimos = 60;
        segundos = 60;       

        //Inicia a variavel de quantidade de inimigos.
        qtdAtualInimigos = 1;
        qtdMaximaInimigos = 5;
        segundosDeSpown = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Tempo();

        //Recebe a posição 
        x = transform.position.x;
        y = transform.position.y;

        //Condição que instancia o inimigo 
        if (qtdAtualInimigos < qtdMaximaInimigos && segundosDeSpown <= 0)
        {
            Instantiate(InimgiosObjeto, new Vector2(GameController.x + 3f, GameController.y + 2.5f), Quaternion.identity);
            qtdAtualInimigos = qtdAtualInimigos + 1;
            qtdSpown = Random.Range(0, 4);
        }

        if (segundosDeSpown <= 0)
        {
            segundosDeSpown = 60;
        }
        //Condicao para instanciar o inimigo 
       
        //Nao deixa spownar inimigos mais que a quantidade maxima permitida.
        if (qtdAtualInimigos >= qtdMaximaInimigos)
        {
            qtdAtualInimigos = qtdMaximaInimigos;
        }
    }

    //Função para Spownar o inimigo em tempo aleatório;
    public static void SpawnInimigos()
    {
        qtdSpown = Random.Range(0, 4);

        switch (qtdSpown)
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

    //Função para contar o tempo
    public static void Tempo()
    {
        milesimos = milesimos - 1;
         
        if (milesimos <= 0 )
        {
            segundos = segundos - 1;
            segundosDeSpown = segundosDeSpown - 1;

            milesimos = 60;
        }
        if (segundos <= 0 )
        {
            minutos = minutos - 1;
            segundos = 60;          
        }    
        
    }
}
