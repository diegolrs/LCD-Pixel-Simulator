using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] Slider _redSlider;
    [SerializeField] Slider _greenSlider;
    [SerializeField] Slider _blueSlider;

    [Header("Parameters")]
    [SerializeField] Color _initialColor;
    [SerializeField] DisplayerAnimation _displayerAnimation;

    void Awake() 
    {
        ApplyClampOnSliders();
        ApplyInitialColor();
        SubscribeToSlidersEvents();
    }

    void OnDestroy() 
    {
        UnsubscribeToSlidersEvents();
    }

    void SubscribeToSlidersEvents()
    {
        _redSlider?.onValueChanged.AddListener(OnSliderUpdateValue);
        _greenSlider?.onValueChanged.AddListener(OnSliderUpdateValue);
        _blueSlider?.onValueChanged.AddListener(OnSliderUpdateValue);
    }

    void UnsubscribeToSlidersEvents()
    {
        _redSlider?.onValueChanged.RemoveAllListeners();
        _greenSlider?.onValueChanged.RemoveAllListeners();
        _blueSlider?.onValueChanged.RemoveAllListeners();
    }

    void ApplyClampOnSliders()
    {
        _redSlider.minValue = 0;
        _blueSlider.minValue = 0;
        _greenSlider.minValue = 0;

        _redSlider.maxValue = 255;
        _blueSlider.maxValue = 255;
        _greenSlider.maxValue = 255;

        _redSlider.wholeNumbers = true;
        _greenSlider.wholeNumbers = true;
        _blueSlider.wholeNumbers = true;
    }

    void ApplyInitialColor()
    {
        _redSlider.value = _initialColor.r*255;
        _greenSlider.value = _initialColor.g*255;
        _blueSlider.value = _initialColor.b*255;
        UpdateOutputRenderers();
    }

    void UpdateOutputRenderers()
    {
        _displayerAnimation.ApplyAnimations(_redSlider.value,
                                            _greenSlider.value,
                                            _blueSlider.value);
    }

    void OnSliderUpdateValue(float value) => UpdateOutputRenderers();
}