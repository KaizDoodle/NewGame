using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneFadeManager : MonoBehaviour
{
    public static SceneFadeManager instance;
    
    [SerializeField] private Image _fadeOutImage;
    [Range(0.1f, 10f), SerializeField] private float _fadeOutSpeed = 5f;
    [Range(0.1f, 10f), SerializeField] private float _fadeInSpeed = 5f;

    [SerializeField] private Color FadeOutStartColor;

    public bool IsFadingOut {get; private set;}
    public bool IsFadingIn {get; private set;}
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        FadeOutStartColor.a = 0f;
    }

    private void Update()
    {
        if (IsFadingOut)
        {
            if (_fadeOutImage.color.a < 1f)
            {
                FadeOutStartColor.a += Time.deltaTime * _fadeOutSpeed;
                _fadeOutImage.color = FadeOutStartColor;
            }
            else
            {
                IsFadingOut = false;
            }        
        }

        if (IsFadingIn)
        {
            if (_fadeOutImage.color.a > 0f)
            {
                FadeOutStartColor.a -= Time.deltaTime * _fadeInSpeed;
                _fadeOutImage.color = FadeOutStartColor;
            }
            else
            {
                IsFadingIn = false;
            }        
        }
    }

    public void StartFadeOut()
    {
        _fadeOutImage.color = FadeOutStartColor;
        IsFadingOut = true;
    }

    public void StartFadeIn()
    {
        if (_fadeOutImage.color.a >= 1f)
        {
        _fadeOutImage.color = FadeOutStartColor;
        IsFadingIn = true;
        }
    }

}
