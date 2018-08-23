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
    private Rect area;

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
        var posicaoAleatoria = new Vector2(
                Random.Range(this.area.x , this.area.x + this.area.width),
                Random.Range(this.area.y, this.area.y + this.area.height)
            );
        var posicaoInimigo = (Vector2)this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(100, 0, 100);
        var posicao = this.area.position + (Vector2)this.transform.position + this.area.size/2;
        Gizmos.DrawWireCube(posicao, this.area.size);
    }

}
