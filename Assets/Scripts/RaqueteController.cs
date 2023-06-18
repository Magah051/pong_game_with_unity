using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Criando Vector 3
    private Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 5f;
    public float meuLimite = 3.5f;

    //Identificando se eu sou o player 1
    public bool player1;

    //Variável de checagem IA
    public bool automatico = false;

    //Pegando a posição da bola
    public Transform transformBola;

    // Start is called before the first frame update
    void Start()
    {
        //Pegando a posicao inicial da raquete e aplicando à minha posicao
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Passando o meuY para o eixo Y da minhaPosicao
        minhaPosicao.y = meuY;

        //Modificar posição da raquete
        transform.position = minhaPosicao;

        //Velocidade multiplicada pelo deltatime
        float deltaVelocidade = velocidade * Time.deltaTime;

        //Se o automático não for TRUE
        if (!automatico)
        {

            //Pegando a setinha para cima
            //Se eu aperta a setinha para cima ele vai subir a raquete.
            //DeltaTime para normalizar frames.
            //Controlando a raquete como o player 1

            if (player1)
            {
                if (Input.GetKey(KeyCode.W))
                {

                    meuY = meuY + deltaVelocidade;

                }
                //Pegando a setinha para baixo
                if (Input.GetKey(KeyCode.S))
                {
                    //Diminuir o valor do meuY;
                    meuY = meuY - deltaVelocidade;
                }
            }
            else
            {
                //Meu código para colocar ele no automático
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    automatico = true;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    meuY = meuY + deltaVelocidade;

                }
                //Pegando a setinha para baixo
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //Diminuir o valor do meuY;
                    meuY = meuY - deltaVelocidade;
                }
            }
        }
        else
        {

            //Tirando do automatico
            //Checando se a setinha para cima ou para baixo foi pressionada
            if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }

            //Se a raquete está no automatico
            //Para acessar funções matemáticas, nós usamos a classe Mathf
            meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.2f);
            

        }

        //Impedindo que eu saia por baixo da tela
        if (meuY < -meuLimite)
        {
            meuY = -meuLimite;
        }

        //Impedindo que eu saia por cima da tela
        if (meuY > meuLimite)
        {
            meuY = meuLimite;
        }

    }
}
