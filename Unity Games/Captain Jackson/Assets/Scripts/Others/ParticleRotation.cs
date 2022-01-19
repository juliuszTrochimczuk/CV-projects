using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour
{
    public Transform parentTransform;
    ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        var main = particle.main;
        main.startRotationZ = (parentTransform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
    }
}