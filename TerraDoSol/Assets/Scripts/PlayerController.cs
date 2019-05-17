using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //Variavel que da a velocidade em que o player ira andar.
    public float velocidade;

    
    [SerializeField]
    //Variavel para atribuir as vidas do player
    public static int vida, maxVida, maxMana,  mana, fome, sede;

    //Variavel usada para receber as posicoes.
    public static float x, y;

    //Variavel para lincar a tabela de atributos do player.
    public GameObject TabelaDoHeroi, ataqueMagico;

    //Variavel que liga o texto da vida na tabela do heroi.
    public Text txtVida, txtMana, txtFome, txtSede;

    // Start is called before the first frame update.
    void Start()
    {
        //Inicializa as variaveis quando comeca o jogo.
        vida = 3;
        maxVida = 3;
        mana = 5;
        maxMana = 5;
        fome = 10;
        sede = 10;
    }
            
    // Update is called once per frame.
    void Update()
    {      
        //Chama a funcao para movimentar o player.
        MovimentaçãoPlayer();

        //Condicao que verifica se tem mana suficiente;
        if(mana > 1)
        {
            //Chama a funcao que instancia a Habilidade.
            FechaDeGelo();
        }

        //Condicao para nao aumentar a "vida" mais que o maximo.
        if (vida >= maxVida)
        {
            vida = maxVida;
        }
        //Condicao para nao aumentar a "mana" mais que o maximo.

        if (mana >= maxMana)
        {
            mana = maxMana;
        }

        //recebe o arquivo txt e da as seguintes informacoes a ela...
        txtVida.text = "" + vida + "/" + maxVida;

        txtMana.text = "" + mana + "/" + maxMana;

        txtFome.text = "" + fome + "/" + "10";

        txtSede.text = "" + sede + "/" + "10";

        //Chama a tela do herois em jogo
        CarregarTabelaDoHeroi();

        //Atribuir a posicao nas variaveis.
        x = transform.position.x;
        y = transform.position.y;

    }

    //Movimentação do player.
    public void MovimentaçãoPlayer()
    {
        //Função que faz a movimentação do player na direita e esquerda.
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        //Movimentação do player para cima e baixo.
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }      
    }

    //Função que carrega a tela do herois com todos os atributos do heroi.
    public void CarregarTabelaDoHeroi()
    {

        //Condição que se o botão "C" do teclado for acionbado ele abre a tela da Tabela do Herói.
        if (Input.GetKeyDown(KeyCode.C))
        {
            TabelaDoHeroi.SetActive(true);
        }
    }

    //Detecta a colisao com algo solido em cena
    public void OnCollisionEnter2D(Collision2D colidir)
    {

        //Condição para checar se o player colidiu com o inimigo e tirar 1 de vida.
        if (colidir.gameObject.CompareTag("Inimigo"))
        {
            vida = vida - 1;
        }
    }
    //Instacia uma flecha de gelo.
    public void FechaDeGelo()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mana = mana - 2;
            Instantiate(this.ataqueMagico, new Vector2(PlayerController.x, PlayerController.y), Quaternion.identity);
        }
    }
}
