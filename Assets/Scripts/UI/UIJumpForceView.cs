using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIJumpForceView : MonoBehaviour
{
    [SerializeField] private Image imageFill;

    public void UpdateImage(float value)
    {
        imageFill.fillAmount = value;
    }
}
