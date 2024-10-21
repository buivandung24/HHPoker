using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeadItem : MonoBehaviour {
    public CircleImage head;


    void Awake() {
        head = transform.GetComponent<CircleImage>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHead(string  url) {

        GameTools.GetSingleton().GetTextureFromNet(url, GetHead);
    }


    public void GetHead(Sprite s)
    {
        head.sprite = s;
    }
    public void DelSelf()
    {
        Destroy(gameObject);
    }
}
