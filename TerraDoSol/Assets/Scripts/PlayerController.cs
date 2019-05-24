using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //Variavel que da a velocidade em que o player ira andar.
    public float velocidade;

    //Vairiaveis para definir os atributos basicos do player.
    public static int vida, maxVida, mana, maxMana,
                      fomeMax, fome, sede, sedeMax, 
                      milesimos, segundos, tempoVida, tempoMana, tempoFome, tempoSede,
                      pontos, forca, inteligencia, agilidade, constituicao, 
                      experienciaAuxiliar,  nivel,
                      ataqueFisico, ataqueMagico, defesaFisica, defesaMagica, regenDeVida, regenDeMana ;

    public static float porcentagemCritivo, experiencia, maxExperiencia;

    //Variavel usada para receber as posicoes.
    public static float X, Y;
                        
    //Variavel para lincar a tabela de atributos do player.
    public GameObject tabelaDoHeroi, ataqueBasicoCima, ataqueBasicoBaixo, ataqueBasicoEsquerda, ataqueBasicoDireita,
                      btnForca, btnInteligencia, btnAgilidade, btnConstituicao;                 

    //visualiza o texto
    public Text txtVida, txtMana,
           txtFome, txtSede,
           txtPontos, txtForca, txtInteligencia, txtAgilidade, txtConstituicao,
           txtExperiencia, txtNivel; 

    private Animator animacao;   

    //Define a direcao do player.
    public static bool direcaoDireita, direcaoEsquerda, direcaoBaixo, direcaoCima;

    public bool CheckTabela;

    // Start is called before the first frame update.
    void Start()
    {
        //Inicializa as variaveis quando comeca o jogo.
        vida = 3;
        maxVida = 3;
        mana = 5;
        maxMana = 5;
        fome = 10;
        fomeMax = 10;
        sede = 10;

        //Tempo
        tempoVida = 50;
        tempoMana = 30;
        tempoFome = 6;
        tempoSede = 3;

        //Atributos inicial do Player
        forca = 0;
        inteligencia = 0;
        agilidade = 0;
        constituicao = 0;

        //Da valor ao experiencia.
        maxExperiencia = 500f;
        experiencia = 0;
        nivel = 1;
        experienciaAuxiliar = 0;
        pontos = 0;

        //Inicia a variavel com o animator.
        animacao = GetComponent<Animator>();

        //Inicia os Atributos
        ataqueFisico = 1;
        ataqueMagico = 0;
        defesaFisica = 1;
        defesaMagica = 1;
        porcentagemCritivo = 0.01f;
        regenDeVida = 1;
        regenDeMana = 1;

        CheckTabela = true;
    }
            
    // Update is called once per frame.
    void FixedUpdate()
    {      
        //Chama a função Tempo
        Tempo();

        //Chama a funcao para movimentar o player.
        MovimentacaoPlayer();

        //Condicao que verifica se tem mana suficiente;
      
            //Chama a funcao que instancia a Habilidade.
            AtaqueBasico();
        

        //Condicao para nao aumentar a "vida" mais que o maximo.
        if (vida >= maxVida)
        {
            vida = maxVida;
        }

        if (tempoVida == 0)
        {
            vida = vida + 1;
        }

        //Condicao para nao aumentar a "mana" mais que o maximo.
        if (mana >= maxMana)
        {
            mana = maxMana;
        }

        //Condição que aumenta a manda no tempo descrito
        if (mana >= 5)
        {
            //Controla o tempo da regeneracao da mana

            tempoMana -= 1;
        }
        if (tempoMana == 0)
        {
            mana = mana + 1;
            tempoMana = 30;
        }

        //Atribuir a posicao nas variaveis.
        X = transform.position.x;
        Y = transform.position.y;

        //Chama a tabela do heroi quando apertar o botão.
        if (Input.GetKeyDown(KeyCode.C))
        {        
            if (CheckTabela == true)
            {
                CheckTabela = false;
            }
            else
            {
                CheckTabela = true;
            }

            if (CheckTabela == true)
            {
               tabelaDoHeroi.SetActive(true);
            }

            if (CheckTabela == false)
            {
                tabelaDoHeroi.SetActive(false);
            }
        }

        //Condicao que passa de nivel.
        if (experiencia >= maxExperiencia)
        {
            nivel = nivel + 1;
            experiencia = 0;
            pontos += 1;
            maxExperiencia = maxExperiencia * 1.5f;
        }

        //ativa e desativa os botoes na tabela para distribuir pontos
        if (pontos == 0)
        {
            //Adiciona
            btnForca.SetActive(false);
            btnInteligencia.SetActive(false);
            btnAgilidade.SetActive(false);
            btnConstituicao.SetActive(false);
        }      
         if (pontos == 1)
        {
            btnForca.SetActive(true);
            btnInteligencia.SetActive(true);
            btnAgilidade.SetActive(true);
            btnConstituicao.SetActive(true);
        }       

        //recebe o arquivo txt e da as seguintes informacoes a ela...
        txtVida.text = "" + vida + "/" + maxVida;

        txtMana.text = "" + mana + "/" + maxMana;

        txtFome.text = "" + fome + "/" + fomeMax;

        txtSede.text = "" + sede + "/" + fomeMax;

        //Ligando os arquivos txt dos atributos;
        txtForca.text = "" + forca;

        txtInteligencia.text = "" + inteligencia;

        txtAgilidade.text = "" + agilidade;

        txtConstituicao.text = "" + constituicao; 

        //Nivel e Experiencia sendo ligados ao texto.
        txtExperiencia.text = "" + experiencia + "/" + maxExperiencia;

        txtNivel.text = "" + nivel;

        txtPontos.text = "" + pontos;
    }


    //Movimentação do player.
    public void MovimentacaoPlayer()
    {
        //atribui os valores para movimentar pelos botoes
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (y == 1)
        {
            //Ajuda a identificar em qual posição está, ajuda no sistema de soltar ataques e magia.
            direcaoDireita = false;
            direcaoEsquerda = false;
            direcaoCima = true;
            direcaoBaixo = false;

            //Recebe a posicao para se movimentar.
            transform.position += new Vector3(0, velocidade, 0);

            //Recebe as animações
            animacao.SetInteger("Andar", 2);
            animacao.SetBool("Parado", false);
            animacao.SetBool("Atacar", false);
        }
        else if (x == 1)
        {
            direcaoDireita = true;
            direcaoEsquerda = false;
            direcaoCima = false;
            direcaoBaixo = false;

            transform.position += new Vector3(velocidade, 0, 0);

            animacao.SetInteger("Andar", 1);
            animacao.SetBool("Parado", false);
             animacao.SetBool("Atacar", false);
        }
        else if (y == -1)
        {
            direcaoDireita = false;
            direcaoEsquerda = false;
            direcaoCima = false;
            direcaoBaixo = true;

            transform.position += new Vector3(0, -velocidade, 0);

            animacao.SetInteger("Andar", 0);
            animacao.SetBool("Parado", false);
             animacao.SetBool("Atacar", false);

        }

        else if (x == -1)
        {
            direcaoDireita = false;
            direcaoEsquerda = true;
            direcaoCima = false;
            direcaoBaixo = false;

            transform.position += new Vector3(-velocidade, 0, 0);

            animacao.SetInteger("Andar", 3);
            animacao.SetBool("Parado", false);
             animacao.SetBool("Atacar", false);
        }
        else
        {
            animacao.SetBool("Parado", true);
             animacao.SetBool("Atacar", false);
        }
    }

    //Instacia uma flecha.
    public void AtaqueBasico()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {         
            if (direcaoDireita == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.ataqueBasicoDireita, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoEsquerda == true)
            {
                 animacao.SetBool("Atacar", true);
                Instantiate(this.ataqueBasicoEsquerda, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoCima == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.ataqueBasicoCima, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoBaixo == true)
            {
                 animacao.SetBool("Atacar", true);
                Instantiate(this.ataqueBasicoBaixo, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }
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
    
    //Metodo que simula um cronometro.
    public static void Tempo()
    {
        milesimos = milesimos - 1;

        if (milesimos <= 0)
        {
            segundos = segundos - 1;

            //Controla o tempo da regeneracao da vida
            tempoVida = tempoVida - 1;

            milesimos = 60;
        }
        if (segundos <= 0)
        {
            //Controla o tempo de fome
            tempoFome = tempoFome - 1;

            //Controla o tempo de sede
            tempoSede = tempoSede - 1;

            segundos = 60;
        }
    }
}
