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
                      fome, sede, 
                      milesimos, segundos, tempoVida, tempoMana, tempoFome, tempoSede,
                      pontos, forca, inteligencia, agilidade, constituicao,
                      experiencia, maxExperiencia, experienciaAuxiliar,  nivel,
                      ataqueFisico, ataqueMagico, defesaFisica, defesaMagica, regenDeVida, regenDeMana ;
  
    //Variavel usada para receber as posicoes.
    public static float X, Y,
                        criticoPorcentagem;

    //Variavel para lincar a tabela de atributos do player.
    public GameObject tabelaDoHeroi, ataqueMagicoRight, ataqueMagicoLeft, ataqueMagicoUp, ataqueMagicoDown;
                                           
    private Animator animacao;   

    //Define a direcao do player.
    public static bool direcaoDireita, direcaoEsquerda, direcaoBaixo, direcaoCima;

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

        //Tempo
        tempoVida = 50;
        tempoMana = 1;
        tempoFome = 6;
        tempoSede = 3;

        //Atributos inicial do Player
        forca = 1;
        inteligencia = 1;
        agilidade = 1;
        constituicao = 1;

        //Da valor ao experiencia.
        maxExperiencia = 100;
        experiencia = 0;
        nivel = 1;
        experienciaAuxiliar = 0;
        pontos = 5;

        //Inicia a variavel com o animator.
        animacao = GetComponent<Animator>();

        //Inicia os Atributos
        ataqueFisico = 1;
        ataqueMagico = 0;
        defesaFisica = 1;
        defesaMagica = 0;
        criticoPorcentagem = 0;
        regenDeVida = 1;
        regenDeMana = 1;
    }
            
    // Update is called once per frame.
    void FixedUpdate()
    {      
        //Chama a função Tempo
        Tempo();

        //Chama a funcao para movimentar o player.
        MovimentacaoPlayer();

        //Condicao que verifica se tem mana suficiente;
        if (mana > 1)
        {
            //Chama a funcao que instancia a Habilidade.
            FechaDeGelo();
        }

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
        if (tempoMana == 0)
        {
            mana = mana + 1;
            tempoMana = 1;
        }

        //Condicao que passa de nivel.
        if (experiencia >= maxExperiencia)
        {
            nivel = nivel + 1;
            experiencia = 0;
            pontos += 5;
        }


        //Atribuir a posicao nas variaveis.
        X = transform.position.x;
        Y = transform.position.y;

        CarregarTabelaDoHeroi();
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
            animacao.SetInteger("Direcao", 2);
            animacao.SetBool("AndarBaixo", true);
        }

        else if (x == 1)
        {
            direcaoDireita = true;
            direcaoEsquerda = false;
            direcaoCima = false;
            direcaoBaixo = false;

            transform.position += new Vector3(velocidade, 0, 0);

            animacao.SetInteger("Direcao", 1);
            animacao.SetBool("AndarBaixo", true);
        }
        else if (y == -1)
        {
            direcaoDireita = false;
            direcaoEsquerda = false;
            direcaoCima = false;
            direcaoBaixo = true;

            transform.position += new Vector3(0, -velocidade, 0);

            animacao.SetInteger("Direcao", 0);
            animacao.SetBool("AndarBaixo", true);
        }

        else if (x == -1)
        {
            direcaoDireita = false;
            direcaoEsquerda = true;
            direcaoCima = false;
            direcaoBaixo = false;

            transform.position += new Vector3(-velocidade, 0, 0);

            animacao.SetInteger("Direcao", 3);
            animacao.SetBool("AndarBaixo", true);
        }
        else
        {
            animacao.SetBool("AndarBaixo", false);
        }
    }

    public void CarregarTabelaDoHeroi()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            tabelaDoHeroi.SetActive(true);
        }
    }

    //Instacia uma flecha de gelo.

    public void FechaDeGelo()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            mana = mana - 2;

            if (direcaoDireita == true)
            {
                Instantiate(this.ataqueMagicoRight, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoEsquerda == true)
            {
                Instantiate(this.ataqueMagicoLeft, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoCima == true)
            {
                Instantiate(this.ataqueMagicoUp, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoBaixo == true)
            {
                Instantiate(this.ataqueMagicoDown, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
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

            //Controla o tempo da regeneracao da mana
            tempoMana = tempoMana - 1;

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
