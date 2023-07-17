using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    //Criando a vari�vel para saber quem � o meu rigidbody
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;
    public float velocidade = 5f;
    public float limiteHorizontal = 12f;
    public AudioClip boing;
    public Transform transforCamera;
    public AudioClip ending;
    public AudioClip backsound;
    public float delay = 2f;
    public bool jogoIniciado = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Iniciando a bola com um Delay
        //Diminuindo o valor do deley
        delay = delay - Time.deltaTime;

        //Checando se o deley chegou em 0 para ent�o iniciar o jogo
        if (delay <= 0 && jogoIniciado == false)
        {
            //Alterar valor da vari�vel de controle
            jogoIniciado = true;
            //Iniciando o jogo


            //Tentando gerar um valor aleat�rio
            int direcao = Random.Range(0, 4);

            if (direcao == 0)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }
            else if (direcao == 3)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }

            //Adicionando uma velocidade para a esquerda
            meuRB.velocity = minhaVelocidade;
        }
        
        //Checando se a bola saiu da tela
        if(transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            AudioSource.PlayClipAtPoint(ending, transforCamera.position);
            //Recarregando a minha scena.
            SceneManager.LoadScene(0);
        }
    }

    //Criando o meu evento de colisao
    //Evento de colisao 2d
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, transforCamera.position);
    }
}
