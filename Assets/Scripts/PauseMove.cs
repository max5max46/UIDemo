using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMove : MonoBehaviour
{
    public float HeightToTravel = 1;
    public bool isTimeScaleIndepentent = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform transformDefault = transform;

        if (isTimeScaleIndepentent)
            DOTween.defaultTimeScaleIndependent = true;

        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DOMove(new Vector3(transformDefault.position.x, transformDefault.position.y + HeightToTravel, transformDefault.position.z), 3).SetEase(Ease.InOutSine))
            .Append(transform.DOMove(transformDefault.position, 3).SetEase(Ease.InOutSine)).SetLoops(-1);

        mySequence.Play();

        DOTween.defaultTimeScaleIndependent = false;
    }


    /*private void ChangeDirection()
    {
        if (goingUp)
        {
            this.transform.DOMove(new Vector3(transformDefault.position.x, transformDefault.position.y + HeightToTravel, transformDefault.position.z), 3).OnComplete(te);
            goingUp = false;
        }
        else
        {
            this.transform.DOMove(transformDefault.position, 3);
            goingUp = true;
        }
    }*/
}
