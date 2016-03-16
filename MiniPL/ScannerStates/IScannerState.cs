namespace MiniPL.ScannerStates
{
    public interface IScannerState
    {
        ScannerState Read(TokenConstruction Current, char Read, StateStorage States);
    }
}
