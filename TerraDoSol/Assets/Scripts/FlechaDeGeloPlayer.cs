using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDeGeloPlayer : MonoBehaviour
{
    bool checkDescricao, itemOK;

    public GameObject painelDescricao;

    // Start is called before the first frame update
    void Start()
    {
        checkDescricao = false;
        itemOK = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && itemOK == true)
        {
            PlayerController.flechaDeGeloAtivado = true;
            Destroy(gameObject);
        }
    }

    public void OnMouseEnter()
    {
        checkDescricao = true;
        itemOK = true;

        if (checkDescricao == true)
        {
            painelDescricao.SetActive(true);
        }      
    }

    public void OnMouseExit()
    {
        checkDescricao = false;
        itemOK = false;

        if (checkDescricao == false)
        {
            painelDescricao.SetActive(false);
        }
    }
}

