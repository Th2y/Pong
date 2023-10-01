public class StateBase
{
    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateStay()
    {

    }

    public virtual void OnStateExit() 
    {

    }
}

public class StateMenu : StateBase
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        GameManager.Instance.ChangeActualStateToMenu();
    }
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        GameManager.Instance.ChangeActualStateToGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        GameManager.Instance.ChangeActualStateToResetPosition();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        GameManager.Instance.ChangeActualStateToEndGame();
    }
}
