using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Controllers;
using UdemyProject1.Pools;
using UnityEngine;

namespace UdemyProject1.Controllers
{
    public class ProjectileController : LifeCycleController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();

            if (enemy != null)
            {
                GameManager.Instance.IncreaseScore();
                if (collision.gameObject.tag == "destroyable")
                {
                    enemy.KillGameObject();
                }
            }
            KillGameObject();
        }

        public override void KillGameObject()
        {
            _currentTime = 0f;
            ProjectilePool.Instance.PutInPool(this);
        }
    }

    /* Pool'dan önce
    public class ProjectileController : LifeCycleController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();

            if (enemy != null)
            {
                GameManager.Instance.IncreaseScore();
                if (collision.gameObject.tag == "destroyable")
                {
                    Destroy(enemy.gameObject);
                    DestroyObject(this.gameObject);
                }
                else
                {
                    DestroyObject(this.gameObject);
                }                
            }
        }
        void DestroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
    */
}

