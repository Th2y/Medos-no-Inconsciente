using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuFase;
    public GameObject painelPrincipal;
    public Toggle verInf;
    public static bool menuAberto = false;

    public static Menu instancia;

    private void Start()
    {
        Time.timeScale = 1f;
        instancia = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MouseCursorAparencia.mouseOn = true;
            AbrirMenu();
        }
    }

    public void VerInf()
    {
        if (verInf.isOn)
            painelPrincipal.SetActive(true);
        else
            painelPrincipal.SetActive(false);
    }

    //Menu dentro do jogo
    public void AbrirMenu()
    {
        menuFase.SetActive(true);
        menuAberto = true;
        Time.timeScale = 0f;
    }
    public void FecharMenu()
    {
        menuFase.SetActive(false);
        MouseCursorAparencia.mouseOn = false;
        Invoke("Fechou", 1);
        Time.timeScale = 1f;
    }
    void Fechou()
    {
        menuAberto = false;
    }
    public void CarregarMenu()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "Fase1")
            DeletarKeysFase1();

        Carregamento.cenaACarregar = "Menu";
        SceneManager.LoadScene("Carregamento");
    }

    public void Venceu()
    {
        Carregamento.cenaACarregar = "Menu";
        SceneManager.LoadScene("Carregamento");
    }

    //Deletar keys
    public void DeletarKeysFase1()
    {
        PlayerPrefs.DeleteKey("ItemThay");
        PlayerPrefs.DeleteKey("ItemMio");
        PlayerPrefs.DeleteKey("PegouCarta1");
        PlayerPrefs.DeleteKey("PegouCarta2");
        PlayerPrefs.DeleteKey("PegouCarta3");
        PlayerPrefs.DeleteKey("PegouCarta4");
        PlayerPrefs.DeleteKey("PegouCarta5");
    }

    //Carregar fases
    public void CarregarFase1()
    {
        DeletarKeysFase1();

        Carregamento.cenaACarregar = "Fase1";
        SceneManager.LoadScene("Carregamento");
    }
    public void CarregarFase2()
    {
        Carregamento.cenaACarregar = "Fase2";
        SceneManager.LoadScene("Carregamento");
    }
    public void CarregarFase3()
    {
        Carregamento.cenaACarregar = "Fase3";
        SceneManager.LoadScene("Carregamento");
    }
    public void CarregarFase4()
    {
        Carregamento.cenaACarregar = "Fase4";
        SceneManager.LoadScene("Carregamento");
    }

    public void ApagarTudo()
    {
        PlayerPrefs.DeleteAll();
    }
}
