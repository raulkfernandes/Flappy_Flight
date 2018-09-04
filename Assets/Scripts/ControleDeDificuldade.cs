using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour {

	[SerializeField] [Range (20, 60)] private float tempoMaxDificuldade;
	private float tempoPassado;
	public float Dificuldade { get; private set; } // Variável representando o conceito de uma 'Propriedade' dessa classe

	private void Update () {

		this.tempoPassado += Time.deltaTime;
		this.Dificuldade = this.tempoPassado / this.tempoMaxDificuldade; // Começa em 0 e vai sendo acrescido gradativamente
		this.Dificuldade = Mathf.Min (this.Dificuldade, 1); // Limitar o crescimento da variável de 0 até 1
	}

	public void Reiniciar () {

		this.tempoPassado = 0;
	}
}
