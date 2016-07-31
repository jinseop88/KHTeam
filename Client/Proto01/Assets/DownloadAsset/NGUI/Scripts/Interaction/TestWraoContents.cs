using UnityEngine;
using System.Collections;

public class TopPlayersWrap : UIWrapContent
{
    int itemCount;
    int itemsTotalSize;
    int startPositionForFirstItem;
    float startY;
    bool areUpdateItemPreCalcsDone = false;
    bool areOnMovePreCalcsDone = false;

    private void DoUpdateItemPreCalcs()
    {
        this.itemCount = transform.childCount;
        this.itemsTotalSize = this.itemCount * Mathf.RoundToInt(itemSize);
    }

    private void DoOnMovePreCalcs(UIPanel panel)
    {
        this.startY = panel.transform.localPosition.y;
    }

    public void InitTopPlayers()
    {
        // Set positions
        this.RepositionChildrenToStartFromTop(NGUITools.FindInParents<UIPanel>(gameObject));
        // Modify items
        for (int i = 0; i < transform.childCount; i++)
        {
            this.UpdateTopPlayerItem(transform.GetChild(i), i);
        }
    }

    private void RepositionChildrenToStartFromTop(UIPanel panel)
    {
        this.startPositionForFirstItem = (Mathf.RoundToInt(panel.GetViewSize().y) / 2) - Mathf.RoundToInt(itemSize) / 2 - 10;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = new Vector3(0, startPositionForFirstItem - i * Mathf.RoundToInt(itemSize), 0);
        }
    }

    protected override void UpdateItem(Transform item, int index)
    {
        if (!this.areUpdateItemPreCalcsDone)
        {
            this.areUpdateItemPreCalcsDone = true;
            this.DoUpdateItemPreCalcs();
        }

        int realIndex = (Mathf.RoundToInt(item.localPosition.y - startPositionForFirstItem) / -itemsTotalSize * itemCount) + index;
        this.UpdateTopPlayerItem(item, realIndex);
    }

    private void UpdateTopPlayerItem(Transform item, int realIndex)
    {
        // INSERT YOUR ITEM UPDATE CODE HERE!!!
        //item.Find("PlayerName").GetComponent<UILabel>().text = "Player " + realIndex;
    }

    protected override void OnMove(UIPanel panel)
    {
        if (!this.areOnMovePreCalcsDone)
        {
            this.areOnMovePreCalcsDone = true;
            this.DoOnMovePreCalcs(panel);
        }

        if (panel.transform.localPosition.y < startY)
        {
            Vector3 overRide = panel.transform.localPosition;
            overRide.y = startY;
            panel.transform.localPosition = overRide;
            panel.clipOffset = new Vector2(panel.clipOffset.x, -startY);
        }

        base.OnMove(panel);
    }
}