
namespace TimeKeepingCode.Code
{
    public interface IForms : IPost
    {
        bool Save();
        bool Edit();
        bool Create();
        bool Cancel();
        void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee);
        UserAction Action { get; }
        string FormText { get; }
    }
}
