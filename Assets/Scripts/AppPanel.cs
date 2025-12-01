using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppPanel : MonoBehaviour
{
    public Toggle trailToggle;
    public Toggle particleToggle;
    public Toggle animToggle;

    public GameObject trailEffect;
    public GameObject particleEffect;
    public Animator animEffect;

    void Start()
    {
        SetEffect(trailEffect, false);
        SetEffect(particleEffect, false);
        SetAnimator(false);

        trailToggle.onValueChanged.AddListener(isOn => SetEffect(trailEffect, isOn));
        particleToggle.onValueChanged.AddListener(isOn => SetEffect(particleEffect, isOn));
        animToggle.onValueChanged.AddListener(isOn => SetAnimator(isOn));
    }

    void SetEffect(GameObject obj, bool active)
    {
        if (obj != null)
            obj.SetActive(active);
    }

    void SetAnimator(bool active)
    {
        if (animEffect == null) return;
        animEffect.enabled = active;
        animEffect.Play(0, 0, 0);
    }
}
