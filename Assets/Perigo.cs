using UnityEngine;

public class Perigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jogador2D jogador = collision.GetComponent<Jogador2D>();

            if (jogador != null)
            {
                jogador.Morrer();
            }
        }
    }
}
