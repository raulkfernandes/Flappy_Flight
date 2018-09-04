using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Aviao : MonoBehaviour {
	
	[SerializeField] [Range (5f, 15f)] private float forca;
    [SerializeField] UnityEvent aoColidir;
    [SerializeField] UnityEvent aoPassarObstaculo;

    private bool deveImpulsionar;
	private Rigidbody2D fisica;
	private Vector3 posicaoInicial;
	private Animator animacao;

	private void Awake () {

		this.posicaoInicial = this.transform.position;
		this.fisica = this.GetComponent<Rigidbody2D> ();
		this.animacao = this.GetComponent<Animator> ();
	}

	private void Update () {

		this.animacao.SetFloat ("VelocidadeY", this.fisica.velocity.y);
	}

	private void FixedUpdate () {

		if (this.deveImpulsionar) {

			Impulsionar ();
		}
	}

    public void DarImpulso ()
    {
        this.deveImpulsionar = true;
    }

	private void Impulsionar () {
		
		this.fisica.velocity = Vector2.zero;
		this.fisica.AddForce (Vector2.up * forca, ForceMode2D.Impulse);
		this.deveImpulsionar = false;
    }

    public void Reiniciar()
    {
        //this.fisica.simulated = true;
        this.transform.position = this.posicaoInicial;
    }

    private void OnCollisionEnter2D (Collision2D colisor)
    {
		this.fisica.simulated = false;
        this.aoColidir.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.aoPassarObstaculo.Invoke();
    }
}
