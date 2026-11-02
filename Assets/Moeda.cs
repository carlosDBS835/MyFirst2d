using UnityEngine;

public class Moeda : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float velocidadeFlutuar = 2f;
    public float velocidadeGiro = 120f;


    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jogador2D jogador = collision.GetComponent<Jogador2D>();
            jogador.pontos++;
            Debug.Log($"Pontos:{jogador.pontos}");
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(0, velocidadeGiro * Time.deltaTime, 0);

        float flutuar = Mathf.Sin(Time.time * velocidadeFlutuar) * amplitude;

        var deslocamento = new Vector3(0f, flutuar, 0f);

        transform.position = posicaoInicial + deslocamento;

    }
}
