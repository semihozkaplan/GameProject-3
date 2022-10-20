using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Controllers;

namespace ProjectGame3.Movements
{

    public class FlipWithSpriteRenderer : IFlip
    {
        SpriteRenderer _spriteRenderer;

        public FlipWithSpriteRenderer(PlayerController playerController)
        {
            //Sprite Renderer compenantı player değil onun child elementi olan body içerisinde olduğu için getcomponentinchildren kullandık.
            _spriteRenderer = playerController.GetComponentInChildren<SpriteRenderer>();

        }


        public void FlipAction(float direction)
        {

            if (direction == 0f) return;

            if (direction < 0f)
            {

                _spriteRenderer.flipX = true;

            }

            else {

                _spriteRenderer.flipX = false;

            }

        }


    }

}


