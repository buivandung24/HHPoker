using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class ClubListPanel : BasePlane {


    public Button createBtn;
    public Button joinBtn;
	public Button myClubBtn;

	public Text myClubCount;
    public Transform myJoinClubContent;
	public GameObject tip;

	public int curGetClubType;

	public ArrayList myList;
	public ArrayList myJoinList;

	public bool firstGet;

    void Awake() {


        createBtn= transform.Find("CreateBtn").GetComponent<Button>();
        joinBtn= transform.Find("JoinBtn").GetComponent<Button>();
		myClubBtn = transform.Find("MyClub").GetComponent<Button>();
		myClubCount = transform.Find("MyClub/Text").GetComponent<Text>();

         myJoinClubContent = transform.Find("MyJoinClub/Scroll View/Viewport/Content");
		 tip = transform.Find("MyJoinClub/tip").gameObject;


        createBtn.onClick.AddListener(()=> {

            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().clubCreateTopPanel);
        });

        joinBtn.onClick.AddListener(()=> {
            ClubManager.GetSingleton().planeManager.AddTopPlane(ClubManager.GetSingleton().hotClubTopPanel);
        });

		myClubBtn.onClick.AddListener(()=> {
			//显示我的俱乐部
			ClubManager.GetSingleton().myClubPanel.gameObject.SetActive(true);
			ClubManager.GetSingleton().myClubPanel.FreshList();
		});
		firstGet = true;
		GetMyClub(0);//获取我的俱乐部
    }

	public void GetClubList()
	{
		GetMyClub (0);
//		if (ClubManager.GetSingleton ().myClubPanel.gameObject.activeInHierarchy) {
//			GetMyClub (0);
//		} 
//		else 
//		{
//			GetMyClub (1);
//		}
	}

	void GetMyClub(int type)
	{
		curGetClubType = type;
		if(type == 0)
			NetMngr.GetSingleton().Send(InterfaceClub.GetMyClub, new object[] { "0" });
		else
			NetMngr.GetSingleton().Send(InterfaceClub.GetMyClub, new object[] { "1" });//获取加入的俱乐部
	}

	private void ClearList(Transform parent)
	{
		int childCount = parent.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Destroy(parent.GetChild(i).gameObject);
		}
	}

    public void GetMyClubCallBack(Hashtable data) {

        BroadcastMessage("DelSelf", SendMessageOptions.DontRequireReceiver);
		if (curGetClubType == 0) {
			myList = data ["ClubList"] as ArrayList;
			myClubCount.text = myList.Count.ToString();
			//if (firstGet) {
			GetMyClub (1);
				//firstGet = false;
			//}
			if (ClubManager.GetSingleton ().myClubPanel.gameObject.activeInHierarchy) {
				ClubManager.GetSingleton ().myClubPanel.FreshList ();
			}
			return;
		}

        tip.SetActive(false);
		myJoinList = data["ClubList"] as ArrayList;
		FreshList();
       
    }

	void FreshList()
	{

		ClearList (myJoinClubContent);

		ArrayList List = myJoinList;
		if (List.Count == 0)
		{
			tip.SetActive(true);
			return;
		}
		tip.SetActive(false);
		for (int i = 0; i < List.Count; i++)
		{
			Hashtable ht = List[i] as Hashtable;
			GameObject obj = Instantiate(Resources.Load("Club/ClubItem/ClubItem")) as GameObject;
			var listv = obj.GetComponent<ClubItem>();
			listv.transform.SetParent(myJoinClubContent) ;
			listv.transform.localScale = new Vector2(1, 1);

			//赋值
			listv.SetInfo( ht["url"].ToString(), ht["clubName"].ToString(), ht["memberCount"].ToString(), ht["deskCount"].ToString(), ht["tag"].ToString(), ht["clubId"].ToString(), ht["isHost"].ToString());

		}
	}


    void Start()
    {
    }

    void Update()
    {

    }

    public override void OnAddComplete()
    {

    }

    public override void OnAddStart()
    {

    }

    public override void OnRemoveComplete()
    {

    }

    public override void OnRemoveStart()
    {

    }


}
