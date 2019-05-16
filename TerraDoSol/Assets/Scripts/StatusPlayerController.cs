using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayerController : MonoBehaviour
{
    //Liga o objeto vida no script
    public GameObject[] vida;

    //Variavel para usar no metodo Tempo.
    public static int milesimos, segundos, minutos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Chama o Método para contar o tempo.
        GameController.Tempo(milesimos, segundos, minutos);

        //Condição para diminuir a fome
        if (GameController.minutos <= 1 && GameController.segundos <= 1)
        {
            PlayerController.fome = PlayerController.fome - 1;
        }

        //Condição para desatuivar a vida ilustrativa da tela.vjcr4,,cowe,l~e~ç 1swdxllrd~´l
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

    }
}
