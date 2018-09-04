using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {

	[SerializeField] private VelocidadeCompartilhada velocidadeCompartilhada;
    [SerializeField] private GameObject obstaculoCima;
    [SerializeField] private GameObject obstaculoBaixo;
    [Range (0, 1.7f)] public float variacaoEmY;
    private ControleDeDificuldade controleDeDificuldade;

    private void Start ()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();

        this.transform.Translate (Vector3.up * Random.Range (-variacaoEmY, variacaoEmY));

        // Reduzir espaço entre os obstaculos ao longo do tempo:
        this.obstaculoCima.transform.Translate(Vector3.down * controleDeDificuldade.Dificuldade);
        this.obstaculoBaixo.transform.Translate(Vector3.up  * controleDeDificuldade.Dificuldade);
    }

	private void Update () {
		
		this.transform.Translate (Vector3.left * velocidadeCompartilhada.velocidade * Time.deltaTime);
	}

	private void OnTriggerEnter2D (Collider2D collider2D) {

        if (collider2D.CompareTag(LiteralStrings.BarreiraDeObstaculos))
        {
            this.Destruir();
        }
	}

	public void Destruir () {
		
		GameObject.Destroy (this.gameObject);
	}
}
