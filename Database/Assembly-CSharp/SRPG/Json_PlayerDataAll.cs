﻿// Decompiled with JetBrains decompiler
// Type: SRPG.Json_PlayerDataAll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

namespace SRPG
{
  public class Json_PlayerDataAll
  {
    public Json_PlayerData player;
    public Json_Unit[] units;
    public Json_Item[] items;
    public Json_Mail[] mails;
    public Json_Party[] parties;
    public Json_Friend[] friends;
    public Json_Artifact[] artifacts;
    public Json_Skin[] skins;
    public Json_Notify notify;
    public Json_MultiFuids[] fuids;
    public int status;
    public string cuid;
    public long tut;
    public int first_contact;
    public Json_Versus vs;
  }
}