using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;

namespace ProjectGame3.Movements
{

    public class MultiJump : IJump
    {

        Rigidbody2D _rigidbody2D;
        IOnGround _onGround;

        float _jumpForce = 350f;
        int _maxJumpCount = 2;
        int _currentJumpCount = 0;

        public bool IsJump { get; set; }

        public MultiJump(Rigidbody2D rigidbody2D, IOnGround onGround)
        {

            _rigidbody2D = rigidbody2D;
            _onGround = onGround;

        }

        public void TickWithFixedUpdate()
        {

            if (IsJump && _onGround.IsOnGround)
            {

                if (_currentJumpCount < _maxJumpCount)
                {

                    _rigidbody2D.velocity = Vector2.zero;

                    _rigidbody2D.AddForce(Vector2.up * _jumpForce);

                    _rigidbody2D.velocity = Vector2.zero;

                    _currentJumpCount++;


                }

                else if (_onGround.IsOnGround)
                {

                    IsJump = false;
                    _currentJumpCount = 0;
                    
                }

            }

        }

    }


}

