using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour {

	[SerializeField] private GameObject obstaculoPrefab;
	[SerializeField] [Range (5, 10)] private float intervaloFacil;
	[SerializeField] [Range (1,  3)] private float intervaloDificil;

	private ControleDeDificuldade controleDeDificuldade;
	private float cronometro;
    private bool estaParado;

	private void Awake () {

		this.cronometro = intervaloFacil;
	}

	private void Start () {

		this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade> ();
	}

    private void Update()
    {
        if (!estaParado)
        {
            this.cronometro -= Time.deltaTime;
            if (cronometro < 0)
            {
                GameObject.Instantiate(this.obstaculoPrefab, this.transform.position, Quaternion.identity);
                this.cronometro = Mathf.Lerp(this.intervaloFacil,
                                              this.intervaloDificil,
                                              this.controleDeDificuldade.Dificuldade);
            }
        }
    }

    public void Parar ()
    {
        estaParado = true;
    }

    public void Recomecar ()
    {
        this.cronometro = intervaloFacil;
        estaParado = false;
    }
    
    public void Reiniciar ()
    {
        this.cronometro = intervaloFacil;
        this.DestruirObstaculos();
    }

    public void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
