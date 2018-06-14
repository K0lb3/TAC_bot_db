﻿// Decompiled with JetBrains decompiler
// Type: SRPG.FlowNode_ReqBtlComReq
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using GR;

namespace SRPG
{
  public class FlowNode_ReqBtlComReq : FlowNode_Network
  {
    private FlowNode_ReqBtlComReq.OnSuccesDelegate mOnSuccessDelegate;

    public FlowNode_ReqBtlComReq.OnSuccesDelegate OnSuccessListeners
    {
      set
      {
        this.mOnSuccessDelegate = value;
      }
    }

    public override void OnActivate(int pinID)
    {
    }

    public override void OnSuccess(WWWResult www)
    {
      if (Network.IsError)
      {
        Network.EErrCode errCode = Network.ErrCode;
        switch (errCode)
        {
          case Network.EErrCode.UnSelectable:
            this.OnBack();
            break;
          case Network.EErrCode.OutOfDateQuest:
            this.OnBack();
            break;
          case Network.EErrCode.ChallengeLimit:
            this.OnBack();
            break;
          default:
            if (errCode != Network.EErrCode.QuestEnd)
            {
              if (errCode == Network.EErrCode.NoBtlInfo)
              {
                this.OnFailed();
                break;
              }
              this.OnRetry();
              break;
            }
            this.OnFailed();
            break;
        }
      }
      else
      {
        WebAPI.JSON_BodyResponse<BattleCore.Json_Battle> jsonObject = JSONParser.parseJSONObject<WebAPI.JSON_BodyResponse<BattleCore.Json_Battle>>(www.text);
        DebugUtility.Assert(jsonObject != null, "res == null");
        if (jsonObject.body == null)
        {
          this.OnRetry();
        }
        else
        {
          Network.RemoveAPI();
          this.mOnSuccessDelegate(jsonObject.body);
        }
      }
    }

    public delegate void OnSuccesDelegate(BattleCore.Json_Battle response);
  }
}