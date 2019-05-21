using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabelaDoHeroi : MonoBehaviour
{
    

    public GameObject btnForca, btnInteligencia, btnAgilidade, btnConstituicao;

    public Text txtVida, txtMana,
           txtFome, txtSede,
           txtPontos, txtForca, txtInteligencia, txtAgilidade, txtConstituicao,
           txtExperiencia, txtNivel;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Função que carrega a Tabela do Herói.
        CarregarTabelaDoHeroi();

        //recebe o arquivo txt e da as seguintes informacoes a ela...
        txtVida.text = "" + PlayerController.vida + "/" + PlayerController.maxVida;

        txtMana.text = "" + PlayerController.mana + "/" + PlayerController.maxMana;

        txtFome.text = "" + PlayerController.fome + "/" + "10";

        txtSede.text = "" + PlayerController.sede + "/" + "10";

        //Ligando os arquivos txt dos atributos;
        txtForca.text = "" + PlayerController.forca;

        txtInteligencia.text = "" + PlayerController.inteligencia;

        txtAgilidade.text = "" + PlayerController.agilidade;

        txtConstituicao.text = "" + PlayerController.constituicao;

        //Nivel e Experiencia sendo ligados ao texto.
        txtExperiencia.text = "" + PlayerController.experiencia + "/" + PlayerController.maxExperiencia;

        txtNivel.text = "" + PlayerController.nivel;

        txtPontos.text = "" + PlayerController.pontos;

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

        if (PlayerController.pontos <= 0)
        {
            btnForca.SetActive(false);
            btnInteligencia.SetActive(false);
            btnAgilidade.SetActive(false);
            btnConstituicao.SetActive(false);
        }
        else if (PlayerController.pontos >= 1)
        {
            btnForca.SetActive(true);
            btnInteligencia.SetActive(true);
            btnAgilidade.SetActive(true);
            btnConstituicao.SetActive(true);
        }
    }

    public void AdicionarForca()
    {
        PlayerController.forca += 1;

        PlayerController.pontos -= 1;
    }

    public void AdicionarInteligencia()
    {
        PlayerController.inteligencia += 1;

        PlayerController.pontos -= 1;
    }

    public void AdicionarAgilidade()
    {
        PlayerController.agilidade += 1;

        PlayerController.pontos -= 1;
    }

    public void AdicionarConstituicao()
    {
        PlayerController.constituicao += 1;

        PlayerController.pontos -= 1;
    }
}