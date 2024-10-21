using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class myjifeipai : BasePopup {
    public Text mang;
    public Text jifenpai;
    public Text mymoney;
    public Text serviceMoney;
    public Slider mslider;
    Button btn;
    int mseatNum;
    private void Awake()
    {
        mang = transform.Find("mang").GetComponent<Text>();
        jifenpai = transform.Find("takemoney").GetComponent<Text>();
        mymoney = transform.Find("mymoney").GetComponent<Text>();
        serviceMoney = transform.Find("serviceMoney").GetComponent<Text>();
        mslider = transform.Find("Slider").GetComponent<Slider>();
        btn = transform.Find("sure").GetComponent<Button>();
        btn.onClick.AddListener(()=> {
           // GameManager.GetSingleton().takeMoney = (int)(mslider.value) ;
            if (mseatNum == -1)
            {
                NetMngr.GetSingleton().Send(InterfaceGame.addCoin, new object[] { (int)(mslider.value * 200* GameManager.GetSingleton().roomXiaoMang) +"" });
            }
            else
                NetMngr.GetSingleton().Send(InterfaceGame.DesktopPlayerSitdownRequest, new object[] { mseatNum, (int)(mslider.value*200 * GameManager.GetSingleton().roomXiaoMang) });
            HideView();
        });
        mslider.onValueChanged.AddListener((v)=> {
            jifenpai.text = v*200*GameManager.GetSingleton().roomXiaoMang + "";
        });
        Init();
    }
    public override void ShowView(Action onComplete = null)
    {
        base.ShowView(onComplete);
        base.hideNeedSendMsg = true;
    }
    void Start () {
        //showInfo();
    }
    public void showInfo(int seatNum)
    {
        mseatNum = seatNum;
        mang.text = GameManager.GetSingleton().roomXiaoMang + "/" + GameManager.GetSingleton().roomDaMang;
        jifenpai.text = GameManager.GetSingleton().roomMinTakeMoneyRatio*200* GameManager.GetSingleton().roomXiaoMang + "";
        serviceMoney.text = GameManager.GetSingleton().serviceMoney + "";
        mymoney.text = StaticData.gold + "";
        mslider.minValue = GameManager.GetSingleton().roomMinTakeMoneyRatio;
        mslider.maxValue = GameManager.GetSingleton().roomMaxTakeMoneyRatio;
        mslider.value= GameManager.GetSingleton().roomMinTakeMoneyRatio;
    }
}
