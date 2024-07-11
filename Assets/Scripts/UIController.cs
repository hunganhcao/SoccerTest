using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button kickBtn;
    [SerializeField] Button autoBtn;
    [SerializeField] Button resetBtn;
    public  Action KickAct;
    public  Action AutoAct;
    public static UIController Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    private void Awake()
    {
       Instance = this;

        kickBtn.onClick.AddListener(Kick);
        autoBtn.onClick.AddListener(AutoKick);
        resetBtn.onClick.AddListener(ResetScene);
    }
    private void OnDestroy()
    {
        kickBtn.onClick.RemoveListener(Kick);
        autoBtn.onClick.RemoveListener(AutoKick);
        resetBtn.onClick.RemoveListener(ResetScene);

    }
    private void AutoKick()
    {
        AutoAct.Invoke();
    }

    private void Kick()
    {
        KickAct.Invoke();
    }
    private void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void DisableButton()
    {
        kickBtn.gameObject.SetActive(false);
    } 
    public void EnableButton()
    {
        kickBtn.gameObject.SetActive(true);
    }
}
