using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;

    private float spawnInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {        
        var x = Random.Range(-7, 7);
        var z = Random.Range(-7, 7);
        var drag = Random.Range(0f, 2f);

        var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, z), Quaternion.identity);
        hazard.GetComponent<Rigidbody>().drag = drag;

        if(spawnInterval > 0.2f) {
            spawnInterval = spawnInterval -= 0.1f;
        }

        yield return new WaitForSeconds(spawnInterval);

        yield return SpawnHazards();
    }
}
