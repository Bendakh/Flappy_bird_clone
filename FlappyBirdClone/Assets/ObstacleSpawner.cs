using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const float minY = -4f;
    private const float maxY = 3f;
    Vector2 temppPosition;
    [SerializeField]
    GameObject obstaclePrefab;
    [SerializeField]
    private float frequency;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }


    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            temppPosition = new Vector2(this.transform.position.x, Random.Range(minY, maxY));
            Instantiate(obstaclePrefab, temppPosition, Quaternion.identity);
            yield return new WaitForSeconds(frequency);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
