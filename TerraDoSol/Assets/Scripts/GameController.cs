using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Variaveis para contar o tempo
    public static int milesimos, segundos, tempoFome, tempoMana;

    // Start is called before the first frame update
    void Start()
    {
        //Iniciando as variaveis para conta de tempo.
        milesimos = 60;
        segundos = 60;
        tempoFome = 5;
        tempoMana = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Tempo();    
    }

    //Função para contar o tempo
    public static void Tempo()
    {
        milesimos = milesimos - 1;
         
        if (milesimos == 0 )
        {
            segundos = segundos - 1;

            //Controla o tempo da regeneracao da mana
            tempoMana = tempoMana - 1;
            Debug.Log(tempoMana);

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
