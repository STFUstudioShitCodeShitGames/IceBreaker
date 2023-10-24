using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shumavlenka : MonoBehaviour
{
    public event Action Vmr;
    
    [SerializeField] private float _silerp;
    [SerializeField] private float _abcent;

    private float _himit;

    private bool _mertv;
    
    private void Start()
    {
        var pulka = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);
        var wPo = Camera.main.ScreenToWorldPoint(pulka);
        _himit = wPo.x - _abcent;
    }

    private void Update()
    {
        if (_mertv)
            return;
        
        if (Input.GetMouseButton(0))
            SudaTuda();
    }

    private void SudaTuda()
    {
        var wPo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wPo.y = transform.position.y;
        wPo.z = 0;
        wPo.x = Mathf.Clamp(wPo.x, -_himit, _himit);
        
        transform.position = Vector3.Lerp(transform.position, wPo, _silerp * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _mertv = true;
        Vmr?.Invoke();
    }
}
