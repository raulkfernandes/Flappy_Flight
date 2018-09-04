using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorVersus : Diretor {

    private bool jogadorMorto;
    private InterfaceStandby interfaceStandby;
    private Pontuacao[] pontuacoes;
    private ControlaJogador[] jogadores;
    private GameObject[] animacoesTutorial;
    private GameObject[] avioes;

    protected override void Start()
    {
        base.Start();
        this.pontuacoes = FindObjectsOfType<Pontuacao>();
        this.jogadores = FindObjectsOfType<ControlaJogador>();
        this.interfaceStandby = FindObjectOfType<InterfaceStandby>();
        this.animacoesTutorial = GameObject.FindGameObjectsWithTag(LiteralStrings.CanvasTutorial);
        this.avioes = GameObject.FindGameObjectsWithTag(LiteralStrings.Aviao);
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        this.ReviverJogadores();

        foreach(var pontuacao in pontuacoes)
        {
            pontuacao.Reiniciar();
        }

        foreach (var animacao in animacoesTutorial)
        {
            animacao.GetComponent<Animator>().Rebind();
        }

        foreach (var aviao in avioes)
        {
            aviao.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    public void AvisarQueBateu(Camera camera)
    {
        if (this.jogadorMorto == true)
        {
            this.interfaceStandby.Sumir();

            switch (camera.name)
            {
                case "Camera1":
                    this.FinalizarJogoVersus(1);
                    break;
                case "Camera2":
                    this.FinalizarJogoVersus(2);
                    break;
            }
        }
        else
        {
            this.jogadorMorto = true;
            this.interfaceStandby.AtualizarTextoVersus();
            this.interfaceStandby.Mostrar(camera);
        }
    }

    public void FinalizarJogoVersus(int indiceDoVencedor)
    {
        Time.timeScale = 0;

        this.jogoFinalizado = true;
        foreach(var pontuacao in pontuacoes)
        {
            pontuacao.SalvarRecorde();
        }
        this.interfaceGameOver.MostrarGameOver(indiceDoVencedor);
    }

    private void ReviverJogadores()
    {
        this.jogadorMorto = false;

        foreach (var jogador in jogadores)
        {
            jogador.Reativar();
        }
    }
}
