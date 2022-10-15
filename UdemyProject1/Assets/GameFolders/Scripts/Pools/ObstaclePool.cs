using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Pools;
using UdemyProject1.Controllers;
using UnityEngine;

namespace UdemyProject1.Pools
{
    public class ObstaclePool : GenericPool<ObstacleController>
    {
        public static ObstaclePool Instance { get; private set; }

        public override void ResetAllObjects()
        {
            foreach (ObstacleController child in GetComponentsInChildren<ObstacleController>())
            {
                if (!child.gameObject.activeSelf) continue;

                child.KillGameObject();
            }
        }

        protected override void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

