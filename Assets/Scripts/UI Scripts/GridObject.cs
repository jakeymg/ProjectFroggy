using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GridObject : MonoBehaviour
{
    [SerializeField] private int page;
    [SerializeField] private int row;
    [SerializeField] private int col;
    [SerializeField] private int gridObejctId;
    [SerializeField] private bool occupied;
    [SerializeField] private GameObject currentStickerObject;
    [SerializeField] private TextMeshProUGUI debugGridPositionText;
    [SerializeField] private Vector3 gridOriginPosCanvas;
    [SerializeField] private float yPosOffset;
    [SerializeField] private Vector3 gridObjectPosOffset;

    private void Start() 
    {
        SetUnoccupied();
        StartCoroutine(SetGridPositionCoroutine());
    }

    IEnumerator SetGridPositionCoroutine()
    {
        yield return new WaitForEndOfFrame();

        SetGridOriginPos();
    }

    public void SetGridOriginPos()
    {
        gridOriginPosCanvas = (this.GetComponent<RectTransform>().localPosition) + new Vector3(0, yPosOffset, 0);
    }

    public void SetDebugText()
    {
        string debugString = (page + "," + row + "," + col); 
        debugGridPositionText.text = debugString;
    }

    public void SetGridObjectId(int id)
    {
        gridObejctId = id;
    }

    public int FetchGridObjectId()
    {
        return gridObejctId;
    }

    public void SetPageNumber(int pageId)
    {
        page = pageId;
    }

    public int FetchPageNumber()
    {
        return page;
    }

    public void SetRowPosition(int rowId)
    {
        row = rowId;
    }

    public int FetchRowPosition()
    {
        return row;
    }

    public void SetColPosition(int colId)
    {
        col = colId;
    }

    public int FetchColPosition()
    {
        return col;
    }

    public void SetOccupied(GameObject newStickerObejct)
    {
        currentStickerObject = newStickerObejct;
        occupied = true;
    }

    public void SetUnoccupied()
    {
        currentStickerObject = null;
        occupied = false;
    }

    public bool CheckIfOccupied()
    {
        return occupied;
    }

    public GameObject CheckCurrentStickerObject()
    {
        return currentStickerObject;
    }

    public Vector3 CheckGridObjectPositionOffset()
    {
        return gridObjectPosOffset;
    }
}
