﻿// Decompiled with JetBrains decompiler
// Type: SRPG.ReqReadTips
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

using System.Text;

namespace SRPG
{
  public class ReqReadTips : WebAPI
  {
    public ReqReadTips(string tips, string trophyprog, string bingoprog, Network.ResponseCallback response)
    {
      this.name = "tips/end";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\"iname\":");
      stringBuilder.Append("\"" + tips + "\"");
      if (!string.IsNullOrEmpty(trophyprog))
      {
        stringBuilder.Append(",");
        stringBuilder.Append(trophyprog);
      }
      if (!string.IsNullOrEmpty(bingoprog))
      {
        stringBuilder.Append(",");
        stringBuilder.Append(bingoprog);
      }
      this.body = WebAPI.GetRequestString(stringBuilder.ToString());
      this.callback = response;
    }
  }
}