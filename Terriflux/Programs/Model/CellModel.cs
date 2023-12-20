using Godot;
using System;

public partial class CellModel : ICellObservable
{
    private StringName cname = "Cell";
    private int size = 128; // px
    private CellKind kind = CellKind.PRIMARY;
    private ICellObserver observer;
    private Vector2 placement;

    // CONSTRUCT
    public CellModel() { }

    public CellModel(ICellObserver observer, int x, int y) { 
        this.SetObserver(observer);
        this.SetPlacement(x, y);
    }

    // GET-SET
    public int GetCellSize()
    {
        return this.size;
    }

    public void SetCellSize(int newSellSize)
    {
        this.size = newSellSize;
    }

    public void SetCellName(StringName newName)
    {
        this.cname = newName;
    }

    public StringName GetCellName()
    {
        return this.cname;
    }

    public void SetCellKind(CellKind newKind)
    {
        this.kind = newKind;
    }

    public CellKind GetCellKind()
    {
        return this.kind;
    }

    public void SetPlacement(int x, int y)
    {
        this.placement = new Vector2(x, y);
        this.NotifyPlacement();
    }

    public Vector2 GetPlacement()
    {
        return this.placement;
    }

    // Observer
    public void SetObserver(ICellObserver observer)
    {
        this.observer = observer;
    }

    public void NotifyPlacement()
    {
        this.observer.UpdatePlacement(this.placement);
    }

    public void NotifyCellName()
    {
        this.observer.UpdateCellName(cname);
    }
}