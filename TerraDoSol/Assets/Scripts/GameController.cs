using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Variaveis para contar o tempo
    public static int milesimos, segundos, tempoVida, tempoMana, tempoFome, tempoSede;

    // Start is called before the first frame update
    void Start()
    {
        //Iniciando as variaveis para conta de tempo.
        milesimos = 60;
        segundos = 60;       
        tempoVida = 60;
        tempoMana = 20;
        tempoFome = 6;
        tempoSede = 3;
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

            //Controla o tempo da regeneracao da vida
            tempoVida = tempoVida - 1;

            //Controla o tempo da regeneracao da mana
            tempoMana = tempoMana - 1;

            milesimos = 60;
        }
        if (segundos == 0 )
        {
            //Controla o tempo de fome
            tempoFome = tempoFome - 1;

            //Controla o tempo de sede
            tempoSede = tempoSede - 1;

            segundos = 60;          
        }           
    }
}
