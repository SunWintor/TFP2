
using GameMain;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class Logo : UIFormLogic {
    //Logo贴图
    private Image SplashLogo;
    //渐入渐出速度
    public float FadeSpeed;
    //等待时间
    public float WaitTime;

    public enum FadeStatus {
        FadeIn,
        FadeWait,
        FadeOut
    }
    private FadeStatus mStatus = FadeStatus.FadeIn;

    private ProcedureSplash procedureSplash;

    //当前透明度
    private float mAlpha = 0.0F;
    //渐入结束的时间
    private float mFadeInFinishedTime;

    protected override void OnOpen(object userData) {
        procedureSplash = (ProcedureSplash)userData;
    }

    private void Start() {
        Transform logoTransform = transform.Find("SilentHouse");
        SplashLogo = logoTransform.GetComponent<Image>();
    }

    void Update() {
        switch (mStatus) {
            case FadeStatus.FadeIn:
                mAlpha += FadeSpeed * Time.deltaTime;
                if (mAlpha >= 1) {
                    mStatus = FadeStatus.FadeWait;
                    mFadeInFinishedTime = Time.time;
                }
                break;
            case FadeStatus.FadeOut:
                mAlpha -= FadeSpeed * Time.deltaTime;
                if (mAlpha <= 0) {
                    procedureSplash.ChangeToLogin();
                    Destroy(this);
                }
                break;
            case FadeStatus.FadeWait:
                if (Time.time > mFadeInFinishedTime + WaitTime) {
                    mStatus = FadeStatus.FadeOut;
                }
                break;
        }
        Color col = new Color(SplashLogo.color.r, SplashLogo.color.g, SplashLogo.color.b, mAlpha);
        SplashLogo.color = col;
    }
}
