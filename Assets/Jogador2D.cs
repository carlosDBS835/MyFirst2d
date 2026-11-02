using UnityEngine;

public class Jogador2D : MonoBehaviour
{
    public LayerMask chao;
    public Transform peDoJogador;
    public float raioPe = 0.2f;
    public float forcaPulo = 7f;
    public float velocidade = 4f;
    public float coyoteTime = 0.1f;
    public int pontos = 0;
    public float limiteQueda = -6f;
    public int vidas = 3;

    public Hud hud;
    private Rigidbody2D rb;
    private float tempoDesdeQueTavaNoChao = -999f;
    private Vector2 posicaoInicial;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = rb.position;
    }
    private void Update()
    {
        if (rb.position.y < limiteQueda)
        {
            Morrer();
            return;
        }

        //movimento do jogador(em 2d so vai para a direi ou esquerda)
        float x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(x * velocidade, rb.linearVelocityY);

        //efeito coyote
        if (TaNoChao())
            tempoDesdeQueTavaNoChao = Time.time;

        //pulo do jogador
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - tempoDesdeQueTavaNoChao <= coyoteTime)
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);

        Virar(x);
    }

    private bool TaNoChao()
    {
        return Physics2D.OverlapCircle(peDoJogador.position, raioPe, chao);
    }
    private void OnDrawGizmos()
    {
        if (peDoJogador != null)
        {
            Gizmos.DrawWireSphere(peDoJogador.position, raioPe);
        }
    }
    private void Virar(float x)
    {

        //virar o jogador de acordo com a direção do movimento
        Vector3 escala = transform.localScale;
        if (x > 0)
            escala.x = Mathf.Abs(escala.x);
        if (x < 0)
            escala.x = -Mathf.Abs(escala.x);
        transform.localScale = escala;
    }
    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = posicaoInicial;

        tempoDesdeQueTavaNoChao = -999f;
    }

    public void Morrer()
    {
        if (vidas <= 0)
        {
            return;
        }
        vidas--;

        if (vidas <= 0)
        {
            GameOver();
            return;
        }
        Respawn();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        hud.MostrarGameOver();
    }
    public void Vencer()
    {
        hud.MostrarVitoria();
    }
}
