using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Inputs;
using ProjectGame3.Inputs;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Movements;
using ProjectGame3.Abstracts.Animations;
using ProjectGame3.Animations;
using ProjectGame3.Abstracts.Controller;
using ProjectGame3.Uis;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Combats;
using ProjectGame3.Managers;

namespace ProjectGame3.Controllers
{

    //Burada IEntityController isimli interfaceden miras almamızın nedeni bir tek Transformu diğer Controllerlerdada kullanabilelim diyedir
    //Mesela EnemyController geldiğinde flip işlemleri için sadece IEntityController den miras alması yeterli olacaktır böylece Flip classında bir değişikliğe gitmeden kullanabileceğiz çünkü interfacenin içine transformu verdik
    public class PlayerController : MonoBehaviour, IEntityController
    {

        [SerializeField] float moveSpeed = 3f;

        IPlayerInput _playerInput;
        IMover _mover;
        IMyAnimations _animations;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        IHealth _health;

        float _horizontal;

        private void Awake()
        {

            _playerInput = new MobileInputs();
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animations = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _onGround = GetComponent<IOnGround>();
            _jump = new Jump(GetComponent<Rigidbody2D>(), _onGround);
            _health = GetComponent<IHealth>();

        }

        private void OnEnable()
        {

            _health.OnDead += _animations.DeadAnimation;
            _health.OnDead += GameManager.Instance.SaveScore; // Öldüğü zaman elimizdeki scoru set et yani sakla.

        }

        private void Start()
        {

            GameOverObject gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);

        }

        private void Update()
        {

            if (_health.IsDead) return;

            _horizontal = _playerInput.Horizontal;
            
            
            if (_playerInput.AttackButton && _horizontal == 0f)
            {

                _animations.AttackAnimation();
                return;

            }

            if (_playerInput.JumpButton)
            {

                _jump.IsJump = true;

            }

            _animations.JumpAnimation(!_onGround.IsOnGround);
            _animations.MoveAnimation(_horizontal);

        }

        private void FixedUpdate()
        {

            _flip.FlipAction(_horizontal);
            _mover.Tick(_horizontal);
            _jump.TickWithFixedUpdate();

        }


    }

}


