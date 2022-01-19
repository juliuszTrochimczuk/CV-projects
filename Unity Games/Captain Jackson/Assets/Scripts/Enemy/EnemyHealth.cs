using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool Died;

    public bool ReadyToFight = false;

    public GameObject ExplosionEffect;
    public Transform placeToRender;

    AudioManager AudioPlayer;

    void Start()
    {
        AudioPlayer = FindObjectOfType<AudioManager>();
    }

    public void DamagingObject()
    {
        if (ReadyToFight && !Died)
        {
            Died = true;
            AudioPlayer.PlayAudio("EnemyDestroy");
            DieEffect();
        }
    }

    public void DieEffect()
    {
        Instantiate(ExplosionEffect, placeToRender.position, placeToRender.rotation);
    }
}
