using Godot;
using Godot.Collections;
using System;

[Tool]
public abstract partial class UpgradeTemplate : Control
{

    private HBoxContainer _outerContainer;

    private VBoxContainer _buttonContainer;

    private RichTextLabel _upradeDescription;

    public override void _Process(double delta)
    {
        // Call base proccess to avoid missing functionality
        base._Process(delta);

        //Keep engine up to date in editor
        if (Engine.IsEditorHint())
        {
            AttachReferences();
        }
    }

    public override void _Ready()
    {
        // Call base ready to avoid missing functionality
        base._Ready();

        // Attach references to children
        AttachReferences();
    }

    private bool AttachReferences()
    {
        // Prepare error message for debugging in catch satement
        string errorMessage = "An error occurred while loading: ";
        string nodeName = "";
        try
        {
            nodeName = "Container";
            this._outerContainer = this.GetNode<HBoxContainer>(nodeName);
            nodeName = "Container/UpgradeButtons";
            this._buttonContainer = this.GetNode<VBoxContainer>(nodeName);
            nodeName = "Container/UpgradeDescription";
            this._upradeDescription = this.GetNode<RichTextLabel>(nodeName);

            return true;
        }
        catch (Exception e)
        {
            GD.PrintErr(errorMessage + nodeName);
            GD.PrintErr(e.Message);

            return false;
        }
    }
}
