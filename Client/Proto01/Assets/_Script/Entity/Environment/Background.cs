using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour, IGameEventListener
{
    public float limitDistance;

    private List<Transform> _backgroundList = new List<Transform>();

<<<<<<< HEAD
    void Awake()
    {
        _backgroundList.Clear();
        for (int i = 0; i < transform.childCount; i++)
            _backgroundList.Add(transform.GetChild(i));
    }
=======
    //CHARACTER오브젝트를 받아서 갑니다.
    //public GameObject testobject;
    //private void Update()
    //{
    //    CalculateDistance(testobject.transform.position.x);
    //}
>>>>>>> master

    void OnEnable()
    {
        GameEventManager.Instance.Register(this);
    }

    void OnDisable()
    {
        GameEventManager.Instance.Unregister(this);
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

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.UpdateMoveDistance:
                CalculateDistance((float)args[0]);
                break;

            default:
                break;
        }
    }


}
