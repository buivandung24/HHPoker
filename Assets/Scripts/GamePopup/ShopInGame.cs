using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInGame : MonoBehaviour {
    public Button back;
    // Use this for initialization
    void Awake() {

		back = transform.Find("ShopGoldTopPanel/Top/Back").GetComponent<Button>();
        back.onClick.AddListener(()=> {
            gameObject.SetActive(false);
//            TouchMove.Instance().isRun = true;
        });

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        TouchMove.Instance().isRun = false;
    }
}
