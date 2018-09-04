using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceGameOver : MonoBehaviour {
	
	[SerializeField] private GameObject fundoGameOver;
    [SerializeField] private Text pontuacaoObtida;
    [SerializeField] private Text pontuacaoRecorde;
    [SerializeField] private Text jogadorVencedor;
    [SerializeField] private Image imagemMedalha;
	[SerializeField] private Sprite medalhaOuro;
	[SerializeField] private Sprite medalhaPrata;
	[SerializeField] private Sprite medalhaBronze;
    [SerializeField] private Texture2D cursor;
    private Vector2 hotspot;
    private float cursorHotspot = 2.5f;
    [SerializeField] [Range(0.1f, 0.5f)] private float tempoDeEsperaBotoes = 0.15f;

    private Diretor diretor;
    private DiretorCoop diretorCoop;
    private DiretorVersus diretorVersus;
    private Pontuacao[] pontuacoes;
	private int recorde;

    private void Start ()
    {
        //hotspot = new Vector2(this.cursor.width / this.cursorHotspot, this.cursor.height / this.cursorHotspot);
        Cursor.visible = false;

        this.diretor = FindObjectOfType<Diretor>();
        this.diretorCoop = FindObjectOfType<DiretorCoop>();
        this.diretorVersus = FindObjectOfType<DiretorVersus>();
        this.pontuacoes = GameObject.FindObjectsOfType<Pontuacao> ();
	}

	public void MostrarGameOver (int indiceDoVencedor)
    {
        //Cursor.SetCursor(this.cursor, hotspot, CursorMode.ForceSoftware);
        Cursor.visible = true;

        this.fundoGameOver.SetActive (true);
        this.AtualizarVencedor(indiceDoVencedor);
        this.AtualizaoPontuacaoObtida (indiceDoVencedor);
        this.AtualizarRecorde ();
	}

	public void SumirGameOver ()
    {
        Cursor.visible = false;

        this.fundoGameOver.SetActive (false);
	}

    private void AtualizaoPontuacaoObtida (int indiceDoVencedor)
    {
        this.pontuacaoObtida.text = this.pontuacoes[indiceDoVencedor-1].Pontos.ToString();
    }

    private void AtualizarVencedor (int indiceDoVencedor)
    {
        this.jogadorVencedor.text = "Jogador " + indiceDoVencedor + " venceu!\nParabéns!";
    }

	private void AtualizarRecorde () {

		this.recorde = PlayerPrefs.GetInt (LiteralStrings.Recorde);
		this.pontuacaoRecorde.text = recorde.ToString ();
		this.SelecionarMedalha ();
	}

	private void SelecionarMedalha () {

        foreach(var pontuacao in pontuacoes)
        {
            if (pontuacao.Pontos >= this.recorde)
            {
                this.imagemMedalha.sprite = this.medalhaOuro;

            }
            else if (pontuacao.Pontos > this.recorde / 2)
            {
                this.imagemMedalha.sprite = this.medalhaPrata;

            }
            else
            {
                this.imagemMedalha.sprite = this.medalhaBronze;
            }
        }
	}

    public void VoltarMenu()
    {
        StartCoroutine(MudarCena(LiteralStrings.MenuScene));
    }

    IEnumerator MudarCena(string momeDaCena)
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        SceneManager.LoadScene(momeDaCena);
    }

    public void ReiniciarSolo()
    {
        StartCoroutine(ReiniciarJogo(diretor));
    }

    public void ReiniciarCoop()
    {
        StartCoroutine(ReiniciarJogo(diretorCoop));
    }

    public void ReiniciarVersus()
    {
        StartCoroutine(ReiniciarJogo(diretorVersus));
    }

    IEnumerator ReiniciarJogo (Object direcao)
    {
        yield return new WaitForSecondsRealtime(tempoDeEsperaBotoes);
        
        switch(direcao.GetType().Name)
        {
            case ("Diretor"):
                this.diretor.ReiniciarJogo();
                break;
            case ("DiretorCoop"):
                this.diretorCoop.ReiniciarJogo();
                break;
            case ("DiretorVersus"):
                this.diretorVersus.ReiniciarJogo();
                break;
        }
    }
}
