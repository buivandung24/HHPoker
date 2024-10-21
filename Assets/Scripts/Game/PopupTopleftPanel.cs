using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PopupTopleftPanel : BasePopup {
    Button btnQuitGame;
    Button btnzhanqi;
    Button btnliuzhuo;
    Button btnrule;
    Button btnPaiju;
    Button btnbuchong;
    Button btnTuoguan;
    Button btnsetting;
    Button bgbtn;
    // Use this for initialization
    void Awake () {
		btnQuitGame = transform.Find("bg/tuichu").GetComponent<Button>();
		btnzhanqi = transform.Find("bg/weiguan").GetComponent<Button>();
		btnliuzhuo = transform.Find("bg/liuzhuo").GetComponent<Button>();
		btnrule = transform.Find("bg/rule").GetComponent<Button>();
		btnPaiju = transform.Find("bg/paiju").GetComponent<Button>();
		btnbuchong = transform.Find("bg/buchong").GetComponent<Button>();
		btnTuoguan = transform.Find("bg/tuoguan").GetComponent<Button>();
		btnsetting = transform.Find("bg/setting").GetComponent<Button>();
        bgbtn= transform.Find("bg").GetComponent<Button>();
        //if (StaticData.isGuanzhan)
        //{
        //    btnTuoguan.interactable = false;
        //    btnzhanqi.interactable = false;
        //    btnliuzhuo.interactable = false;
        //}
        //else
        //{
        //    btnTuoguan.interactable = true;
        //    btnzhanqi.interactable = true;
        //    btnliuzhuo.interactable = true;
        //}
        bgbtn.onClick.AddListener(() =>
        {
            
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
        });
        btnQuitGame.onClick.AddListener(() =>
        {
            print("1111");
            TouchMove.Instance().RemoveFunction();
            NetMngr.GetSingleton().Send(InterfaceGame.DesktopPlayerLeaveRequest, new object[] { });
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
        });
        btnzhanqi.onClick.AddListener(() =>
        {
            //PopupCommon.GetSingleton().ShowView("站起将直接弃牌，是否继续？", null, true, () =>
            //{
            //    NetMngr.GetSingleton().Send(InterfaceGame.DesktopPlayerObRequest, new object[] { });
            //    GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
            //});
            NetMngr.GetSingleton().Send(InterfaceGame.KBDesktopPlayerCanObRequest,new object[] { });

			
          
        });
        btnliuzhuo.onClick.AddListener(() =>
        {
            NetMngr.GetSingleton().Send(InterfaceGame.keepSeat, new object[] { });
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
        });
        btnrule.onClick.AddListener(() =>
        {
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
            GameUIManager.GetSingleton().insuranceRulePopup.ShowView();
        });
        btnPaiju.onClick.AddListener(() =>
        {
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
            GameUIManager.GetSingleton().matchInfoPopup.ShowView();
        });
        // 补充记分牌
        btnbuchong.onClick.AddListener(() =>
        {
            GameUIManager.GetSingleton()._mjifenpai.ShowView();
            GameUIManager.GetSingleton()._mjifenpai.showInfo(-1);
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
        });
        btnTuoguan.onClick.AddListener(() =>
        {
            NetMngr.GetSingleton().Send(InterfaceGame.tuoGuan, new object[] { true});
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
        });
        btnsetting.onClick.AddListener(() =>
        {
            GameUIManager.GetSingleton().ptopleftpanel.gameObject.SetActive(false);
            GameUIManager.GetSingleton().roomSetPopup.ShowView();
        });
        this.Init();
    }
}
