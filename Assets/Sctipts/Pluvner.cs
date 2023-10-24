using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pluvner : MonoBehaviour
{
    [SerializeField] private Shumavlenka _shumavlenka;
    
    [SerializeField] private float _empR;
    [SerializeField] private float _spse;
    [SerializeField] private float _verhuchaOts;
    [SerializeField] private DangRork[] _dangRork;

    [SerializeField] private TMP_Text _chikaKa;
    [SerializeField] private GameObject _hilgan;

    private float _verhucha;

    private Vector3[] _bubi;

    private int _uf;
    
    private void Start()
    {
        var pulka = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);
        var wPo = Camera.main.ScreenToWorldPoint(pulka);

        _verhucha = wPo.y + _verhuchaOts;
        var onka = Mathf.RoundToInt((wPo.x  * 2 - _spse) / (_empR + _spse));

        _bubi = new Vector3[onka];

        var orka = new Vector2(_empR / 2f + -wPo.x, _verhucha);
        for (var lok = 0; lok < _bubi.Length; lok++)
        {
            _bubi[lok] = orka;
            orka.x += _spse + _empR;
        }

        _shjoork = StartCoroutine(CokKoc());
        _podacha = StartCoroutine(Podal());
        _shumavlenka.Vmr += OnVmr;
        
        _hilgan.SetActive(false);
    }

    private Coroutine _shjoork;

    private void OnVmr()
    {
        StopCoroutine(_shjoork);
        StopCoroutine(_podacha);
        
        var shush = GetComponentsInChildren<DangRork>();
        foreach (var rork in shush)
            rork.Vmert = true;
        
        _hilgan.SetActive(true);
        
        
        if (!PlayerPrefs.HasKey("Sisamba"))
            PlayerPrefs.SetInt("Sisamba", _uf);
        else if (PlayerPrefs.GetInt("Sisamba") < _uf)
            PlayerPrefs.SetInt("Sisamba", _uf);
    }
    
    private Coroutine _podacha;

    private IEnumerator CokKoc()
    {
        while (true)
        {
            _chikaKa.text = $"Second {_uf}";
            yield return new WaitForSecondsRealtime(1f);
            _uf++;
        }
    }
    
    private IEnumerator Podal()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.7f);
            WowPow();
        }
    }
    
    private void WowPow()
    {
        var shufka = Random.Range(0, _bubi.Length);
        var shufka2 = Random.Range(0, _bubi.Length);

        for (var fur = 0; fur < _bubi.Length; fur++)
        {
            if (fur == shufka || fur == shufka2)
                continue;

            Instantiate(_dangRork[Random.Range(0, _dangRork.Length)], _bubi[fur], Quaternion.identity, transform);
        }
    }
}