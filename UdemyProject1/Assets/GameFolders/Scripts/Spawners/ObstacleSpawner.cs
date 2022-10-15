using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Spawners;
using UdemyProject1.Controllers;
using UdemyProject1.Pools;
using UnityEngine;

namespace UdemyProject1.Spawners
{
    public class ObstacleSpawner : BaseSpawner
    {
        protected override void Spawn()
        {
            EnemyController poolEnemy = ObstaclePool.Instance.GetOutPool();
            poolEnemy.transform.position = this.transform.position;
            poolEnemy.gameObject.SetActive(true);
        }
    }
}

/* Pool'dan önceki
namespace UdemyProject1.Spawners
{
    public class ObstacleSpawner : BaseSpawner
    {
        [SerializeField]
        EnemyController[] enemies;

        protected override void Spawn()
        {
            // Range method 0'da kapsar ama altýna gidemez. 4 de gelemez.
            int enemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyIndex], this.transform);
        }
    }
}
*/
