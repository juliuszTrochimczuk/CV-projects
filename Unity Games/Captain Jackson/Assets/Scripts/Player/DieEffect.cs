using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public Skin DieEffectSkin = new Skin();

    [Header("Lists")]
    List<Sprite> ShatterSprite;
    public List<ParticleSystem> Particles;

    void Start()
    {
        ShatterSprite = DieEffectSkin.Skins[PlayerData.ActiveSkin].SpeedSprites;
        for (int i = 0; i <= 2; i++)
        {
            Particles[i].textureSheetAnimation.SetSprite(0, ShatterSprite[i]);
        }
    }
}
