using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLock : MonoBehaviour
{
    public static AutoLock instance;

    public GameObject player;

    public bool lockTarget = false;
    public GameObject lockTargetEnemy;
    private float lockRange = 10f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) LockTarget();
        if (lockTargetEnemy == null && lockTarget == true) AutoChangeLockTarget();
    }

    private void LockTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (Vector3.Distance(player.transform.position, hit.collider.transform.position) <= lockRange)
                {
                    lockTargetEnemy = hit.collider.gameObject;
                    lockTarget = true;
                }
            }
            else
            {
                lockTargetEnemy = null;
                lockTarget = false;
            }
        }
    }

    private void AutoChangeLockTarget()
    {
        // change lock target upon death
        Collider[] collidersInRange = Physics.OverlapSphere(player.transform.position, lockRange);

        // check for enemy in range and calculate distance
        float shortestDist = 0f;
        GameObject closestEnemy = null;

        foreach (Collider colliderInRange in collidersInRange)
        {
            if (colliderInRange.gameObject.tag == "Enemy")
            {
                float enemyDist = Vector3.Distance(player.transform.position, colliderInRange.transform.position);
                if (enemyDist >= shortestDist)
                {
                    shortestDist = enemyDist;
                    closestEnemy = colliderInRange.gameObject;
                }
            }
        }

        if (closestEnemy != null)
        {
            lockTargetEnemy = closestEnemy;
        }
        else
        {
            lockTarget = false;
        }
    }
}
