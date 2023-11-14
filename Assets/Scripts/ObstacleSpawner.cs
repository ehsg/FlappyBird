using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;

        if (gameManager.isGameOver())
            return;

        cooldown -= Time.deltaTime;
        if (cooldown < 0f)
        {
            //Update Cooldown
            cooldown = gameManager.obstacleInterval;

            //Spawn Obstacle
            int prefabIndex = Random.Range(0, gameManager.Obstacleprefabs.Count);
            GameObject prefab = gameManager.Obstacleprefabs[prefabIndex];

            Quaternion rotation = prefab.transform.rotation;
            float x = gameManager.obstacleOffSetX;
            float y = Random.Range(gameManager.obstacleOffSetY.x, gameManager.obstacleOffSetY.y);
            Vector3 position = new Vector3(x, y, 0);
            Instantiate(prefab, position, rotation);
        }
    }
}
