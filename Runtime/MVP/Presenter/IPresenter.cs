public interface IPresenter
{
    void Bind(IView view);
    void Open();
    void Refresh();
    void Close();
}