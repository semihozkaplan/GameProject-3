using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;

namespace ProjectGame3.Movements
{

    [RequireComponent(typeof(Collider2D))]

    public class StopEdge : MonoBehaviour, IStopEdge
    {

        [SerializeField] float distance = 0.2f;
        [SerializeField] LayerMask _layerMask;

        Collider2D _collider;
        float _direction;

        private void Awake()
        {

            _collider = GetComponent<Collider2D>();
            _direction = this.transform.localScale.x;

        }

        public bool ReachedEdge()
        {

            float x = GetXPosition();
            float y = _collider.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, _layerMask);
            Debug.DrawRay(origin, Vector2.down * distance, Color.blue);


            if (hit.collider != null)
            {

                return false;

            }

            else
            {

                return true;

            }

        }


        private float GetXPosition() // Karakterin local scale pozisyonuna bak eğer sağa dönük ise bir tık ilerisini dön eğer sola dönük ise solun bir tık ilerisini dön.
        {
            return _direction == 1f ? _collider.bounds.max.x + distance : _collider.bounds.min.x - distance;
        }

    

    }




}

