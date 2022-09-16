// DiscoBall Mod Made By Fault With Help From Husky#9424 (;
using UnityEngine;
using UnityEngine.InputSystem;
using DiscoBall.Config;

class DiscoBallMusic : MonoBehaviour
{
    AudioSource Source;
    bool ContiuneSpinning = false;
    bool menu = false;
    float Speed = Config.SpinSpeed;
    float MusicDistance = Config.MusicDistance;
    float DefaultVolume = Config.DefaultVolume;
    bool PlayOnStart = Config.PlayOnStart;
    bool MenuOpenByDefault = Config.MenuOpenByDefault;
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        Source.volume = DefaultVolume;

        if (!PlayOnStart)
            Source.enabled = false;

        if (MenuOpenByDefault)
            menu = true;
    }
    void FixedUpdate()
    {
        if (Source.isPlaying || ContiuneSpinning)
        transform.Rotate(0f, Speed, 0f * Time.deltaTime);
    }
    void OnGUI()
    {
        if (menu)
        {
            GUILayout.Label($"\n\n\n\n\n\n\n\n\n\nVolume: {Source.volume}");
            if (GUILayout.Button("Volume +"))
                Source.volume += 0.1f;
            if (GUILayout.Button("Volume -"))
                Source.volume -= 0.1f;
            if (GUILayout.Button("Play"))
            {
                if (!Source.enabled)
                    Source.enabled = true;
            }
            if (GUILayout.Button("Stop"))
            {
                if (Source.enabled)
                    Source.enabled = false;
            }
        }
    }
    void LateUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard.tabKey.wasPressedThisFrame)
        {
            menu ^= true;
        }
        var distance = Vector3.Distance(gameObject.transform.position, GorillaLocomotion.Player.Instance.transform.position);
        if (distance > MusicDistance)
        {
            ContiuneSpinning = true;
            if (!Source.enabled)
                Source.enabled = true;

            if (Source.isPlaying)
                Source.Pause();
        }
        else if (!Source.isPlaying)
        {
            ContiuneSpinning = false;
            if (Source.enabled)
                Source.Play();
        }
    }
}
