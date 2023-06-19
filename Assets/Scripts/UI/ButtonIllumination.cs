using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonIllumination : MonoBehaviour
{
    [SerializeField] private Image targetColor;
    [SerializeField] private Color baseColor = Color.white;
    [SerializeField] private Color pressedColor = Color.white;
    private InteractionBehaviour _intObj;
    // Start is called before the first frame update
    private void Awake()
    {
        _intObj = GetComponent<InteractionBehaviour>();
        targetColor = GetComponent<Image>();
        baseColor = targetColor.color;
    }

    // Update is called once per frame
    private void Update()
    {
        if (targetColor != null)
        {
            if (_intObj is InteractionButton && (_intObj as InteractionButton).isPressed)
            {
                targetColor.color = Color.Lerp(targetColor.color, pressedColor, 30f * Time.deltaTime);
            }
            else
            {
                targetColor.color = Color.Lerp(targetColor.color, baseColor, 30f * Time.deltaTime);
            }
        }
    }
}
