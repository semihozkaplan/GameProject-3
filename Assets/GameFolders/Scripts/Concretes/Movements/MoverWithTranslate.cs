using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Controllers;
using ProjectGame3.Abstracts.Controller;

namespace ProjectGame3.Movements
{

    public class MoverWithTranslate : IMover
    {   
        //Compenant almadan oluşturuduğumuz bu yapıya Humble Pattern denir. Bir classın referansını başka classtan parametre olarak aldık ve kullanacağımız classda this keywordunu kullandık.
        IEntityController _entity;
        //float _moveSpeed = 3f;
        float _moveSpeed;

        //Newlenen obje ilk olarak constructor ı çalıştırır tıpkı c++ da olduğu gibi
        public MoverWithTranslate(IEntityController entity, float moveSpeed)
        {
            
            _entity = entity;
            _moveSpeed = moveSpeed;

        }

        public void Tick(float horizontal)
        {

            if(horizontal == 0f) return;

            _entity.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);

        }
        
    }

}


