﻿// Decompiled with JetBrains decompiler
// Type: SRPG.Tooltip
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

namespace SRPG
{
  public class Tooltip : MonoBehaviour
  {
    public static Vector2 TooltipPosition;
    public RectTransform Body;
    public Text TooltipText;
    public string CloseTrigger;
    public float DestroyDelay;
    private Animator mAnimator;
    private bool mDestroying;
    public bool CloseOnPress;

    public Tooltip()
    {
      base.\u002Ector();
    }

    public static void SetTooltipPosition(RectTransform rect, Vector2 localPos)
    {
      Vector2 vector2 = Vector2.op_Implicit(((Transform) rect).TransformPoint(Vector2.op_Implicit(localPos)));
      CanvasScaler componentInParent = (CanvasScaler) ((Component) rect).GetComponentInParent<CanvasScaler>();
      if (Object.op_Inequality((Object) componentInParent, (Object) null))
      {
        Vector3 localScale = ((Component) componentInParent).get_transform().get_localScale();
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Vector2& local1 = @vector2;
        // ISSUE: explicit reference operation
        // ISSUE: explicit reference operation
        (^local1).x = (^local1).x / localScale.x;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Vector2& local2 = @vector2;
        // ISSUE: explicit reference operation
        // ISSUE: explicit reference operation
        (^local2).y = (^local2).y / localScale.y;
      }
      Tooltip.TooltipPosition = vector2;
    }

    public void ResetPosition()
    {
      if (!Object.op_Inequality((Object) this.Body, (Object) null))
        return;
      this.Body.set_anchorMin(Vector2.get_zero());
      this.Body.set_anchorMax(Vector2.get_zero());
      this.Body.set_anchoredPosition(Tooltip.TooltipPosition);
    }

    private void Start()
    {
      this.mAnimator = (Animator) ((Component) this).GetComponent<Animator>();
      this.ResetPosition();
    }

    public void Close()
    {
      this.mDestroying = true;
      if (Object.op_Inequality((Object) this.mAnimator, (Object) null) && !string.IsNullOrEmpty(this.CloseTrigger))
        this.mAnimator.SetTrigger(this.CloseTrigger);
      Object.Destroy((Object) ((Component) this).get_gameObject(), this.DestroyDelay);
    }

    private void Update()
    {
      if (this.mDestroying)
        return;
      if (this.CloseOnPress)
      {
        if (!Input.GetMouseButton(0))
          return;
      }
      else if (Input.GetMouseButton(0))
        return;
      this.Close();
    }
  }
}