using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSubjectHandler : MonoBehaviour
{
    public bool Empty { get; private set; } = true;

    [Inject] private readonly ICustomInput input;

    [SerializeField] private PlayerHand playerHand;

    private IGameSubject currentSubject;


    private void OnEnable()
    {
        input.MouseClicked += OnMouseClicked;
    }
    private void OnDisable()
    {
        input.MouseClicked -= OnMouseClicked;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<IGameSubject>(out var sublect))
        {
            if (currentSubject == null)
            {
                sublect.TakeSubject(playerHand);
                currentSubject = sublect;
                Empty = false;
            }

        }
    }

    private void OnMouseClicked()
    {
        if (currentSubject != null)
        {
            var needRemove = currentSubject.PerformAction();
            if(needRemove)
            {
                currentSubject.RemoveSubject();
                currentSubject = null;
                Empty = true;
            }
        }

    }
}
