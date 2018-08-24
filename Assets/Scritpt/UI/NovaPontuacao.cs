using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaPontuacao : MonoBehaviour {
    [SerializeField]
    private TextoDinamico textoPontuacao;
    [SerializeField]
    private TextoDinamico textoNome;
    [SerializeField]
    private Ranking ranking;

    private string id;
    private Pontuacao pontuacao;
	
	private void Start ()
    {
        int totalDePontos = this.GetPontuacao();
        string nomeDaPessoa = this.GetNome();
        this.textoPontuacao.AtualizarTexto(totalDePontos);
        this.textoNome.AtualizarTexto(nomeDaPessoa);
        this.id = this.ranking.AdicionarPontuacao(totalDePontos, nomeDaPessoa);
    }

    private string GetNome()
    {
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            return PlayerPrefs.GetString("UltimoNome");
        }
        return "Nome";
    }
    private int GetPontuacao()
    {
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        var totalDePontos = -1;
        if (this.pontuacao != null)
        {
            totalDePontos = this.pontuacao.Pontos;
        }

        return totalDePontos;
    }

    public void AlterarNome(string nome)
    {
        this.ranking.AlterarNome(nome, this.id);
        PlayerPrefs.SetString("UltimoNome", nome);
    }
}
