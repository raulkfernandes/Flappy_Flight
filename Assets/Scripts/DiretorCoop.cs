using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorCoop : Diretor {

    private bool jogadorMorto;
    private int pontosAposBater;
    [SerializeField] [Range(1, 10)] private int pontosParaReviver;
    private ControlaJogador[] jogadores;
    private InterfaceStandby interfaceStandby;
    private GameObject[] animacoesTutorial;
    private GameObject[] avioes;

    protected override void Start ()
    {
        base.Start();
        this.jogadores = FindObjectsOfType<ControlaJogador>();
        this.interfaceStandby = FindObjectOfType<InterfaceStandby>();
        this.animacoesTutorial = GameObject.FindGameObjectsWithTag(LiteralStrings.CanvasTutorial);
        this.avioes = GameObject.FindGameObjectsWithTag(LiteralStrings.Aviao);
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        this.ReviverJogadores();

        foreach(var animacao in animacoesTutorial)
        {
            animacao.GetComponent<Animator>().Rebind();
        }

        foreach(var aviao in avioes)
        {
            aviao.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    public void AvisarQueBateu (Camera camera)
    {
        if(this.jogadorMorto == true)
        {
            this.interfaceStandby.Sumir();
            this.FinalizarJogo();
        }
        else
        {
            this.jogadorMorto = true;
            this.pontosAposBater = 0;
            this.interfaceStandby.AtualizarTexto(this.pontosParaReviver);
            this.interfaceStandby.Mostrar(camera);
        }
    }

    public void TentarReviver ()
    {
        if(this.jogadorMorto)
        {
            this.pontosAposBater++;
            this.interfaceStandby.AtualizarTexto(this.pontosParaReviver - this.pontosAposBater);
            if (this.pontosAposBater >= this.pontosParaReviver)
            {
                this.interfaceStandby.Sumir();
                this.ReviverJogadores();
            }
        }
    }

    private void ReviverJogadores ()
    {
        this.jogadorMorto = false;

        foreach (var jogador in jogadores)
        {
            jogador.Reativar();
        }
    }
}
