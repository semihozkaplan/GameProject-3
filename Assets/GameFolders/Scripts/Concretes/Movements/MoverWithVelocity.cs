using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Controllers;

namespace ProjectGame3.Movements
{

    public class MoverWithVelocity : IMover
    {

        Rigidbody2D _rigidbody2D;

        float _moveSpeed = 90f;

        public MoverWithVelocity(PlayerController playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }

        public void Tick(float horizontal)
        {   //normalized nedir ?
            //Time.fixedDeltaTime, fiziki işlemler için kullandığımız saniyedeki frame rate tir.

            if(_rigidbody2D.velocity.magnitude >= 5f) return;
            
            Vector2 direction = new Vector2(horizontal, 0f);
            Vector2 movement = direction.normalized * Time.fixedDeltaTime * _moveSpeed;

            _rigidbody2D.velocity = movement;
            
        }

    }

}


