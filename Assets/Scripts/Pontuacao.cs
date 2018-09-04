using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour {

	[SerializeField] private Text textoPontuacao;
    [SerializeField] private UnityEvent aoPontuar;
	private AudioSource audioPontuacao;
	public int Pontos { get; private set; }

	private void Awake () {
		
		this.audioPontuacao = this.GetComponent<AudioSource> ();
	}

	public void AdicionarPontos () {

		this.Pontos++;
		this.textoPontuacao.text = this.Pontos.ToString ();
		this.audioPontuacao.Play ();
        this.aoPontuar.Invoke ();
	}

	public void Reiniciar () {

		this.Pontos = 0;
		this.textoPontuacao.text = this.Pontos.ToString ();
		this.textoPontuacao.enabled = true;
	}

	public void SalvarRecorde () {

		int recordeAtual = PlayerPrefs.GetInt (LiteralStrings.Recorde);
		if (this.Pontos > recordeAtual) {

			PlayerPrefs.SetInt (LiteralStrings.Recorde, this.Pontos);
		}

		this.textoPontuacao.enabled = false;
	}
}
