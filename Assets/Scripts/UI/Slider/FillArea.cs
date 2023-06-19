using System;
using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class FillArea : MonoBehaviour
{
  [SerializeField] private Image fillImage;
  
  [SerializeField] private InteractionSlider handSlider;

  [SerializeField] private bool isHorizontal;
  
  [SerializeField] private float value;
  [SerializeField] private float maxHorizontalValue;

  private void Awake()
  {
      fillImage = GetComponent<Image>();
  }

  private void Update()
  {
      if (isHorizontal == true)
      {
          value = handSlider.HorizontalSliderValue;
          fillImage.rectTransform.anchorMax = new Vector2((handSlider.HorizontalSliderValue - handSlider.minHorizontalValue) / (handSlider.maxHorizontalValue - handSlider.minHorizontalValue), 1f);
      }
      else
      {
          value = handSlider.VerticalSliderValue;
          fillImage.rectTransform.anchorMax = new Vector2((handSlider.VerticalSliderValue - handSlider.minVerticalValue) / (handSlider.maxVerticalValue - handSlider.minVerticalValue), 1f);
      }
  }
}
