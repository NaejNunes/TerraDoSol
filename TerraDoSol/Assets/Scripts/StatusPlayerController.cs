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

        //Condição para diminuir a fome
        if (GameController.tempoFome <= 1 && GameController.segundos <= 1)
        {
            PlayerController.fome = PlayerController.fome - 1;
            GameController.tempoFome = 5;
        }

        //Condição para Aumentar a mana
        if (GameController.tempoMana == 0)
        {
            PlayerController.mana = PlayerController.mana + 1;
            GameController.tempoMana = 10;
        }

        //Condição para desatuivar a vida ilustrativa da tela.
        if (PlayerController.vida == 2)
        {
            vida[0].SetActive(false);          
        }

        if (PlayerController.vida == 1)
        {
            vida[1].SetActive(false);
        }

        if (PlayerController.vida == 0)
        {
            vida[2].SetActive(false);
        }

        //Condicao para desativar e ativar a mana ilustrativa na tela.
        if (PlayerController.mana < 4)
        {
            mana[0].SetActive(false);
        }
        else if (PlayerController.mana == 5)
        {
            mana[0].SetActive(true);
        }
        //_____________________________________________________________________________

        if (PlayerController.mana <= 3)
        {
            mana[1].SetActive(false);
        }
        else if (PlayerController.mana == 4)
        {
            mana[1].SetActive(true);
        }
        //_____________________________________________________________________________

        if (PlayerController.mana <=  2)
        {
            mana[2].SetActive(false);
        }
        else if (PlayerController.mana == 3)
        {
            mana[2].SetActive(true);
        }
        //_____________________________________________________________________________

        if (PlayerController.mana <= 1)
        {
            mana[3].SetActive(false);
        }
        if (PlayerController.mana == 2)
        {
            mana[3].SetActive(true);


        }
        //_____________________________________________________________________________

        if (PlayerController.mana == 0)
        {
            mana[4].SetActive(false);
        }
        if (PlayerController.mana == 1)
        {
            mana[4].SetActive(true);
        }
    }
}
