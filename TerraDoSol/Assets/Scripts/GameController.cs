using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Variaveis para contar o tempo
    public static int milesimos, segundos, tempoFome;

    // Start is called before the first frame update
    void Start()
    {

        //Iniciando as variaveis para conta de tempo.
        milesimos = 60;
        segundos = 60;
        tempoFome = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        Tempo();

        Debug.Log(tempoFome + "/" + segundos);
    }

    //Função para contar o tempo
    public static void Tempo()
    {
        milesimos = milesimos - 1;
         
        if (milesimos == 0)
        {
            segundos = segundos - 1;
            milesimos = 60;
        }
        if (segundos == 0 )
        {
            //Controla o tempo de fome
            tempoFome = tempoFome - 1;
            segundos = 60;
        }
    }
}
