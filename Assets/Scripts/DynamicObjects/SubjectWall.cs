using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubjectWall : MonoBehaviour, IDestroybleObject
{
    [SerializeField] private Rigidbody2D[] blocks;
    [SerializeField] private int indexIgnoreLayer;
    [SerializeField] private float destroyDistance;
    [SerializeField] private BoxCollider2D collider;

    public void DestroySubject(Transform grenader,float explosiveForce)
    {
        for(int i = 0; i < blocks.Length; i++)
        {
            blocks[i].gameObject.layer = indexIgnoreLayer;
            blocks[i].isKinematic = false;
            var direction = blocks[i].transform.position - grenader.position;
            if (direction.sqrMagnitude < destroyDistance)
            {
                Destroy(blocks[i].gameObject);
            }
            else
            {
                blocks[i].AddForce(CalculateForce(direction, explosiveForce));
            }
        }
        collider.enabled = false;
    }

    private Vector2 CalculateForce(Vector2 direction,float explosiveForce)
    {
        return new Vector2 (1/direction.x, 1/direction.y)*Random.Range(explosiveForce*0.9f,explosiveForce);
    }
}
