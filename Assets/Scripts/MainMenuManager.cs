using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public RectTransform titleText;

    public RectTransform dog;

    public RectTransform button1;
    public RectTransform button2;
    public RectTransform button3;
    public RectTransform button4;
    public RectTransform button5;
    public RectTransform button6;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        dog.rotation = Quaternion.Euler(Vector3.zero);
        titleText.localScale = Vector3.zero;
        button1.anchoredPosition = new Vector3(-2000, button1.anchoredPosition.y, 0);
        button2.anchoredPosition = new Vector3(2000, button2.anchoredPosition.y, 0);
        button3.anchoredPosition = new Vector3(-2000, button3.anchoredPosition.y, 0);
        button4.anchoredPosition = new Vector3(2000, button4.anchoredPosition.y, 0);
        button5.anchoredPosition = new Vector3(-2000, button5.anchoredPosition.y, 0);
        button6.anchoredPosition = new Vector3(2000, button6.anchoredPosition.y, 0);


        titleText.DOScale(3, 1).SetEase(Ease.OutBounce);
        dog.DORotate(new Vector3(0,0,360), 5, RotateMode.FastBeyond360);
        DOTween.To(() => button1.anchoredPosition, x => button1.anchoredPosition = x, new Vector2 (0, button1.anchoredPosition.y), 1).SetEase(Ease.OutCubic);
        DOTween.To(() => button2.anchoredPosition, x => button2.anchoredPosition = x, new Vector2 (0, button2.anchoredPosition.y), 1).SetEase(Ease.OutCubic);
        DOTween.To(() => button3.anchoredPosition, x => button3.anchoredPosition = x, new Vector2 (0, button3.anchoredPosition.y), 1).SetEase(Ease.OutCubic);
        DOTween.To(() => button4.anchoredPosition, x => button4.anchoredPosition = x, new Vector2 (0, button4.anchoredPosition.y), 1).SetEase(Ease.OutCubic);
        DOTween.To(() => button5.anchoredPosition, x => button5.anchoredPosition = x, new Vector2 (0, button5.anchoredPosition.y), 1).SetEase(Ease.OutCubic);
        DOTween.To(() => button6.anchoredPosition, x => button6.anchoredPosition = x, new Vector2 (0, button6.anchoredPosition.y), 1).SetEase(Ease.OutCubic);


    }

}
