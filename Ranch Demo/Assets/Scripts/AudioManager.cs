using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    CsGlobals gl;
    public AudioMixer audioMixer;
    public AudioSource mus_country;
    public AudioSource snd_tractor_engine;
    public AudioSource snd_tractor_fail;
    public AudioSource snd_race_ambient;
    public AudioSource snd_sheep;
    public List<AudioClip> ac_sheep;
    public AudioSource snd_next_speed;
    public AudioSource snd_breacking;
    public AudioSource snd_health;

    GameObject tractor;
    int fadeMode = 0;

    void Start()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;

        tractor = gl.TRACTOR;
    }

    void Update()
    {
        float speed = tractor.GetComponent<Tractor>().maxMoveSpeed;
        if (snd_tractor_engine != null)
        {
            snd_tractor_engine.pitch = speed / 30f;
        }

        if (fadeMode == 1)
        {
            if (GetFadeVolume() < 0f)
            {
                float vol = GetFadeVolume() + Time.deltaTime * 100f;
                SetFadeVolume(vol);
            }
            else
            {
                SetFadeVolume(0f);
                fadeMode = 0;
            }
        }
        else if (fadeMode == 2)
        {
            if (GetFadeVolume() > -80f)
            {
                float vol = GetFadeVolume() - Time.deltaTime * 13f;
                SetFadeVolume(vol);
            }
            else
            {
                SetFadeVolume(-80f);
                fadeMode = 0;
            }
        }
    }

    public void SetMasterPitch(float volume)
    {
        audioMixer.SetFloat("MasterPitch", volume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
    }

    public void MusicCountryPlay()
    {
        if (mus_country != null)
        {
            mus_country.Play();
        }
    }

    public void TractorEnginePlay()
    {
        if (snd_tractor_engine != null)
        {
            snd_tractor_engine.Play();
        }
    }
    public void TractorFailPlay()
    {
        if (snd_tractor_fail != null)
        {
            snd_tractor_fail.Play();
        }
    }

    public void SetFadeVolume(float volume)
    {
        audioMixer.SetFloat("FadeVolume", volume);
    }

    public float GetFadeVolume()
    {
        float volume;
        audioMixer.GetFloat("FadeVolume", out volume);
        return volume;
    }

    public void FadeInOut(bool fade_in)
    {
        if (fade_in)
        {
            fadeMode = 1;
            SetFadeVolume(-80f);
        }
        else
        {
            fadeMode = 2;
            SetFadeVolume(0f);
        }
    }

    public void RaceAmbientPlay()
    {
        if (snd_race_ambient != null)
        {
            snd_race_ambient.Play();
        }
    }

    public void SheepPlayRandom()
    {
        if (ac_sheep.Count > 0)
        {
            int rnd = Random.Range(0, ac_sheep.Count);
            snd_sheep.PlayOneShot(ac_sheep[rnd]);
        }
    }

    public void NextSpeedPlay()
    {
        if (snd_next_speed != null)
        {
            snd_next_speed.Play();
        }
    }

    public void PlayOneShot(AudioClip audio)
    {
        if (audio != null)
        {
            snd_breacking.PlayOneShot(audio);
        }
    }

    public void HealthPlay()
    {
        if (snd_health != null)
        {
            snd_health.Play();
        }
    }
}
