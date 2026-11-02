using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    public Jogador2D jogador;
    public TMP_Text contadorPontos;
    public TMP_Text contadorVidas;
    public TMP_Text pontuacaoFinal;
    public TMP_Text gameover;
    public GameObject painelGameOver;


    private void Start()
    {
        painelGameOver.SetActive(false);
    }

    private void Update()
    {
        contadorPontos.text = $"Pontos: {jogador.pontos}";
        contadorVidas.text = $"Vidas: {jogador.vidas}";
    }
    public void MostrarGameOver()
    {
        painelGameOver.SetActive(true);

        pontuacaoFinal.text = $"Pontuação:\n {jogador.pontos}";
        Time.timeScale = 0f;
    }
    public void TentarNovamente()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void MostrarVitoria()
    {
        painelGameOver.SetActive(true);

        pontuacaoFinal.text = $"Pontuação:\n {jogador.pontos}";
        gameover.text = "Você venceu!";
    }
}
