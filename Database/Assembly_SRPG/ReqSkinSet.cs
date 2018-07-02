﻿// Decompiled with JetBrains decompiler
// Type: SRPG.ReqSkinSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;

namespace SRPG
{
  public class ReqSkinSet : WebAPI
  {
    public ReqSkinSet(Dictionary<long, string> sets, Network.ResponseCallback response)
    {
      StringBuilder stringBuilder = WebAPI.GetStringBuilder();
      stringBuilder.Append("\"sets\":[");
      string str = string.Empty;
      using (Dictionary<long, string>.Enumerator enumerator = sets.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          KeyValuePair<long, string> current = enumerator.Current;
          str += "{";
          str = str + "\"iid\":" + current.Key.ToString() + ",";
          str = str + "\"iname\":\"" + current.Value + "\"";
          str += "},";
        }
      }
      if (str.Length > 0)
        str = str.Substring(0, str.Length - 1);
      stringBuilder.Append(str);
      stringBuilder.Append("]");
      this.name = "unit/skin/set";
      this.body = WebAPI.GetRequestString(stringBuilder.ToString());
      this.callback = response;
    }
  }
}