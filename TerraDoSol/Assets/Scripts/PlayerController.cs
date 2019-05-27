using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //Variavel que recebe a velocidade em que o player ira andar.
    public float velocidade;

    //Vairiaveis para definir os atributos basicos do player.
    public static int vida, maxVida, mana, maxMana,
                      fome, fomeMax, sede, sedeMax,
                      milesimos, segundos,
                      milesimosVida, segundosVida,
                      milesimosMana, segundosMana,
                      tempoMana, tempoFome, tempoSede,
                      pontos, forca, inteligencia, agilidade, constituicao,
                      nivel,
                      ataqueFisico, ataqueMagico, defesaFisica, defesaMagica, regenDeVida, regenDeMana;

    public static float porcentagemCritivo, experiencia, maxExperiencia;

    //Variavel usada para receber as posicoes.
    public static float X, Y;

    //Variavel para lincar a tabela de atributos do player.
    public GameObject painelHeroi, painelInventario, painelHabilidade,
                      ataqueBasicoCima, ataqueBasicoBaixo, ataqueBasicoEsquerda, ataqueBasicoDireita,
                      flechaGeloCima, flechaGeloBaixo, flechaGeloEsqueda, flechaGeloDeireita,
                      btnForca, btnInteligencia, btnAgilidade, btnConstituicao;

    public GameObject[] vidaHUD, manaHUD;

    //visualiza o texto
    public Text txtVida, txtMana,
           txtFome, txtSede,
           txtPontos, txtForca, txtInteligencia, txtAgilidade, txtConstituicao,
           txtExperiencia, txtNivel;

    private Animator animacao;

    //Define a direcao do player.
    public static bool direcaoDireita, direcaoEsquerda, direcaoBaixo, direcaoCima,
                        flechaDeGelo,
                        flechaDeGeloAtivado;

    public bool checkHeroi, checkInventario, checkHabilidade;

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

        //INICIA O TEMPO    
        milesimosVida = 60;
        segundosVida = 60;
        milesimosMana = 60;
        segundosMana = 40;
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
        pontos = 0;

        //Inicia a variavel com o animator.
        animacao = GetComponent<Animator>();

        //Inicia os Atributos
        ataqueFisico = 1;
        ataqueMagico = 0;
        defesaFisica = 1;
        defesaMagica = 1;
        porcentagemCritivo = 0.01f;
        regenDeVida = segundosVida;
        regenDeMana = segundosMana;

        checkHeroi = false;
        checkInventario = false;
        checkHabilidade = false;

        //HABILIDADES
        flechaDeGelo = false;

        flechaDeGeloAtivado = false;
    }

    // Update is called once per frame.
    void Update()
    {

        //Atribuir a posicao nas variaveis.
        X = transform.position.x;
        Y = transform.position.y;


        //_________________CHAMA AS FUNCOES_______________________________

        //Chama a funcao para movimentar o player.
        MovimentacaoPlayer();

        //Chama a funcao que instancia a Habilidade.
        AtaqueBasico();

        // Ataque de Habilidade
        if (mana >= 2 && flechaDeGeloAtivado == true)
        {
            FleclaDeGelo();
        }

        //______________________CONTROLA A VIDA DO PLAYER________________________

        //Contador de Tempo para aumentar a vida
        if (vida < maxVida)
        {
            milesimosVida -= 1;

            if (milesimosVida == 0)
            {
                segundosVida -= 1;

                milesimosVida += 60;
            }

            if (segundosVida == 0)
            {
                vida += 1;
                segundosVida = regenDeVida;
            }
        }

        if (vida == 0)
        {
            Debug.Log("MORREU!");
        }

        //Desatuivar a vida da HUD.
        if (vida == 2)
        {
            vidaHUD[0].SetActive(false);
        }
        //Ativa a vida da HUD.
        if (vida == 3)
        {
            vidaHUD[0].SetActive(true);
        }
        //_____________________________________________________________________________

        if (vida == 1)
        {
            vidaHUD[1].SetActive(false);
        }
        if (vida == 2)
        {
            vidaHUD[1].SetActive(true);
        }
        //_____________________________________________________________________________

        if (vida == 0)
        {
            vidaHUD[2].SetActive(false);
        }
        if (vida == 1)
        {
            vidaHUD[2].SetActive(true);
        }

        //________________________CONTROLADOR DE MANA__________________________________

        if (mana < maxMana)
        {
            milesimosMana -= 1;

            if (milesimosMana == 0)
            {
                segundosMana -= 1;

                milesimosMana += 60;
            }

            if (segundosMana == 0)
            {
                mana += 1;
                segundosMana = regenDeMana;
            }
        }

        if (mana <= 0)
        {
            mana = 0;
        }

        //Desatuivar a mana da HUD.
        if (mana <= 4)
        {
            manaHUD[0].SetActive(false);
        }
        //Ativa a mana da HUD.
        if (mana == 5)
        {
            manaHUD[0].SetActive(true);
        }
        //_____________________________________________________________________________   

        if (mana <= 3)
        {
            manaHUD[1].SetActive(false);
        }
        if (mana == 4)
        {
            manaHUD[1].SetActive(true);
        }
        //_____________________________________________________________________________  

        if (mana <= 2)
        {
            manaHUD[2].SetActive(false);
        }
        if (mana == 3)
        {
            manaHUD[2].SetActive(true);
        }
        //_____________________________________________________________________________

        if (mana <= 1)
        {
            manaHUD[3].SetActive(false);
        }
        if (mana == 2)
        {
            manaHUD[3].SetActive(true);
        }
        //_____________________________________________________________________________

        if (mana <= 0)
        {
            manaHUD[4].SetActive(false);
        }
        if (mana == 1)
        {
            manaHUD[4].SetActive(true);
        }

        //________________________CONTROLADOR DOS PAINEIS__________________________________

        //HEROI
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (checkHeroi == true)
            {
                checkHeroi = false;
            }
            else
            {
                checkHeroi = true;
            }

            if (checkHeroi == true)
            {
                painelHeroi.SetActive(true);
            }

            if (checkHeroi == false)
            {
                painelHeroi.SetActive(false);
            }
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
            //Retira
            btnForca.SetActive(true);
            btnInteligencia.SetActive(true);
            btnAgilidade.SetActive(true);
            btnConstituicao.SetActive(true);
        }

        //INVENTARIO
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (checkInventario == true)
            {
                checkInventario = false;
            }
            else
            {
                checkInventario = true;
            }

            if (checkInventario == true)
            {
                painelInventario.SetActive(true);
            }

            if (checkInventario == false)
            {
                painelInventario.SetActive(false);
            }
        }

        //HABILIDADE       
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (checkHabilidade == true)
            {
                checkHabilidade = false;
            }
            else
            {
                checkHabilidade = true;
            }

            if (checkHabilidade == true)
            {
                painelHabilidade.SetActive(true);
            }

            if (checkHabilidade == false)
            {
                painelHabilidade.SetActive(false);
            }
        }
        //GUILDA

        //CONFIGURACOES

        //_________________________NIVEL________________________________

        //Condicao que passa de nivel.
        if (experiencia >= maxExperiencia)
        {
            nivel = nivel + 1;
            experiencia = 0;
            pontos += 1;
            maxExperiencia = maxExperiencia * 1.5f;
        }

        //___________________________ARQUIVOS TEXTO___________________________________

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

    //______________________COMANDOS INPUT_______________________________

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

    //Inicia o ataque basico
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

    // Inicia uma habilidade 
    public void FleclaDeGelo()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            mana -= 2;
            if (direcaoDireita == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.flechaGeloDeireita, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoEsquerda == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.flechaGeloEsqueda, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoCima == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.flechaGeloCima, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }

            if (direcaoBaixo == true)
            {
                animacao.SetBool("Atacar", true);
                Instantiate(this.flechaGeloBaixo, new Vector2(PlayerController.X, PlayerController.Y), Quaternion.identity);
            }
        }
    }

    //______________________________COLISOES________________________________________

    //Detecta a colisao com algo solido em cena
    public void OnCollisionEnter2D(Collision2D colidir)
    {
        //Condição para checar se o player colidiu com o inimigo e tirar 1 de vida.
        if (colidir.gameObject.CompareTag("Inimigo"))
        {
            vida -= 1;
        }
    }

    //_____________________________COLETANDO ITENS_______________________________________
    public void ColetarItens()
    {
        if (flechaDeGelo == true)
        {

        }
    }

    //Metodo que simula um cronometro.
    public static void Tempo()
    {
        milesimos = milesimos - 1;

        if (milesimos <= 0)
        {
            segundos = segundos - 1;

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
