using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject slime;
    public int xPos;
    public int zPos;
    public int yPos;
    public int enemyCount;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(190, 255);
            zPos = Random.Range(160, 245);
            yPos = Random.Range(3, 5);
            Instantiate(slime, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(12);
            enemyCount += 1;
        }
    }
}