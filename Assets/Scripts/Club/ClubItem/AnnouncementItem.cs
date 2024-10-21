﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnnouncementItem : MonoBehaviour {
    public Text gongGaoText;
    public Text timeText;
	public CircleImage icon;

    public string content;
    public string id;
    void Awake() {
        gongGaoText = transform.Find("GongGaoText").GetComponent<Text>();
        timeText= transform.Find("TimeText").GetComponent<Text>();
		icon = transform.Find("Head").GetComponent<CircleImage>();

        GetComponent<Button>().onClick.AddListener(()=> {

            HallManager.GetSingleton().noticeContentTopPanel.type = "2";
            HallManager.GetSingleton().noticeContentTopPanel.id = id;
            HallManager.GetSingleton().planeManager.AddTopPlane(HallManager.GetSingleton().noticeContentTopPanel);
            // HallManager.GetSingleton().noticeContentTopPanel.title.text = gongGaoText.text;
            // HallManager.GetSingleton().noticeContentTopPanel.content.text = content;
        

        });

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetInfo(string title, string time, string content,string id, string iconUrl)
    {
        gongGaoText.text = title;
        timeText.text = time;
        this.content = content;
        this.id = id;
		if (iconUrl != "") {
			GameTools.GetSingleton ().GetTextureFromNet (iconUrl, getSprite);
		}

    }

	void getSprite(Sprite sp)
	{
		icon.sprite = sp;
	}

    public void DelSelf() {
        Destroy(gameObject);
    }
}
