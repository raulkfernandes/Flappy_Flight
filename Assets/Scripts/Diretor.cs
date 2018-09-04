using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour {

	protected bool jogoFinalizado;
	private Aviao aviao;
	private Pontuacao pontuacao;
	protected InterfaceGameOver interfaceGameOver;
	protected ControleDeDificuldade dificuldade;
    private Animator animacaoAviao;
    private GameObject animacaoTutorial;
    private ControlaJogador jogador;
    private GeradorDeObstaculos[] geradoresDeObstaculos;

    protected virtual void Start () {

		this.aviao = GameObject.FindObjectOfType<Aviao> ();
		this.pontuacao = GameObject.FindObjectOfType<Pontuacao> ();
		this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver> ();
		this.dificuldade = GameObject.FindObjectOfType<ControleDeDificuldade> ();
        this.animacaoTutorial = GameObject.FindGameObjectWithTag(LiteralStrings.CanvasTutorial);
        this.jogador = FindObjectOfType<ControlaJogador>();
        this.geradoresDeObstaculos = FindObjectsOfType<GeradorDeObstaculos>();
    }

	public void FinalizarJogo ()
    {
        Time.timeScale = 0;

        this.jogoFinalizado = true;
		this.pontuacao.SalvarRecorde ();
		this.interfaceGameOver.MostrarGameOver (1);
        this.jogador.Desativar();
    }

	public virtual void ReiniciarJogo ()
    {
		if (this.jogoFinalizado == true)
        {
			Time.timeScale = 1;

            this.interfaceGameOver.SumirGameOver ();
			this.aviao.Reiniciar ();
			this.pontuacao.Reiniciar ();
			this.dificuldade.Reiniciar ();
			this.jogoFinalizado = false;
            this.animacaoTutorial.GetComponent<Animator>().Rebind();
            this.jogador.Reativar();

            foreach(var gerador in geradoresDeObstaculos)
            {
                gerador.Reiniciar();
            }
        }
	}
}
