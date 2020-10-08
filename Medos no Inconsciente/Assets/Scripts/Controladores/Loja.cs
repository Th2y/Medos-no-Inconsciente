using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loja : MonoBehaviour
{
	[Header ("Dinheiro")]
	public Text dinheiroAtual;
	public Text dinheiroMunicao;
	public Text dinheiroRecarga;
	public Text dinheiroInsuficiente;

	[Header("Quantidade Atual")]
	public Text quantidadeMunicaoAtual;
	public Text quantidadeRecargaAtual;

	[Header("Quantidade Aumentar")]
	public Text quantidadeMunicaoAumentar;
	public Text quantidadeRecargaAumentar;

	[Header("Botões")]
	public Button botaoMunicao;
	public Button botaoRecarga;
	public GameObject Municao;
	public GameObject Recarga;

	[HideInInspector]
	public int atualMunicao;
	[HideInInspector]
	public float atualRecarga;
	[HideInInspector]
	public int moedas;

	private float tempo = 0f;
	private bool aviso = false;
	bool mudou = false;

	public static Loja instancia;

    private void Start()
    {
		instancia = this;

		if (PlayerPrefs.GetInt("Moedas") < 0)
			PlayerPrefs.SetInt("Moedas", 0);
		if (PlayerPrefs.GetInt("Municao") < 5)
			PlayerPrefs.SetInt("Municao", 5);
		if (PlayerPrefs.GetFloat("Recarga") > 10)
			PlayerPrefs.SetFloat("Recarga", 10);
		if(!PlayerPrefs.HasKey("ComprouRecarga"))
			PlayerPrefs.SetFloat("Recarga", 10);

		moedas = PlayerPrefs.GetInt("Moedas");
		atualMunicao = PlayerPrefs.GetInt("Municao");
		atualRecarga = PlayerPrefs.GetFloat("Recarga");

		dinheiroAtual.text = PlayerPrefs.GetInt("Moedas", moedas).ToString();
		quantidadeMunicaoAtual.text = "Atual: " + PlayerPrefs.GetInt("Municao", atualMunicao).ToString();
		quantidadeRecargaAtual.text = "Atual: " + PlayerPrefs.GetFloat("Recarga", atualRecarga).ToString();

		quantidadeMunicaoAumentar.text = "Aumentar: " + "1";
		quantidadeRecargaAumentar.text = "Diminuir: " + "2";

		PlayerPrefs.SetInt("Municao", atualMunicao);
		PlayerPrefs.SetFloat("Recarga", atualRecarga);
	}

    private void Update()
    {
        if(mudou || PlayerPrefs.GetString("Mudou") == "true")
        {
			dinheiroAtual.text = PlayerPrefs.GetInt("Moedas", moedas).ToString();
			quantidadeMunicaoAtual.text = "Atual: " + PlayerPrefs.GetInt("Municao", atualMunicao).ToString();
			quantidadeRecargaAtual.text = "Atual: " + PlayerPrefs.GetFloat("Recarga", atualRecarga).ToString();

			mudou = false;
			PlayerPrefs.SetString("Mudou", "false");
		}

		if (aviso)
        {
			dinheiroInsuficiente.gameObject.SetActive(true);
			tempo += Time.deltaTime;
			if (tempo >= 1f)
            {
				tempo = 0f;
				aviso = false;
				dinheiroInsuficiente.gameObject.SetActive(false);
			}
		}
    }

    public void MunicaoSim()
	{
		mudou = true;
		if (PlayerPrefs.GetInt("Municao") <= 0)
			PlayerPrefs.SetInt("Municao", 5);

		else if (PlayerPrefs.GetInt("Municao") < 10)
		{
			moedas = PlayerPrefs.GetInt("Moedas") - 10;
			PlayerPrefs.SetInt("Moedas", moedas);

			atualMunicao = PlayerPrefs.GetInt("Municao") + 1;
			PlayerPrefs.SetInt("Municao", atualMunicao);
		}
		else
			botaoMunicao.interactable = false;
	}

	public void ComprarMunicao()
    {
		if (PlayerPrefs.GetInt("Moedas", moedas) >= 10)
		{
			Municao.SetActive(true);
		}
		else
		{
			aviso = true;
			Municao.SetActive(false);
		}
	}

	public void RecargaSim()
    {
		PlayerPrefs.SetString("ComprouRecarga", "sim");
		mudou = true;

		if (PlayerPrefs.GetFloat("Recarga") > 10)
			PlayerPrefs.SetFloat("Recarga", 10);

		else if (PlayerPrefs.GetFloat("Recarga") >= 2)
		{
			moedas = PlayerPrefs.GetInt("Moedas") - 10;
			PlayerPrefs.SetInt("Moedas", moedas);

			atualRecarga = PlayerPrefs.GetFloat("Recarga") - 2f;
			PlayerPrefs.SetFloat("Recarga", atualRecarga);
		}
		else
			botaoRecarga.interactable = false;
	}

	public void ComprarRecarga()
	{
		if (PlayerPrefs.GetInt("Moedas", moedas) >= 10)
		{
			Recarga.SetActive(true);
		}
		else
        {
			aviso = true;
			Recarga.SetActive(false);
		}
	}

	public void GanharMoedas()
    {
		moedas = PlayerPrefs.GetInt("Moedas") + Random.Range(10, 20);
		PlayerPrefs.SetInt("Moedas", moedas);
	}
}
