using Godot;
using Godot.Collections;
using System;

[Tool]
public partial class UpgradeTemplate : Control
{
    [Export]
    public Array<Button> UpgradeButtons { get; set; } = new Array<Button>();


    private HBoxContainer _outerContainer;

    private VBoxContainer _buttonContainer;

    private RichTextLabel _upradeDescription;

    public override void _Process(double delta)
    {
        // Call base proccess to avoid missing functionality
        base._Process(delta);

        // Keep the editor up to date with button changes
        if(Engine.IsEditorHint())
        {
            this.AddButtons();
        }
    }

    public override void _Ready()
    {
        // Call base ready to avoid missing functionality
        base._Ready();

        if(this.AttachReferences() && this.UpgradeButtons.Count > 0)
        {
            this.AddButtons();
        }
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

    private void AddButtons()
    {
        if (this.UpgradeButtons.Count > 0)
        {
            foreach (Button button in this.UpgradeButtons)
            {
                this._buttonContainer.AddChild(button);
            }
        }
    }
}
