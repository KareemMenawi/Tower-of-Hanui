using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected int poleCount;
    [SerializeField] private int diskCount;

    [SerializeField] private Pole polePrefab;
    [SerializeField] private Disc discPrefab;

    private Vector3 _discOffset;
    private Pole[] _poles;

    [SerializeField] private float poleSpacing;
    [SerializeField][Range(0.1f, 2f)] private float diskScaling;

    public Vector3 DiskOffset 
    {
        get => _discOffset;
        private set => _discOffset = value;
    }

    public Pole[] Poles
    {
        get => _poles;
        private set => _poles = value;
    }

    private void Awake()
    {
        Poles = new Pole[poleCount];
        for (int i = 0; i<poleCount; i++)
        {
            Poles[i] = Instantiate(polePrefab);
            Poles[i].transform.position = Vector3.right * i * (4 + poleSpacing);
        }
    }

}
