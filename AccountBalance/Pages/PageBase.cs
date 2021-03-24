using Microsoft.AspNetCore.Components;

namespace AccountBalance.Pages
{
    public abstract class PageBase: ComponentBase
    {
        protected bool DisplayErrorMessage;

        protected string ErrorMessage;

        protected void HideErrorMessage()
        {
            DisplayErrorMessage = false;
            ErrorMessage = "";
        }

        protected void ShowErrorMessage(string message)
        {
            DisplayErrorMessage = true;
            ErrorMessage = message;
        }        
    }
}