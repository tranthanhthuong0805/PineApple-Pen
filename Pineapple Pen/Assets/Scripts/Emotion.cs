using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Emotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sequence s = DOTween.Sequence();
        // Add an horizontal relative move tween that will last the whole Sequence's duration
        s.Append(transform.GetChild(1).DORotate(new Vector3(0, 0, -16), 0.3f).SetRelative().SetEase(Ease.InOutQuad));
        // Set the whole Sequence to loop infinitely forward and backwards
        s.SetLoops(-1, LoopType.Yoyo);

        transform.GetChild(0).DORotate(new Vector3(0, 0, -3600), 100);
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<AudioSource>().isPlaying == false)
            Destroy(gameObject);
	}
}
