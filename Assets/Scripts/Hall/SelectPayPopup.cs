using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPayPopup : BasePopup {

    private Button WeChat;
    private Button ZhiFuBao;
    private Button Back;

    public string id;

    private void Awake()
    {
        Init();
        WeChat = transform.Find("WeChat").GetComponent<Button>();
        ZhiFuBao = transform.Find("ZhiFuBao").GetComponent<Button>();
        Back = transform.Find("CancelBtn").GetComponent<Button>();

        WeChat.onClick.AddListener(() =>
        {
            NetMngr.GetSingleton().Send(InterfaceMain.BuyDiamond, new object[] { "2",id });
            HideView();
        });
        ZhiFuBao.onClick.AddListener(() =>
        {
            NetMngr.GetSingleton().Send(InterfaceMain.BuyDiamond, new object[] { "1", id });
            HideView();
        });
        Back.onClick.AddListener(() =>
        {
            HideView();
        });
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    public void ShowView(string id)
    {
        this.id = id;
        base.ShowView();
    }
}
