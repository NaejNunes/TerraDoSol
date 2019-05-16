using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Variaveis para contar o tempo
    public static int milesimos, segundos, minutos;

    // Start is called before the first frame update
    void Start()
    {

        //Iniciando as variaveis para conta de tempo.
        milesimos = 60;
        segundos = 60;
        minutos = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
             
    }

    //Função para contar o tempo
    public static void Tempo(int milesimos, int segundos, int minutos)
    {
        milesimos = milesimos - 1;
         
        if (milesimos <= 1)
        {
            segundos = segundos - 1;
            milesimos = 60;
        }
        if (segundos <= 1)
        {
            minutos = minutos - 1;
            segundos = 60;
        }
    }
}
