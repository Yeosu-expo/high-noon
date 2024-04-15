using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager.Identifier identifier;

    public float health;
    public float maxHealth = 100f;

    List<DamageController.BodyPart> hitList;

    void Awake()
    {
        hitList = new List<DamageController.BodyPart>();
        health = maxHealth;
    }

    public void ApplyDamage(float damage, DamageController.BodyPart hitPart)
    {
        if (!GameManager.Instance.isFirstShot)
        {
            GameManager.Instance.firstHitter = identifier;
            GameManager.Instance.isFirstShot = true;
        }
        hitList.Add(hitPart);
        health -= damage;
    }
}
