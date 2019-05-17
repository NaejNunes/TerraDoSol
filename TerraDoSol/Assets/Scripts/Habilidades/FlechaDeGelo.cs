using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDeGelo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.05f , 0);
    }
    
    public void OnTriggerEnter2D(Collider2D Colisao)
    {
        if (Colisao.gameObject.CompareTag("Inimigo"))
        {
            Destroy(this.gameObject);
        }
    }
}
