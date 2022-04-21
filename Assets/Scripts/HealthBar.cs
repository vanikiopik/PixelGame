using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _img;

    void Start()
    {
        _img = GetComponent<Image>();
        _img.fillAmount = 1f;
    }

    void Update()
    {

    }

    public void HpDecrease()
    {
        _img.fillAmount -= 0.2f;
    }
}

