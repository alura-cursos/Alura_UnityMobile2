using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaDeInimigos : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int quantidade;

    private Stack<GameObject> reservaDeInimigos;

    private void Start () {
        this.reservaDeInimigos = new Stack<GameObject>();
        this.CriarTodosOsInimigos();
	}
	
    private void CriarTodosOsInimigos()
    {
        for(var i =0; i<this.quantidade; i++)
        {
            var inimigo = GameObject.Instantiate(this.prefab, this.transform);
            inimigo.SetActive(false);
            this.reservaDeInimigos.Push(inimigo);
        }
    }

    public GameObject PegarInimigo()
    {
        return this.reservaDeInimigos.Pop();
    }

    public bool TemInimigo()
    {
        return this.reservaDeInimigos.Count > 0;
    }
}
