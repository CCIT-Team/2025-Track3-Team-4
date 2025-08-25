using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tmp = null;

    public void SetText(string text)
    {
        if (_tmp == null)
        {
            Debug.LogWarning("tmpro is null");
            return;
        }

        _tmp.text = text;
    }
}
