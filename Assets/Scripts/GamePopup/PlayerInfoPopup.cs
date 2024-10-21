using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfoPopup : BasePopup {

    private CircleImage icon;
    private Button back;
    private Button playerBtn;
    private Text playerName;
    private Text playerState;
    private Transform parent;
    private Text shoushu;
    private Text ruchilv;
    private Text ruchishenglv;
    private Text jijin;
    private Text fanqianjiazhu;
    private Text againAdd;
    private Text persisentAdd;
    private Text tanpai;
    private Button look;

    private bool noSit=false;
    private bool noEnter=false;
    private string id;

    private Hashtable data;
    
    private void Awake()
    {
        Init();
        icon = transform.Find("PlayerHead").GetComponent<CircleImage>();
        back = transform.Find("CloseBtn").GetComponent<Button>();
        playerBtn = transform.Find("playerManageBtn").GetComponent<Button>();
        playerName = transform.Find("name").GetComponent<Text>();
        playerState = transform.Find("State").GetComponent<Text>();
        parent = transform.Find("Scroll View/Viewport/Content");
        shoushu = parent.Find("Item1/shoushu/Text").GetComponent<Text>();
        ruchilv = parent.Find("Item2/ruchilv/Text").GetComponent<Text>();
        ruchishenglv = parent.Find("Item3/ruchishenglv/Text").GetComponent<Text>();
        jijin = parent.Find("Item4/jijinshuliang/Text").GetComponent<Text>();
        fanqianjiazhu = parent.Find("Item5/fanqianjiazhu/Text").GetComponent<Text>();
        againAdd = parent.Find("Item6/zaicijiazhu/Text").GetComponent<Text>();
        persisentAdd = parent.Find("Item7/chixuxiazhu/Text").GetComponent<Text>();
        tanpai = parent.Find("Item8/tanpailv/Text").GetComponent<Text>();
        look = transform.Find("isLook").GetComponent<Button>();


        back.onClick.AddListener(() =>
        {
            HideView();
        });
        playerBtn.onClick.AddListener(() =>
        {
            GameUIManager.GetSingleton().playerManagePopup.ShowView(noSit,noEnter,id);
        });
        look.onClick.AddListener(() =>
        {
            NetMngr.GetSingleton().Send(InterfaceGame.peekCards, new object[] {int.Parse(id) });
            HideView();
        });
    }
    private void Start()
    {

    }
    private void Update()
    {

    }
    public void SetData(Hashtable data)
    {
        this.data = data;
        GameTools.GetSingleton().GetTextureFromNet(data["headUrl"].ToString(),SetIcon);
        playerName.text = data["nickname"].ToString();
        playerState.text = data["State"].ToString() == "1" ? "游戏中" : "旁观中";
        shoushu.text = data["shou"].ToString();
        ruchilv.text = float.Parse(data["inPoolRate"].ToString())*100+"%";
        ruchishenglv.text = float.Parse(data["inPoolWinRate"].ToString())*100+"%";
        jijin.text = data["jijin"].ToString();
        fanqianjiazhu.text = float.Parse(data["fanqian"].ToString())*100+"%";
        againAdd.text = float.Parse(data["again"].ToString())*100 + "%";
        persisentAdd.text = float.Parse(data["continue"].ToString())*100 + "%";
        tanpai.text = float.Parse(data["tanpai"].ToString())*100 + "%";
        id = data["id"].ToString();
        string temp = "";
        if (data.Contains("canShowManageBtn"))
        {
            temp = data["canShowManageBtn"].ToString();
        }
        look.gameObject.SetActive(int.Parse(data["isLook"].ToString()) == 1 ? true : false);
      
        if (id==StaticData.ID || temp=="0")
        {
            playerBtn.gameObject.SetActive(false);
            look.gameObject.SetActive(false);
        }
        else
        {
            look.gameObject.SetActive(true);
            playerBtn.gameObject.SetActive(true);
        }
        noSit = int.Parse(data["forbidSit"].ToString()) == 1 ? true : false;
        noEnter= int.Parse(data["forbidEntry"].ToString()) == 1 ? true : false;
    }
    private void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void ShowView(string id)
    {
        NetMngr.GetSingleton().Send(InterfaceGame.getRoomUserDetails, new object[] { int.Parse(id)});
        base.ShowView();
    }
}
