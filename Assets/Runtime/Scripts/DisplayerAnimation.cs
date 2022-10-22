using UnityEngine;
using UnityEngine.UI;

public class DisplayerAnimation : MonoBehaviour
{
    [SerializeField] float _minY;
    [SerializeField] float _maxY;

    [Header("RGB Texts")]
    [SerializeField] Text _redText;
    [SerializeField] Text _greenText;
    [SerializeField] Text _blueText;

    [Header("Saturation/Bright Texts")]
    [SerializeField] Text _saturationText;
    [SerializeField] Text _brightText;

    [Header("Cover")]
    [SerializeField] RectTransform _redCover;
    [SerializeField] RectTransform _greenCover;
    [SerializeField] RectTransform _blueCover;

    [Header("Out Color")]
    [SerializeField] Image _outImage;

    public void ApplyAnimations(float r_255_format, float g_255_format, float b_255_format)
    {
        float r_normalized = r_255_format/255;
        float g_normalized = g_255_format/255;
        float b_normalized = b_255_format/255;

        UpdateOutImage(r_normalized, g_normalized, b_normalized);
        UpdateCoverPositions(r_normalized, g_normalized, b_normalized);
        UpdateTexts((int)r_255_format, (int)g_255_format, (int)b_255_format);
    }

    void UpdateOutImage(float r_normalized, float g_normalized, float b_normalized)
    {
        _outImage.color = new Color(r_normalized, g_normalized, b_normalized);
    }

    void UpdateCoverPositions(float r_normalized, float g_normalized, float b_normalized)
    {
        UpdateCoverPosition(_redCover, r_normalized);
        UpdateCoverPosition(_greenCover, g_normalized);
        UpdateCoverPosition(_blueCover, b_normalized);
    }

    void UpdateCoverPosition(RectTransform obj, float t)
    {
        t = Mathf.Clamp01(t);
        var targetY = _minY + t * (_maxY - _minY);
        var curPosition = obj.anchoredPosition;
        obj.anchoredPosition = new Vector2(curPosition.x, targetY);
    }

    void UpdateTexts(int r, int g, int b)
    {
        _redText.text = r.ToString();
        _greenText.text = g.ToString();
        _blueText.text = b.ToString();
        _saturationText.text = ColorUtils.GetSaturationPercent(r, g, b).ToString("0.00") + '%';
        _brightText.text = ColorUtils.GetBrightPercent(r, g, b).ToString("0.00") + '%';
    }
}