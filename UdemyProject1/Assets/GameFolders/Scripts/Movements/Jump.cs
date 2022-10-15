using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.Movements
{
    public class Jump : MonoBehaviour
    {
        [SerializeField]
        float jumpForce = 350f;

        public void JumpAction(Rigidbody2D _rigidbody2D)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}

