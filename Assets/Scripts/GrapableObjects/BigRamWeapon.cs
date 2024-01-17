using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BigRamWeapon : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDestroybleObject destroybleObject))
        {
            destroybleObject.DestroySubject(transform, 0);
        }
    }
}
