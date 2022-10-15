using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Spawners;
using UdemyProject1.Controllers;
using UdemyProject1.Pools;
using UnityEngine;

namespace UdemyProject1.Spawners
{
    public class RedDragonSpawner : BaseSpawner
    {
        protected override void Spawn()
        {
            EnemyController poolEnemy = RedDragonPool.Instance.GetOutPool();
            poolEnemy.transform.position = this.transform.position;
            poolEnemy.gameObject.SetActive(true);
        }
    }

    /* Pool'dan önce
    public class RedDragonSpawner : BaseSpawner
    {
        [SerializeField]
        EnemyController enemy;

        protected override void Spawn()
        {
            Instantiate(enemy, this.transform);
        }
    }
    */
}

