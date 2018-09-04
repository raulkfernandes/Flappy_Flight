using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoComputador : MonoBehaviour {

    private Aviao aviao;

    private void Start()
    {
        this.aviao = GetComponent<Aviao>();
        StartCoroutine(this.Impulsionar());
    }

    private IEnumerator Impulsionar()
    {
        while(true)
        {
            this.aviao.DarImpulso();
            yield return new WaitForSeconds(1);
        }
    }
}
