using UnityEngine;

public class ParticleSystemEffect : MonoBehaviour
{
    float LivingTime = 0.0f;
    public float MaxLivingTime;
    void Update()
    {
        LivingTime += Time.deltaTime;
        if (LivingTime >= MaxLivingTime)
        {
            Destroy(gameObject);
        }
    }
}
