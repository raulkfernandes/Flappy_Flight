using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour {

    private Carrossel[] cenario;
    private GeradorDeObstaculos geradorDeObstaculos;
    private Aviao aviao;
    private ParticleSystem efeitoFumaca;
    private Animator[] animacoesAviao;
    private float alturaJogador;
    private bool jogadorDesativado;

    private void Start()
    {
        this.cenario = this.GetComponentsInChildren<Carrossel>();
        this.geradorDeObstaculos = this.GetComponentInChildren<GeradorDeObstaculos>();
        this.aviao = this.GetComponentInChildren<Aviao>();
        this.efeitoFumaca = this.GetComponentInChildren<ParticleSystem>();
        this.animacoesAviao = this.GetComponentsInChildren<Animator>();
        this.alturaJogador = this.transform.position.y;
    }

    public void Desativar ()
    {
        // Avisa que desativou:
        this.jogadorDesativado = true;
        // Parar efeito de fumaça:
        this.efeitoFumaca.gameObject.SetActive(false);
        // Parar animação do avião:
        foreach(var animacao in animacoesAviao)
        {
            animacao.enabled = false;
        }
        // Parar a movimentação do cenário:
        foreach (var carrossel in this.cenario)
        {
            carrossel.enabled = false;
        }
        // Parar de gerar obstaculos:
        this.geradorDeObstaculos.Parar();

        // Destruir os obstaculos existentes:
        Obstaculo[] obstaculos = FindObjectsOfType<Obstaculo>();
        foreach(var obstaculo in obstaculos)
        {
            float alturaObstaculos = obstaculo.transform.position.y;

            if(     alturaObstaculos > (alturaJogador - obstaculo.variacaoEmY) 
                 && alturaObstaculos < (alturaJogador + obstaculo.variacaoEmY))
            {
                Destroy(obstaculo.gameObject);
            }
        }
    }

    public void Reativar ()
    {
        if(this.jogadorDesativado)
        {
            this.aviao.Reiniciar();
            this.efeitoFumaca.gameObject.SetActive(true);
            foreach (var animacao in animacoesAviao)
            {
                animacao.enabled = true;
            }
            foreach (var carrossel in this.cenario)
            {
                carrossel.enabled = true;
            }
            this.geradorDeObstaculos.Recomecar();
            this.jogadorDesativado = false;

            if(Camera.allCamerasCount > 1)
            {
                this.aviao.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
}
