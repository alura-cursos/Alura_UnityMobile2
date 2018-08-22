using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Pontuacao pontuacao;

    [SerializeField]
    private float tempo;
    [SerializeField]
    private float raio;

    [SerializeField]
    private ReservaDeInimigos reservaDeInimigos;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0f, this.tempo);
    }

    private void Instanciar()
    {
        if (this.reservaDeInimigos.TemInimigo())
        {
            var inimigo = this.reservaDeInimigos.PegarInimigo();
            this.DefinirPosicaoInimigo(inimigo);
            inimigo.GetComponent<Seguir>().SetAlvo(this.alvo);
            inimigo.GetComponent<Pontuavel>().SetPontuacao(this.pontuacao);
        }
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = Random.insideUnitCircle * this.raio;
        var posicaoInimigo = (Vector2)this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }
}
