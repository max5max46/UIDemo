using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public RectTransform pauseText;

    private void OnEnable()
    {
        DOTween.defaultTimeScaleIndependent = true;

        pauseText.localScale = Vector3.zero;
        pauseText.DOScale(1, 1).SetEase(Ease.OutBounce);

        DOTween.defaultTimeScaleIndependent = false;
    }
}
