using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : ChildBehaviour
{

    Animator anim;
    Action curEvtOnEnd;
    public bool animationPlaying { get; private set; }

    protected void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimationActivate(string command)
    {

    }

    public void ActivateTrigger(string name)
    {
        Debug.Log("Playing trigger : "+name);
        anim.SetTrigger(name);
    }

    public void ActivateInt(string nameValue)
    {

    }
    public void ActivateBool(string nameValue)
    {
        string[] s = nameValue.Split('-');

        ActivateBool(s[0], bool.Parse(s[1]));
    }

    public void ActivateBool(string name, bool value)
    {
        anim.SetBool(name, value);
    }

    public void AnimationStart()
    {
        animationPlaying = true;
    }

    public void PushAction(Action onAnimEnd)
    {
        curEvtOnEnd += onAnimEnd;
    }

    public void PopAction()
    {
        if (curEvtOnEnd != null)
        {
            curEvtOnEnd.Invoke();
            curEvtOnEnd = null;
        }
        animationPlaying = false;
    }
}
