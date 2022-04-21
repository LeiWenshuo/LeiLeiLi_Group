using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public EnemyProducer enemyProducer;
    public GameObject playerPrefab;
    public string sceneName;
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.onPlayerDeath += onPlayerDeath;
    }

    void onPlayerDeath(Player player)
    {
        enemyProducer.SpawnEnemies(false);
        Destroy(player.gameObject);

        SceneManager.LoadScene(sceneName);
    }

    
}
