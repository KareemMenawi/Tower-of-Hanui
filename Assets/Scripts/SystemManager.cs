using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : GameManager
{
    private Disc _selectedDisk;

    public Disc selectedDisk
    {
        get => _selectedDisk;
        set => _selectedDisk = value;
    }

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < Poles.Length; i++) Poles[i].SystemManager = this;
    }

    //public void CheckForCompletion()
    //{
    //    if (Poles[poleCount - 1].disks.Count >= poleCount)
    //    {
    //        Debug.Log("Gameover!");
    //        StartCoroutine(ReloadScene());
    //    }
    //}

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}