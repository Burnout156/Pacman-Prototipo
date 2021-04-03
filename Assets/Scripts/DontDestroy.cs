using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static bool created = false; //aqui é para definir se esse objeto com esse script foi criado

    void Awake()
    {
        if (!created) //caso ele não tenha sido criado, ele seta a variável para verdadeira, impedindo outros objetos iguais serem criados
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

}
