using UnityEngine;
using System.Collections;

public class InterfaceClub : MonoBehaviour {

    //获取我的俱乐部
    public const string GetMyClub = "c/getMyClub";
    //获取俱乐部信息
    public const string GetClubInfo = "c/getClubInfo";
    //俱乐部成员信息
    public const string MemberInfo = "c/memberInfo";
    //踢出俱乐部
    public const string DelMember = "c/delMember";
    //设置俱乐部标签
    public const string SetClubTag = "c/setClubTag";
   
    //获取赠送金币内容
    public const string GetCoinContent = "c/getCoinContent";
    //设置是否赠送金币
    public const string SetSendCoin = "c/setSendCoin";
    //获取赠送钻石内容
    public const string GetDiamondContent = "c/getDiamondContent";
    //设置是否赠送钻石
    public const string SetSendDiamond = "c/setSendDiamond";

    //升级俱乐部
    public const string UpdateClub = "c/updateClub";
    //获取升级俱乐部的金额
    public const string GetUpdateCost = "c/getUpdateCost";
    //设置新人欢迎词
    public const string SetWelcomeWord = "c/setWelcomeWord";
    //获取新人欢迎词
    public const string GetWelcomeWord = "c/getWelcome";
    //新建公告
    public const string SetGongGao = "c/setGongGao";
    //热门俱乐部
    public const string GetHotClub = "c/getHotClub";
    //加入俱乐部
    public const string JoinClub = "c/joinClub";
    //设置管理员
    public const string SetManager = "c/setManager";
    //获取管理员
    public const string GetManager = "c/getManager";
    //管理员 查找成员
    public const string ManagerFind = "c/managerFind";
    //筛选 查找成员
    public const string SelectFind = "c/selectFind";
    //成员查找成员
    public const string MemberFind = "c/memberFind";
    //管理员查找全员
    public const string ManagerFindAll = "c/managerFindAll";
    //成员查找全员
    public const string MemberFindAll = "c/memberFindAll";
    //清除公告
    public const string DelGongGao = "c/delGongGao";
    //解散俱乐部
    public const string DissClub = "c/dissClub";
    //获取俱乐部公告
    public const string GetGongGao = "c/getGongGao";
    //获取俱乐部牌局记录
    public const string GetClubRecord = "c/getClubRecord";
    //获取俱乐部牌局
    public const string GetClubMatch = "c/getMatch";
    //创建俱乐部
    public const string CreateClub = "c/createClub";
    //编辑俱乐部信息
    public const string FixClubInfo = "c/fixClubInfo";
    //获取二维码图片
    public const string GetErWeiMa = "c/getErWeiMa";
    //搜索俱乐部
    public const string GetClub = "c/getClub";
    //设置免打扰和私密
    public const string SetRefuseAndSelf = "c/setRefuseAndSelf";
    //退出俱乐部
    public const string QuitClub = "c/quitClub";
    //获得钻石赠送信息
    public const string GetPlayerDiamondInfo = "c/getPlayerDiamondInfo";
    //获取赠送钻石记录
    public const string GetPlayerDiamondrecord = "c/getPlayerDiamondrecord";
    //赠送钻石
    public const string SendToPlayerDiamond = "c/sendToPlayerDiamond";
}
