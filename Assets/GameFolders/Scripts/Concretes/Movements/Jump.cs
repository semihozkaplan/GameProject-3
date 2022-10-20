using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Controller;
using ProjectGame3.Controllers;
using ProjectGame3.Abstracts.Movements;

namespace ProjectGame3.Movements
{

    public class Jump : IJump
    {
        float _jumpForce = 330f;
        Rigidbody2D _rigidbody2D;
        IOnGround _onGround;

        public bool IsJump { get; set; }

        public Jump(Rigidbody2D rigidbody2D, IOnGround onGround)
        {

            _rigidbody2D = rigidbody2D;
            _onGround = onGround;

        }


        public void TickWithFixedUpdate()
        {

            if (IsJump && _onGround.IsOnGround)
            {
                
                _rigidbody2D.velocity = Vector2.zero;

                _rigidbody2D.AddForce(Vector2.up * _jumpForce);

                _rigidbody2D.velocity = Vector2.zero;


            }

            IsJump = false;

        }

    }

}


