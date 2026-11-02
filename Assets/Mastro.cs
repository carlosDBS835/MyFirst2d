using UnityEngine;

public class Mastro : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jogador2D jogador = collision.GetComponent<Jogador2D>();

            if (jogador is not null)
                jogador.Vencer();
        }
    }
}
