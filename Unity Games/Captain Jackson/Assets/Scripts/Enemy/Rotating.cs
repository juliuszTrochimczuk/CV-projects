using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float Degree;
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, Degree * Time.deltaTime);
    }
}
