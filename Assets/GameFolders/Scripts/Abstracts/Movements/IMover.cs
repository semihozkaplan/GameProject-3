using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.Movements
{

    //Bu ve diğer hareketler için interface kullanmamızın amacı test güdümlü çalışabilmemizdir. Böylece PlayerController kısmında sadece newleme kısmında değişiklik yapacağız method kısmına dokunmamıza gerek kalmayacak.

    public interface IMover
    {
        void Tick(float horizontal);

    }

}


