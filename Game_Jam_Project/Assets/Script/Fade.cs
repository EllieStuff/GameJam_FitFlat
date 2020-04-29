using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public static class Fade
{
    public static IEnumerator ScreenFade(float time, string imageName)
    {
        Image fadeIn = GameObject.Find(imageName).GetComponent<Image>();
        Interpolator weight = new Interpolator(time/2, Interpolator.Type.COS);
        fadeIn.raycastTarget = true;
        weight.ForceMax();
        weight.ToMin();
        while (!weight.IsMinPrecise)
        {
            weight.Update(Time.deltaTime);
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, weight.Value);
            yield return null;
        }

        weight.ToMax();
        while (!weight.IsMinPrecise)
        {
            weight.Update(Time.deltaTime);
            fadeIn.color = new Color(0f, 0f, 0f, weight.Value);
            yield return null;
        }
        fadeIn.raycastTarget = false;
    }

    public static  IEnumerator ScreenFadeOut(float time, string imageName)
    {
        Image fadeIn = GameObject.Find(imageName).GetComponent<Image>();
        Interpolator weight = new Interpolator(time, Interpolator.Type.COS);
        fadeIn.raycastTarget = true;
        weight.ForceMax();
        weight.ToMin();
        while (!weight.IsMinPrecise)
        {
            weight.Update(Time.deltaTime);
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, weight.Value);
            yield return null;
        }
        fadeIn.raycastTarget = false;
    }

    public static IEnumerator ScreenFadeIn(float time, string ImageName)
    {
        Image fadeIn = GameObject.Find(ImageName).GetComponent<Image>();
        Interpolator weight = new Interpolator(time, Interpolator.Type.COS);
        fadeIn.raycastTarget = true;
        weight.ToMax();
        while (!weight.IsMaxPrecise)
        {
            weight.Update(Time.deltaTime);
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, weight.Value);
            yield return null;
        }
        fadeIn.raycastTarget = false;
    }

    public static IEnumerator ScreenFadeInAndLoadScene(float value, string imageName, string sceneName)
    {
        Image fadeIn = GameObject.Find(imageName).GetComponent<Image>();
        Interpolator weight = new Interpolator(value, Interpolator.Type.COS);
        fadeIn.raycastTarget = true;
        weight.ToMax();
        while (!weight.IsMaxPrecise)
        {
            weight.Update(Time.deltaTime);
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, weight.Value);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
        yield return null;
    }

    public static IEnumerator MusicFadeOut(float time, AudioMixer audioMixer)
    {
        Interpolator weight = new Interpolator(time, Interpolator.Type.COS);
        weight.ToMax();
        float currentVolume;
        audioMixer.GetFloat("MusicVolume", out currentVolume);
        float difference = 80 - Mathf.Abs(currentVolume);
        while (!weight.IsMaxPrecise)
        {
            weight.Update(Time.deltaTime);
            float tmp = difference;
            tmp *= weight.Value;
            audioMixer.SetFloat("MusicVolume", currentVolume - tmp);
            yield return null;
        }
    }

    public static IEnumerator MusicFadeIn(float time, AudioMixer audioMixer)
    {
        Interpolator weight = new Interpolator(time, Interpolator.Type.COS);
        weight.ToMax();
        float currentVolume;
        audioMixer.GetFloat("MusicVolume", out currentVolume);
        audioMixer.SetFloat("MusicVolume", -80);
        float difference = 80 - Mathf.Abs(currentVolume);
        currentVolume = -80;
        while (!weight.IsMaxPrecise)
        {
            weight.Update(Time.deltaTime);
            float tmp = difference;
            tmp *= weight.Value;
            audioMixer.SetFloat("MusicVolume", currentVolume + tmp);
            yield return null;
        }
    }

}
