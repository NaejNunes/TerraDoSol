using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayerController : MonoBehaviour
{
    //Liga o objeto vida no script
    public GameObject[] vida, mana;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Chama o Método para contar o tempo.
        GameController.Tempo();


        //Condição para Aumentar a mana.
        if (PlayerController.tempoMana == 0)
        {
            PlayerController.mana = PlayerController.mana + 1;
            PlayerController.tempoMana = 20;
        }

        //Condição para diminuir a fome.
        if (PlayerController.tempoFome <= 1 && GameController.segundos <= 1)
        {
            PlayerController.fome = PlayerController.fome - 1;
            PlayerController.tempoFome = 6;
        }

        //Condição para diminuir a sede.
        if (PlayerController.tempoSede <= 1 && GameController.segundos <= 1)
        {
            PlayerController.sede = PlayerController.sede - 1;
            PlayerController.tempoSede = 3;
        }

    }
}   

