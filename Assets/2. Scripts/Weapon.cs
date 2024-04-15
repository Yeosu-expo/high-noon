using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int bulletCount;
    public int maxBulletCount = 5;
    public float delay = 0.2f;
    public Transform bulletPos;

    void Awake()
    {
        bulletCount = maxBulletCount;
    }
    public void Use(int layerNum)
    {
        StopCoroutine("Fire");
        if (bulletCount > 0)
        {
            bulletCount--;
            StartCoroutine(Fire(layerNum));
        }
    }

    IEnumerator Fire(int layerNum)
    {
        GameObject bullet = GameManager.Instance.pool.Get(0, bulletPos);
        bullet.layer = layerNum + 8;
        Rigidbody bulletRigid = bullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.right * 100;
        yield return null;
    }

}
