using JetBrains.Annotations;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _timeOfDay;
    [SerializeField] private float _dayDuration;

    [Header("Animations Of Celestial Bodies")]
    [SerializeField] private AnimationCurve _sunCurve;
    [SerializeField] private AnimationCurve _moonCurve;
    [SerializeField] private AnimationCurve _skyBoxCurve;

    [Header("SkyBoxes")]
    [SerializeField] private Material _daySkyBox;
    [SerializeField] private Material _nightSkyBox;

    [Header("Celestial Bodies")]
    [SerializeField] private Light _sun;
    [SerializeField] private Light _moon;

    private float _sunIntensity;
    private float _moonIntensity;

    private void Start()
    {
        _sunIntensity = _sun.intensity;
        _moonIntensity = _moon.intensity;
    }

  
    private void Update()
    {
        _timeOfDay += Time.deltaTime / _dayDuration;
        if (_timeOfDay >= 1) _timeOfDay -= 1;

        RenderSettings.skybox.Lerp(_nightSkyBox, _daySkyBox, _skyBoxCurve.Evaluate(_timeOfDay));
        RenderSettings.sun = _skyBoxCurve.Evaluate(_timeOfDay) > 0.1f ? _sun : _moon;
        DynamicGI.UpdateEnvironment();


        _sun.transform.localRotation = Quaternion.Euler(_timeOfDay * 360f, 180, 0);
        _moon.transform.localRotation = Quaternion.Euler(_timeOfDay * 360f + 180, 180, 0);

        _sun.intensity = _sunIntensity * _sunCurve.Evaluate(_timeOfDay);
        _sun.intensity = _moonIntensity * _moonCurve.Evaluate(_timeOfDay);
    }
}
