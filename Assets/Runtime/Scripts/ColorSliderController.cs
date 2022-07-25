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

        _redSlider.maxValue = 1;
        _blueSlider.maxValue = 1;
        _greenSlider.maxValue = 1;
    }

    void ApplyInitialColor()
    {
        _redSlider.value = _initialColor.r;
        _greenSlider.value = _initialColor.g;
        _blueSlider.value = _initialColor.b;
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