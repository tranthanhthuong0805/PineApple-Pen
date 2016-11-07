using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ValueScoreOrCoin : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        transform.DOMoveY(transform.position.y + 2, 1);
	}

    IEnumerator DestroyObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        StartCoroutine(DestroyObject(0.8f));
	}
}
