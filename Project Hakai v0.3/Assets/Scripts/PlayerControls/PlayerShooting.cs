using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    private float shootRange = 1000f;

    [SerializeField] private GameObject testPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayerShoot();
    }

    private void PlayerShoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Player")
            {
                GameObject testHit = Instantiate(testPrefab, hit.point, Quaternion.identity);
                Destroy(testHit, 3f);
            }
        }
    }
}
