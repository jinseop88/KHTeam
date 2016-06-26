using UnityEngine;
using System.Collections;

public class BSpline : MonoBehaviour
{
    private static BSpline instance;
    public static BSpline Instance
    {
        get
        {
//             if (instance == null)
//             {
//                 instance = FindObjectOfType<BSpline>();
//                 instance.Initialize();
//             }

            return instance;
        }
    }    

	public BSplineControlPoint[] m_controlPoints;
	
	[HideInInspector]
	public float startTime = 0.0f;
	
	[HideInInspector]
	public float endTime = 1.0f;
	
	private int count;
	
	private Vector3[] positions;
	private float[] times;

    /// <summary>
    /// 시작지점부터 끝지점까지의 이동 거리
    /// </summary>
    public float maxLength { private set;  get; }

	public bool Initialize()
	{
        if (m_controlPoints == null)
            return false;

		if( m_controlPoints.Length != 0)
		{
		
			positions = new Vector3[m_controlPoints.Length + 4];
			times = new float[m_controlPoints.Length + 2];
		
			count = m_controlPoints.Length + 4;
		
			// Copy positions data (triplicate start and en points so that curve passes trough them.)
			positions[0] = positions[1] = m_controlPoints[0].cachedPosition;
		
			for(int i = 0; i < m_controlPoints.Length; ++i)
			{
				positions[i + 2] = m_controlPoints[i].cachedPosition;
			}
		
			positions[count - 1] = positions[count - 2] = m_controlPoints[m_controlPoints.Length - 1].cachedPosition;
		
			// Setup times (subdivide interval to get arrival times at each knot location)
			float dt = (endTime - startTime) / (float)(m_controlPoints.Length + 1);
		
			times[0] = startTime;
			for(int i = 0; i < m_controlPoints.Length; ++i)
			{
				times[i + 1] = times[i] + dt;
			}
			times[m_controlPoints.Length + 1] = endTime;

            maxLength = 0.0f;

            for (int i = 1; i < positions.Length; i++)
                maxLength += Vector3.Distance(positions[i - 1], positions[i]);

			//Debug.Log("Initialize success.");
			return true;
		}
		
		//Debug.Log("Initialize failed.");
		return false;
		
	}
	
	// PUBLIC INTERFACE
	
	public void Clean()
	{
		positions = null;
		times = null;
		count = 0;
	}

    public Vector3 Velocity(float t1, float t2)
    {
        Vector3 vel = Evaluate(t2) - Evaluate(t1);
        vel.Normalize();

        return vel;
    }

    /// <summary>
    /// 지정한 위치와 가장 근접한 Path 에서의 t값(0.0~1.0)을 찾는다
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public float FindClosetPosition(Vector3 position)
    {
        int p0 = -1;
        int p1 = -1;
        float dist = maxLength;

        // 가장 가까운 포인트를 찾는다
        for (int i = 0; i < m_controlPoints.Length; i++)
        {
            Vector3 relative = m_controlPoints[i].cachedPosition - position;
            if (relative.sqrMagnitude < dist * dist)
            {
                p0 = i;
                dist = relative.magnitude;
            }
        }

        // 두번째로 가까운 포인트를 찾는다
        if (p0 > -1)
        {
            if (p0 == 0)
            {
                p1 = 1;
            }
            else if (p0 == m_controlPoints.Length - 1)
            {
                p1 = p0 - 1;
            }
            else
            {
                // 앞뒤 포인트를 찾는다
                Vector3 dir = m_controlPoints[p0 + 1].cachedPosition - m_controlPoints[p0].cachedPosition;
                dir.Normalize();

                Vector3 relative = position - m_controlPoints[p0].cachedPosition;
                relative.Normalize();

                if (Vector3.Dot(dir, relative) > 0.0f)
                    p1 = p0 + 1;
                else
                    p1 = p0 - 1;
            }
        }

        if (p0 > -1)
        {
            // 이진 탐색 시작
            if (p0 < p1)
                return BinarySearch(position, times[p0], times[p1+2], 0.0001f, 0.0f);
            else
                return BinarySearch(position, times[p1], times[p0+2], 0.0001f, 0.0f);
        }

        return 0.0f;
    }

    /// <summary>
    /// 근접한 T값을 찾기 위한 이진 탐색
    /// 이전에 비교한 거리(lastDist)와 현재 비교한 거리(dist)의 차가 오차 허용거리(approxDist)보다 작으면 해당 위치(mid)를 리턴한다
    /// </summary>
    /// <param name="position">지정한 위치</param>
    /// <param name="minT">시작 시간</param>
    /// <param name="maxT">끝 시간</param>
    /// <param name="approxDist">오차 허용 거리</param>
    /// <param name="lastDist">최종 거리</param>
    /// <returns></returns>
    float BinarySearch(Vector3 position, float minT, float maxT, float approxDist, float lastDist)
    {
        if (maxT < minT)
            return 0.0f;

        float mid = (minT + maxT) * 0.5f;
        Vector3 point = Evaluate(mid);
        Vector3 dir = position - point;
        float dist = dir.magnitude;
        if (Mathf.Abs(dist-lastDist) < approxDist)
        {
            return mid;
        }
        else
        {
            Vector3 pathDir = Velocity(minT, maxT);
            if (Vector3.Dot(pathDir, dir) > 0.0f)
                return BinarySearch(position, mid, maxT, approxDist, dist);
            else
                return BinarySearch(position, minT, mid, approxDist, dist);
        }
    }

	public Vector3 Evaluate(float t)
	{
		if( count < 6 )
			return Vector3.zero;
		
		// Handle boundry conditions
		if( t <= times[0] )
		{
			return positions[0];
		}
		else if ( t >= times[count - 3] )
		{
			return positions[count - 3];
		}
		
		// Find segment and parameter
		
		int segment = 0;
		while(segment < count - 3)
		{
			
			if( t <= times[segment + 1] )
			{
				break;
			}
			
			segment++;
			
		}
		
		float t0 = times[segment];
		float t1 = times[segment + 1];
		float u = (t - t0) / (t1 - t0);
		
		// match segment index to standard B-spline terminology
		segment += 3;
		
		// Evaluate
		Vector3 A = positions[segment] - 3.0f * positions[segment - 1] + 3.0f * positions[segment - 2] - positions[segment - 3];
		Vector3 B = 3.0f * positions[segment - 1] - 6.0f * positions[segment - 2] + 3.0f * positions[segment - 3];
		Vector3 C = 3.0f * positions[segment - 1] - 3.0f * positions[segment - 3];
		Vector3 D = positions[segment - 1] + 4.0f * positions[segment - 2] + positions[segment - 3];
		
		return (D + u * (C + u * (B + u * A))) / 6.0f;
	}
	
	// Render
	void OnDrawGizmos()
	{
		
		Initialize();

		Gizmos.color = Color.blue;
		
		Vector3 start = Evaluate(0.0f);
		Vector3 end = Vector3.zero;
		
		for(float t = startTime; t < endTime; t += 0.01f)
		{
			
			end = Evaluate(t);
			
			Gizmos.DrawLine(start, end);
			
			start = end;
			
		}
		
	}

    void Awake()
    {
        instance = this;
        Initialize();
    }
}
