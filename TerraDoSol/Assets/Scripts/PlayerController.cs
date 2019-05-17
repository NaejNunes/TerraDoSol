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
    //Vairiaveis para definir os atributos basicos do player.
    public static int vida, maxVida, maxMana,  mana, fome, sede, forca, inteligencia, agilidade, constituicao, experiencia, maxExperiencia, nivel;
  
    //Variavel usada para receber as posicoes.
    public static float x, y;

    //Variavel para lincar a tabela de atributos do player.
    public GameObject TabelaDoHeroi, ataqueMagico;

    //Variavel que liga o texto da vida na tabela do heroi.
    public Text txtVida, txtMana, txtFome, txtSede, txtForca, txtInteligencia, txtAgilidade, txtConstituicao, txtExperiencia, txtNivel;

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

        //Atributos inicial do Player
        forca = 1;
        inteligencia = 1;
        agilidade = 1;
        constituicao = 1;

        //Da valor ao experiencia.
        maxExperiencia = 100;
        experiencia = 0;
        nivel = 1;
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

        if (experiencia >= maxExperiencia)
        {

        }

        //recebe o arquivo txt e da as seguintes informacoes a ela...
        txtVida.text = "" + vida + "/" + maxVida;

        txtMana.text = "" + mana + "/" + maxMana;

        txtFome.text = "" + fome + "/" + "10";

        txtSede.text = "" + sede + "/" + "10";

        //Ligando os arquivos txt dos atributos;
        txtForca.text = "" + forca;

        txtInteligencia.text = "" + inteligencia;

        txtAgilidade.text = "" + agilidade;

        txtConstituicao.text = "" + constituicao;

        //Nivel e Experiencia sendo ligados ao texto.
        txtExperiencia.text = "" + experiencia + "/" + maxExperiencia;

        txtNivel.text = "" + nivel;

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
