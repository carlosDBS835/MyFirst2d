using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Transform alvo;
    public float suavidade = 5f;
    private float yFixo;

    private void Start()
    {
        yFixo = transform.position.y;
    }
    void LateUpdate()
    {
        Vector3 destino = new(alvo.position.x, yFixo, -10f);

        transform.position = Vector3.Lerp(transform.position, destino, suavidade * Time.deltaTime);
    }
}
