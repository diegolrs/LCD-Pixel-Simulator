using UnityEngine;
using UnityEngine.UI;

public class DisplayerAnimation : MonoBehaviour
{
    [SerializeField] float _minY;
    [SerializeField] float _maxY;

    [Header("Text")]
    [SerializeField] Text _redText;
    [SerializeField] Text _greenText;
    [SerializeField] Text _blueText;

    [Header("Cover")]
    [SerializeField] RectTransform _redCover;
    [SerializeField] RectTransform _greenCover;
    [SerializeField] RectTransform _blueCover;

    [Header("Out Color")]
    [SerializeField] Image _outImage;

    public void ApplyAnimations(float r, float g, float b)
    {
        UpdateOutImage(r, g, b);
        UpdateCoverPositions(r, g, b);
        UpdateTexts(r, g, b);
    }

    void UpdateOutImage(float r, float g, float b)
    {
        _outImage.color = new Color(r, g, b);
    }

    void UpdateCoverPositions(float r, float g, float b)
    {
        UpdateCoverPosition(_redCover, r);
        UpdateCoverPosition(_greenCover, g);
        UpdateCoverPosition(_blueCover, b);
    }

    void UpdateCoverPosition(RectTransform obj, float t)
    {
        t = Mathf.Clamp01(t);
        var targetY = _minY + t * (_maxY - _minY);
        var curPosition = obj.anchoredPosition;
        obj.anchoredPosition = new Vector2(curPosition.x, targetY);
    }

    void UpdateTexts(float r, float g, float b)
    {
        _redText.text = ToRGB255Format(r);
        _greenText.text = ToRGB255Format(g);
        _blueText.text = ToRGB255Format(b);
    }

    string ToRGB255Format(float normalizedColor)
    {
        int color = (int)(normalizedColor*255);
        return color.ToString();
    }
}