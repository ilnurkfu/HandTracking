using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;

    #region Properties

    private Image _myImage;
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    /// <summary>
    /// Creates an instance of the material and caches it in a local variable.
    /// </summary>
    protected Image MyImage
    {
        get
        {
            if (_myImage == null)
            {
                _myImage = GetComponent<Image>();
            }

            return _myImage;
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void ActivatedAction();

    public void Hover()
    {
        //actionBasedController.activateAction.action.performed += ActionOnPerformed;
        //hoveredDirectInteractors.Add(xrDirectInteractor);

        //xrDirectInteractor.SendHapticImpulse(hoverAmplitude, hoverDuration);
        MyImage.color = hoverColor;
    }

    public void Dehover()
    {
        //actionBasedController.activateAction.action.performed -= ActionOnPerformed;

        //hoveredDirectInteractors.Remove(xrDirectInteractor);
        //if (hoveredDirectInteractors.Count == 0)
        //{
        //    MyMaterial.SetColor(BaseColor, defaultColor);
        //}
        MyImage.color = defaultColor;
    }
}
