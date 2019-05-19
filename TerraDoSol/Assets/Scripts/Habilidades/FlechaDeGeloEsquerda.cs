using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDeGeloEsquerda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {     
            transform.Translate(Vector3.left * 0.1f);
    }

    public void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.CompareTag("Inimigo"))
        {
            Destroy(this.gameObject);
        }
        if (Colisao.gameObject.CompareTag("Cenario"))
        {
            Destroy(this.gameObject);
        }
    }
}
