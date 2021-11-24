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

    private void Start() 
    {
        SetUnoccupied();
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

    public void SetPageNumber(int pageId)
    {
        page = pageId;
    }

    public void SetRowPosition(int rowId)
    {
        row = rowId;
    }

    public void SetColPosition(int colId)
    {
        col = colId;
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
}
