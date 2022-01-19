using UnityEngine;

public class OrbDestroying : MonoBehaviour
{

    public bool Killed = false;

    public GameObject CollectEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.CompareTag("Player"))
        {
            Killed = true;
            Instantiate(CollectEffect, gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
    }
}
