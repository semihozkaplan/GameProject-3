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
using ProjectGame3.StateMachines;
using ProjectGame3.StateMachines.EnemyState;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Combats;

namespace ProjectGame3.Controllers
{

    public class EnemyController : MonoBehaviour, IEntityController
    {
        [Header("Movements")]
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] Transform[] patrols;


        [Header("Combats")]
        [SerializeField] float chaseDistance = 3f; //Playeri hangi mesafeden tespit edip kovalayacak onu gösteriyor.
        [SerializeField] float attackDistance = 1f;
        [SerializeField] float maxAttackTime = 1.5f;

        [Header("Score")]
        [SerializeField] ScoreController scorePrefab;
        [SerializeField] int currentScoreChance;
        [SerializeField] int maxScoreChange = 70;
        [SerializeField] int minScoreChange = 20;

        StateMachine _stateMachine;
        IEntityController _player;



        private void Awake()
        {

            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();

        }

        private IEnumerator Start()
        {

            currentScoreChance = Random.Range(minScoreChange, maxScoreChange); // Herbir düşmanda elmas düşmesin diye elmas düşme şansını burada Random Methodu ile ayarladık.

            // Normalde cache işlemleri için globalde classın nesnesini oluşturur ve cache işlemini awake içinde yapardık fakat
            // zaten aynı classları statemachine içerisinden tutuyor bu yüzden birden fazla gereksiz referans almamak için çoğu classları 
            // burada cacheledik çünkü zaten statemachine global field halinde hepsini tutuyor.
            // playerı niye buraya almadık ? çünkü playeri aşağıda methodda kullanıyoruz   

            IMover mover = new MoverWithTranslate(this, moveSpeed);
            IMyAnimations animation = new CharacterAnimation(GetComponent<Animator>());
            IFlip flip = new FlipWithTransform(this);
            IHealth health = GetComponent<IHealth>();
            IEntityController player = FindObjectOfType<PlayerController>();
            IAttacker attacker = GetComponent<IAttacker>();
            IStopEdge stopEdge = GetComponent<StopEdge>();

            Idle idle = new Idle(mover, animation);
            Walk walk = new Walk(this, mover, animation, flip, patrols);
            ChasePlayer chasePlayer = new ChasePlayer(mover, flip, animation, stopEdge, () => IsRightSide());
            Attack attack = new Attack(player.transform.GetComponent<IHealth>(), flip, animation, attacker, maxAttackTime, () => IsRightSide());
            TakeHit takeHit = new TakeHit(health, animation);
            Dead dead = new Dead(this, animation, () =>
            {

                if (currentScoreChance > Random.Range(0, 100))  // Elmas düşme şansı ve spawn işlemi
                {

                    Instantiate(scorePrefab, this.transform.position, Quaternion.identity);   //Quaternion.identity methodu bize rotasyonun (0,0,0) dönmesini sağlar.

                }

            });

            _stateMachine.AddTransition(idle, walk, () => idle.IsIdle == false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceBetweenPlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceBetweenPlayerEnemy() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceBetweenPlayerEnemy() < attackDistance);
            _stateMachine.AddTransition(takeHit, chasePlayer, () => !takeHit.IsTakeHit);

            _stateMachine.AddTransition(walk, idle, () => walk.IsWalking == false);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceBetweenPlayerEnemy() > chaseDistance);
            _stateMachine.AddTransition(chasePlayer, walk, () => DistanceBetweenPlayerEnemy() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceBetweenPlayerEnemy() > attackDistance);


            _stateMachine.AddAnyState(dead, () => health.IsDead);
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);

            _stateMachine.SetState(idle);

            yield return null; // burayı IEnumarator bir değer döndürerek courutines haline getirmiş oluyoruz böylece bir method bitmeden diğerlerinide çalıştırmış oluyor.
                               // bu sayede buradaki yükü hafifletmiş olduk özellikle mobil kısmı için performansı arttırmış olduk.

        }

        private void Update()
        {

            _stateMachine.Tick();

        }

        private void OnDrawGizmos()
        {

            OnDrawGizmosSelected();

        }

        private void OnDrawGizmosSelected()
        {

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
            Gizmos.DrawWireSphere(transform.position, attackDistance);

        }

        private float DistanceBetweenPlayerEnemy()
        {

            return Vector2.Distance(this.transform.position, _player.transform.position);

        }

        private bool IsRightSide()
        {

            Vector3 leftOrRight = _player.transform.position - this.transform.position;

            if (leftOrRight.x > 0f)
            {

                return true;

            }

            else
            {

                return false;

            }

        }

    }

}

