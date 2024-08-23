using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectH : MonoBehaviour
{
    #region Fields
    [SerializeField] private EffectD effectData;
    [SerializeField] private LazerH lazerHandler;
    [SerializeField] private Texture[] textures;

    private int animationStep;
    private float fpsCounter;
    #endregion

    #region Methods
    void Update()
    {
        Enableffect();
    }

    #region Effect
    void Enableffect()
    {
        fpsCounter += Time.deltaTime;

        if (fpsCounter >= 5f / effectData.fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }

            lazerHandler.laserRenderer.material.SetTexture("_MainTex", textures[animationStep]);
            fpsCounter = 0f;
        }
    }
    #endregion

    #endregion
}
