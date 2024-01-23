using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform LogSig, Log, Sig, FM, CP, Kons, Buttn;    
    // Start is called before the first frame update
    void Start()
    {
        LogSig.DOAnchorPos(new Vector2(0, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, -1000), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500,0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    public void Loginbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(0, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, -1000), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    public void Signupbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(0, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, -1000), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    public void FMbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, 127.9f), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(0, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    public void Konsulbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, 127.9f), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(0, 0), 1.0f);
    }
    public void CPbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, 127.9f), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(0, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
}
