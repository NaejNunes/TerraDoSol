using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDeGelo : MonoBehaviour
{
    bool checkDescricao, itemOk;

    public GameObject painelDescricao;

    // Start is called before the first frame update
    void Start()
    {
        checkDescricao = false;
        itemOk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && itemOk == true)
        {
            PlayerController.flechaDeGelo = true;
            Destroy(gameObject);
        }
    }

    public void OnMouseEnter()
    {           
        checkDescricao = true;
        itemOk = true;

        if (checkDescricao == true)
        {
            painelDescricao.SetActive(true);
        }

      
    }

    public void OnMouseExit()
    {
        checkDescricao = false;
        itemOk = false;

        if (checkDescricao == false)
        {
            painelDescricao.SetActive(false);    
        }
    }
}
