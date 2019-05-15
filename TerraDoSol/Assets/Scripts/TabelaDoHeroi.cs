using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabelaDoHeroi : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Função que carrega a Tabela do Herói.
        CarregarTabelaDoHeroi();

    }

    //Função que carrega a tela do herois com todos os atributos do heroi.
    public void CarregarTabelaDoHeroi()
    {

        //Condição que se o botão "C" do teclado for acionbado ele abre a tela da Tabela do Herói.
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (gameObject.activeInHierarchy == true)
            {
                gameObject.SetActive(false);              
            }          
           
        }
        
    }
}