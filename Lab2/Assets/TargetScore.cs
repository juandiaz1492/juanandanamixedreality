using UnityEngine;
using TMPro;

public class TargetScore : MonoBehaviour
{
    public int totalScore = 0;
    public TextMeshProUGUI scoreText;
    public ParticleSystem hitParticles;

    private Vector3 posicionInicial;
    private Rigidbody fisicasPelota;

    void Start()
    {
        // Al darle al Play, buscamos la pelota y guardamos su posición y sus físicas
        GameObject pelota = GameObject.Find("Pelota");
        if (pelota != null)
        {
            posicionInicial = pelota.transform.position;
            fisicasPelota = pelota.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Pelota")
        {
            float distance = Vector3.Distance(other.transform.position, transform.position);

            int points = 0;
            if (distance < 0.3f) points = 50;
            else if (distance < 0.8f) points = 20;
            else points = 5;

            totalScore += points;

            if (scoreText != null)
            {
                scoreText.text = "Points: " + totalScore;
            }

            GetComponent<Renderer>().material.color = Random.ColorHSV();

            if (hitParticles != null)
            {
                hitParticles.Play();
            }

            // Devolver la pelota a su sitio y frenarla en seco
            other.transform.position = posicionInicial;
            if (fisicasPelota != null)
            {
                fisicasPelota.linearVelocity = Vector3.zero;
                fisicasPelota.angularVelocity = Vector3.zero;
            }
        }
    }
}