using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuverMuver : MonoBehaviour
{
    [SerializeField] private TMP_Text _hjTxt;

    private void Start()
    {
        Application.targetFrameRate = 120;
        
        if (_hjTxt == null)
            return;
        
        var urp = PlayerPrefs.HasKey("Sisamba") ? PlayerPrefs.GetInt("Sisamba") : 0;
        _hjTxt.SetText($"Record: {urp} sec");
    }

    public void Shmand()
    {
        Horpa(1);
    }
    
    public void MatherRunk()
    {
        Horpa(0);
    }

    public void IamPoshol()
    {
        Application.Quit();
    }

    private void Horpa(int hij)
    {
        SceneManager.LoadScene(hij);
    }
}
