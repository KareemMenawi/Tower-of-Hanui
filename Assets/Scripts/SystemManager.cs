using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : GameManager
{
    private Disc _selectedDisk;
    [SerializeField] [Range(0.1f, 2f)] private float autoSolveDelay = 0.5f;

    private Coroutine autoSolveRoutine;

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

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void AutoSolve()
    {
        if (autoSolveRoutine != null)
            StopCoroutine(autoSolveRoutine);
        ResetGame();

        List<Move> moves = new List<Move>();

        HanoiSolver.Solve(
            Poles[0].disks.Count,
            0,
            2,
            1,
            moves
        );

        autoSolveRoutine = StartCoroutine(ExecuteMoves(moves));
    }

    private IEnumerator ExecuteMoves(List<Move> moves)
    {
        foreach (Move move in moves)
        {
            yield return new WaitForSeconds(autoSolveDelay);

            Poles[move.from].SelectDisk();

            yield return new WaitForSeconds(autoSolveDelay * 0.5f);

            Poles[move.to].PutDisk(selectedDisk);
        }
    }
    public void ResetGame()
    {
        if (autoSolveRoutine != null)
            StopCoroutine(autoSolveRoutine);

        // Destroy ALL discs in the scene
        Disc[] allDiscs = FindObjectsOfType<Disc>();
        foreach (Disc disc in allDiscs)
            Destroy(disc.gameObject);

        // Clear pole stacks
        foreach (Pole pole in Poles)
            pole.disks.Clear();

        selectedDisk = null;

        // Respawn
        for (int i = 0; i < diskCount; i++)
        {
            Disc disc = Instantiate(discPrefab, Poles[0].transform);
            disc.Scale = 4 - i * diskScaling;
            disc.Size = i;
            Poles[0].PutDisk(disc);
        }
    }
}