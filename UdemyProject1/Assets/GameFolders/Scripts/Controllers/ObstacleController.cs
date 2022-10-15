using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Pools;
using UnityEngine;

namespace UdemyProject1.Controllers
{
    public class ObstacleController : EnemyController
    {
        public override void PutInPoolEnemy()
        {
            ObstaclePool.Instance.PutInPool(this);
        }
    }
}

