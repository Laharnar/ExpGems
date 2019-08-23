using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    [SerializeField] Transform enemyPrefab;
    [SerializeField] float spawnRate;
    [SerializeField] Vector3 levelBounds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(Mathf.Clamp(spawnRate, 0.0001f, 100000));
        }
    }

    void Spawn()
    {
        if (enemyPrefab == null) return;

        Instantiate(enemyPrefab, RandomPosition(levelBounds, transform.position), RandomRotation());
    }

    private Vector3 RandomPosition(Vector3 bounds, Vector3 center)
    {
        return center + new Vector3(
            UnityEngine.Random.Range(0, bounds.x),
            UnityEngine.Random.Range(0, bounds.y),
            UnityEngine.Random.Range(0, bounds.z)
            )-bounds/2;
    }

    private Quaternion RandomRotation()
    {
        return Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, levelBounds);
    }
}
