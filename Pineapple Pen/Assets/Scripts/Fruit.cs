using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fruit : MonoBehaviour {

    void FixedUpdate () {
        if (transform.position.y <= -12)
            Destroy(gameObject);
    }

    public void FruitMove()
    {
        // Create a new Sequence.
        Sequence s = DOTween.Sequence();
        // Add an horizontal relative move tween that will last the whole Sequence's duration
        if (transform.position.x == -4)
            s.Append(transform.DOMoveX(8, Random.Range(0.7f, 1f)).SetRelative().SetEase(Ease.InOutQuad));
        
        if (transform.position.x == 4)
            s.Append(transform.DOMoveX(-8, Random.Range(0.7f, 1f)).SetRelative().SetEase(Ease.InOutQuad));

        // Set the whole Sequence to loop infinitely forward and backwards
        s.SetLoops(-1, LoopType.Yoyo);
    }


}
