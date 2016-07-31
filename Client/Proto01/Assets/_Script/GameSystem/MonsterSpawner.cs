using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public class Request
    {
        private Monster monsterPrefab;
        private int monsterCount;

        public Request(Monster monsterPrefab, int monsterCount)
        {
            this.monsterPrefab = monsterPrefab;
            this.monsterCount = monsterCount;
        }

        public Monster MonsterPrefab
        {
            get
            {
                return monsterPrefab;
            }
        }

        public int MonsterCount
        {
            get
            {
                return monsterCount;
            }
        }
    } 
    private Queue<Request> requests = new Queue<Request>();

    public bool RequestEmpty
    {
        get
        {
            return requests.Count == 0;
        }
    }

    public void SendRequest(Request request)
    {
        requests.Enqueue(request);
    }

    private void Start()
    {
        StartCoroutine(ProcessingRequest());
    }

    private IEnumerator ProcessingRequest()
    {
        while (true)
        {
            if (requests.Count != 0)
            {
                yield return StartCoroutine(ActionMonsters(requests.Dequeue()));
            }
            else
            {
                yield return new WaitUntil(() => requests.Count != 0);
            }
        }
    }

    private IEnumerator ActionMonsters(Request request)
    {
        int standbyMonsterCount = request.MonsterCount;

        do
        {
            GameObject gameObject = Instantiate(request.MonsterPrefab.gameObject, transform.position, transform.rotation) as GameObject;

            yield return new WaitUntil(() => gameObject == null);

            GameEventManager.Instance.Notify(GameEventType.MonsterDied);
        } while (--standbyMonsterCount != 0);
    }
}
