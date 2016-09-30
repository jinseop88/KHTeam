using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MapDistanceType
{
    Far,
    Mid,
    Near,
}

public class Background : MonoBehaviour, IGameEventListener
{
    public float limitDistance;
    public MapDistanceType distanceType;

    private List<Transform> _backgroundList = new List<Transform>();

    void Awake()
    {
        _backgroundList.Clear();
        for (int i = 0; i < transform.childCount; i++)
            _backgroundList.Add(transform.GetChild(i));
    }

    void OnEnable()
    {
        GameEventManager.Register(this);
    }

    public float GetEndX()
    {
        float endX = 0f;
        for (int i = 0; i < _backgroundList.Count; i++)
            endX = Mathf.Max(_backgroundList[i].transform.position.x + limitDistance, endX);

        return endX;
    }

    void OnDisable()
    {
        GameEventManager.Unregister(this);
    }


    private void CalculateDistance(float currentX)
    {
        if (currentX < transform.position.x) return;

        int realIndex = (int)(currentX / limitDistance);
        int firstIndex = (realIndex - 1) % _backgroundList.Count;

        for(int i = 0 ; i < _backgroundList.Count ; i++)
        {
            if (firstIndex == -1) firstIndex = _backgroundList.Count - 1;
            if (firstIndex == _backgroundList.Count) firstIndex = 0;

			Vector3 nextPosition = new Vector3(limitDistance * (realIndex + i),
				_backgroundList[firstIndex].transform.position.y,
				_backgroundList[firstIndex].transform.position.z);
            _backgroundList[firstIndex].transform.position = nextPosition;

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
