using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Controllers;
using UdemyProject1.Pools;
using UnityEngine;

namespace UdemyProject1.Combats
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] ProjectileController projectilePrefab;
        [SerializeField] Transform projectileTransform;
        [SerializeField] GameObject projectileParent;
        [SerializeField] float delayProjectile = 1f;

        float _currentDelayTime;
        bool _canLaunch = false;

        private void Update()
        {
            _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime > delayProjectile)
            {
                _canLaunch = true;
                _currentDelayTime = 0;
            }
        }
        public void LaunchAction()
        {
            if (_canLaunch)
            {
                ProjectileController poolEnemy = ProjectilePool.Instance.GetOutPool();
                poolEnemy.transform.position = projectileTransform.position;
                //poolEnemy.transform.parent = projectileParent.transform;
                poolEnemy.gameObject.SetActive(true);
                _canLaunch = false;
            }

        }
    }

    /* Pool'da önce
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] ProjectileController projectilePrefab;
        [SerializeField] Transform projectileTransform;
        [SerializeField] GameObject projectileParent;
        [SerializeField] float delayProjectile = 1f;

        float _currentDelayTime;
        bool _canLaunch = false;

        private void Update()
        {
            _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime > delayProjectile)
            {
                _canLaunch = true;
                _currentDelayTime = 0;
            }
        }
        public void LaunchAction()
        {
            if (_canLaunch)
            {
                ProjectileController newProjectile = Instantiate(projectilePrefab, projectileTransform.position, Quaternion.identity);
                // Projectile'e parent atama iþlemi (Instantiate edilince Hierarchy penceresinde nerede oluþacak)
                newProjectile.transform.parent = projectileParent.transform;
                _canLaunch = false;
            }
            
        }
    }
    */
}

