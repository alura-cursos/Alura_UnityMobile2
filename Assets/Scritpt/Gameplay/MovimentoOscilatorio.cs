using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoOscilatorio : MonoBehaviour {

    
    [SerializeField]
    private float amplitude;
    [SerializeField]
    private float velocidade;

    private Vector3 posicaoInicial;
    private float angulo;
    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
    }

    private void Update () {
        this.angulo += this.velocidade;
        var variacao = Mathf.Sin(angulo);
        this.transform.position = this.posicaoInicial + (this.amplitude * variacao * Vector3.up);
	}
}
