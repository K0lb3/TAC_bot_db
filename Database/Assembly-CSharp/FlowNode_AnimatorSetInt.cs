﻿// Decompiled with JetBrains decompiler
// Type: FlowNode_AnimatorSetInt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

[FlowNode.NodeType("Animator/Set Int", 32741)]
[FlowNode.Pin(1, "Output", FlowNode.PinTypes.Output, 1)]
[FlowNode.Pin(10, "Input", FlowNode.PinTypes.Input, 0)]
public class FlowNode_AnimatorSetInt : FlowNode
{
  [FlowNode.ShowInInfo]
  public string ParameterName = "None";
  public int Value;
  [FlowNode.DropTarget(typeof (GameObject), true)]
  [FlowNode.ShowInInfo]
  public GameObject Target;
  public bool UpdateAnimator;

  public override string GetCaption()
  {
    return base.GetCaption() + ":" + this.ParameterName;
  }

  public override void OnActivate(int pinID)
  {
    Animator component = (Animator) (!Object.op_Inequality((Object) this.Target, (Object) null) ? ((Component) this).get_gameObject() : this.Target).GetComponent<Animator>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.SetInteger(this.ParameterName, this.Value);
      if (this.UpdateAnimator)
        component.Update(0.0f);
    }
    this.ActivateOutputLinks(1);
  }
}