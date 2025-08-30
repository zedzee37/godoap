using Godot;

#nullable enable
[GlobalClass]
public partial class InteractorArea : Area2D
{
    private InteractionArea? currentArea;

    public override void _Ready()
    {
        AreaEntered += InteractionAreaEntered;
    }

    public InteractionResult? Interact()
    {
        if (currentArea == null)
        {
            return null;
        }

        return currentArea.Interact();
    }

    private void InteractionAreaEntered(Area2D area)
    {
        if (area is not InteractionArea interactionArea)
        {
            return;
        }

        float distanceTo = interactionArea.GlobalPosition.DistanceSquaredTo(
                GlobalPosition
        );

        if (currentArea == null)
        {
            currentArea = interactionArea;
            return;
        }

        float currentDistance = currentArea.GlobalPosition.DistanceSquaredTo(
                GlobalPosition
        );

        if (distanceTo < currentDistance)
        {
            currentArea = interactionArea;
        }
    }
}
