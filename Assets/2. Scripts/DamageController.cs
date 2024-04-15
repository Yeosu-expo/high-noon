using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public enum BodyPart { Head, Torso, Arm, Leg}
    public BodyPart part;

    public float headDamage = 100f;
    public float torsoDamage = 50f;
    public float armDamage = 20f;
    public float legDamage = 30f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
            return;
        float damage = CalculateDamage();
        Health health = GetComponentInParent<Health>();
        health.ApplyDamage(damage, part);
    }

    float CalculateDamage()
    {
        switch (part)
        {
            case BodyPart.Head:
                return headDamage;
            case BodyPart.Torso:
                return torsoDamage;
            case BodyPart.Leg:
                return armDamage;
            case BodyPart.Arm:
                return legDamage;
            default:
                return 0;
        }
    }
}
