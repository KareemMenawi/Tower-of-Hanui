using System;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    private SystemManager _systemManager;

    [SerializeField]
    private Transform top;

    [SerializeField]
    private Transform bottom;

    private Stack<Disc> _discs;
    private Renderer rend;

    public SystemManager SystemManager
    {
        get => _systemManager;
        set => _systemManager = value;
    }

    public Stack<Disc> disks
    {
        get => _discs;
        set => _discs = value;
    }

    private void Awake()
    {
        disks = new Stack<Disc>();
        rend = GetComponent<Renderer>();
        InitialPoleColor();
        top.hideFlags = HideFlags.HideInHierarchy;
        bottom.hideFlags = HideFlags.HideInHierarchy;
    }


    public void SelectDisk()
    {
        if (disks.Count < 1)
            return;
        Disc selectedDisk = disks.Pop();
        selectedDisk.transform.position = top.position;
        SystemManager.selectedDisk = selectedDisk;
        SystemManager.selectedFromPoleIndex = Array.IndexOf(SystemManager.Poles, this);
    }

    private bool CanStack(Disc toStack)
    {
        bool canStack = true;
        if (disks.TryPeek(out Disc topDisk)) canStack = topDisk.Size < toStack.Size;
        return canStack;
    }

    public void PutDisk(Disc toStack)
    {
        if (!CanStack(toStack))
            return;

        int fromIndex = SystemManager.selectedFromPoleIndex;
        int toIndex = Array.IndexOf(SystemManager.Poles, this);

        if (disks.Count <= 0)
            toStack.transform.position = bottom.position;
        else
            toStack.transform.position = disks.Peek().transform.position + SystemManager.DiskOffset;

        disks.Push(toStack);
        toStack.transform.parent = transform;

        SystemManager.RegisterMove(fromIndex, toIndex);
        SystemManager.selectedDisk = null;
    }

    private void OnMouseEnter()
    {
        if (SystemManager.selectedDisk != null && !CanStack(SystemManager.selectedDisk))
            rend.material.SetColor("_Color", new Color(0.5f, 0f, 0f));
        else
            rend.material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
    }

    private void OnMouseExit()
    {
        InitialPoleColor();
    }

    private void OnMouseDown()
    {
        if (SystemManager.selectedDisk != null)
            PutDisk(SystemManager.selectedDisk);
        else
            SelectDisk();
    }

    private void InitialPoleColor()
    {
        rend.material.SetColor("_Color", new Color(0.82f, 0.67f, 0.48f));
    }
}