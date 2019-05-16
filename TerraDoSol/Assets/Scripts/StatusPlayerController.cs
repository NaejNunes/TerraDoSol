using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayerController : MonoBehaviour
{
    //Liga o objeto vida no script
    public GameObject[] vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
