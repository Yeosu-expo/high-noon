using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum ShootingMode { stop, hold, trace };
    public ShootingMode shootingMode;

    public Transform target;
    bool isFireReady;
    float fireDelay = 0f;
    public Weapon weapon;

    Animator anim;
    void Awake()
    {
        //target = GameManager.Instance.playerTransform;
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Aim();
        Fire();
    }

    void Aim()
    {
        if (shootingMode != ShootingMode.trace || target == null)
            return;

        transform.LookAt(target.position);

    }

    void Fire()
    {
        if(shootingMode == ShootingMode.stop)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = weapon.delay < fireDelay;

        if (isFireReady)
        {
            weapon.Use(1);
            anim.SetTrigger("doFire");
            fireDelay = 0;
        }
    }
}
