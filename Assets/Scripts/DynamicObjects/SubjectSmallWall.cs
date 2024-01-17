using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectSmallWall : MonoBehaviour, IDestroybleObject
{
    [SerializeField] private Rigidbody2D[] blocks;
    [SerializeField] private int indexIgnoreLayer;
    [SerializeField] private BoxCollider2D collider;

    public void DestroySubject(Transform grenader, float explosiveForce)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].gameObject.layer = indexIgnoreLayer;
            blocks[i].isKinematic = false;
            blocks[i].AddForce(new Vector2(1, Random.Range(-1, 1)) * Random.Range(50, 80));
        }
        collider.enabled = false;
    }
}
