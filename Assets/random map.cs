using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAssetPlacer : MonoBehaviour
{
    public GameObject[] assetsToPlace;
    public int numberOfAssets = 100;
    public Vector2 spawnArea = new Vector2(500f, 500f);

    void Start()
    {
        PlaceRandomAssets();
    }

    void PlaceRandomAssets()
    {
        for (int i = 0; i < numberOfAssets; i++)
        {
            int randomIndex = Random.Range(0, assetsToPlace.Length);
            GameObject originalAsset = assetsToPlace[randomIndex];

            Vector3 randomPosition;
            GameObject instantiatedAsset = Instantiate(originalAsset, Vector3.zero, Quaternion.identity);
            string assetName = instantiatedAsset.name;

            if (assetName == "Ground_03(Clone)" || assetName == ("Ground_02(Clone)"))
            {
                randomPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 0f, Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
            }
            else
            {
                randomPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 1f, Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
            }
            instantiatedAsset.transform.position = randomPosition;
        }
    }

}

