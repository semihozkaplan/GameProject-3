using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;


namespace ProjectGame3.Movements
{

    public class OnGround : MonoBehaviour, IOnGround
    {

        [SerializeField] Transform[] transforms;
        [SerializeField] float maxDistance = 0.4f;
        [SerializeField] LayerMask layerMask;

        bool _isOnGround;
        public bool IsOnGround => _isOnGround;

        private void Update()
        {

            foreach (Transform footTransform in transforms)
            {


                CheckFootOnGround(footTransform);

                if (_isOnGround) break;

            }

        }

        private void CheckFootOnGround(Transform footTransform)
        {

            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);

            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (hit.collider != null)
            {

                _isOnGround = true;

            }

            else
            {

                _isOnGround = false;

            }

        }

    }


}

