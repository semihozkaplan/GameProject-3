using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Controllers;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Abstracts.Controller;

namespace ProjectGame3.Movements
{

    public class FlipWithTransform : IFlip
    {
        //Playercontrollerdaki IEntityControlleri kullanabilelim diye buradan constructor ile referansını verdik böylece PlaeyrControllerdan sadece this keywordu ile kullanabileceğiz.
        IEntityController _entityController;

        public FlipWithTransform(IEntityController entityController)
        {

            _entityController = entityController;
            
        }

        public void FlipAction(float direction){

            if(direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != _entityController.transform.localScale.x){
                
                _entityController.transform.localScale = new Vector2(mathValue, 1);

            }

        }

    }

}


