using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zengsongItem : MonoBehaviour {

    private Text title;
    private Text time;

    private void Awake()
    {
        title = transform.Find("title").GetComponent<Text>();
        time = transform.Find("time").GetComponent<Text>();
    }

    public void SetData(Hashtable data)
    {
        title.text = data["name"].ToString() + " 赠送给 " + data["name2"].ToString() +" "+ data["count"].ToString() + "个钻石";
        time.text = data["time"].ToString();
    }
}
