using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour, IGameEventListener
{
    public float limitDistance;

    private List<Transform> _backgroundList = new List<Transform>();


    public GameObject testobject;
    private void Update()
    {
        CalculateDistance(testobject.transform.position.x);
    }

    void Awake()
    {
        GameEventManager.Instance.Register(this);

        _backgroundList.Clear();
        for (int i = 0; i < transform.childCount; i++)
            _backgroundList.Add(transform.GetChild(i));
    }


    private void CalculateDistance(float currentX)
    {
        int realIndex = (int)(currentX / limitDistance);
        int firstIndex = (realIndex - 1) % _backgroundList.Count;

        for(int i = 0 ; i < _backgroundList.Count ; i++)
        {
            if (firstIndex == -1) firstIndex = _backgroundList.Count - 1;
            if (firstIndex == _backgroundList.Count) firstIndex = 0;

            Vector3 nextPosition = new Vector3(limitDistance * (realIndex + i), 0, 0);
            _backgroundList[firstIndex].transform.localPosition = nextPosition;

            firstIndex++;
        }
    }

    public void OnGameEvent(GameEventType gameEventType, params Object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.UpdateMoveDistance:
                break;

            default:
                break;
        }
    }


}
