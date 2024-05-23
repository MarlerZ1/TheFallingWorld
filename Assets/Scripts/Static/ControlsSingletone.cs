public class ControlsSingletone
{
    static private Controls _controls;

    static public Controls GetControls ()
    {
        if (_controls == null)
            _controls = new Controls();
        return _controls;
    }
    
    static public void Destroy()
    {
        _controls = null;
    }
}
