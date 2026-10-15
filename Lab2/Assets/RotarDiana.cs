using UnityEngine;

public class RotarDiana : MonoBehaviour
{
    public float velocidad = 50f;

    void Update()
    {
        // Rota la diana sobre su propio eje Y un poco cada frame
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
}