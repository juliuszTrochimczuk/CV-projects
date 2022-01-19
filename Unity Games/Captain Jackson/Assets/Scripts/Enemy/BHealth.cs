using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHealth : MonoBehaviour
{
    [Header("Health")]
    public int Health;

    void DamageToBoss()
    {
        Health -= 1;
    }
}
