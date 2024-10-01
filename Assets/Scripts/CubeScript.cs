using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private Transform cubePos;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        var start = transform.position;

        //transform.DOMove(cubePos.position, 1f).SetEase(Ease.Linear).onComplete += () =>
        //{
        //    DOVirtual.DelayedCall(1f, () => transform.DORotate(Vector3.up * 180f, 1f).onComplete += ()=> transform.DOMove(start,1f));
        //};


        var seq = DOTween.Sequence();

        seq.Append(transform.DOMove(cubePos.position, 1f).SetEase(Ease.InOutQuart))
            .Append(DOVirtual.DelayedCall(1f, null))
            .Append(transform.DORotate(Vector3.up * 90f, 1f))
            .AppendCallback(() =>
            {
                StartCoroutine(WaitForClick(seq));
            })
            //.Append
            .Append(transform.DOMove(start,1f))
            .Play();

    }

    IEnumerator WaitForClick(Sequence seq)
    {
        seq.Pause();
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        Debug.Log("clicklenildi");
        seq.Play();
    }

}
