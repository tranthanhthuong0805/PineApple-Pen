using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CoinMotion : MonoBehaviour {
    private GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("CoinButton");
        transform.DOMove(target.transform.GetChild(0).transform.position, Random.Range(1.0f, 1.5f)).SetAutoKill(false);
	}

    IEnumerator DestroyObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        StartCoroutine(DestroyObject(1.5f));
	}
}
