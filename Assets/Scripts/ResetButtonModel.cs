using UniRx;

public class ResetButtonModel
{
    public IReactiveProperty<bool> IsCreatedProp => _isCreatedProp;
    private BoolReactiveProperty _isCreatedProp;
    
    public ResetButtonModel()
    {
        _isCreatedProp = new BoolReactiveProperty(false);
    }

    public void SetIsCreated(bool IsCreated)
    {
        _isCreatedProp.Value = IsCreated;
    }
}
