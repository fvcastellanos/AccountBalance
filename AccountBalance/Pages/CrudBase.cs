using Microsoft.AspNetCore.Components.Forms;

namespace AccountBalance.Pages
{
    public abstract class CrudBase: PageBase
    {
        protected EditContext EditContext;
        protected bool DisplayModal;
        protected bool DisplayDeleteModal;
        protected bool DisplayViewModal;
        protected bool ModifyModal;
        protected bool HasModalError;
        protected string ModalErrorMessage;

        protected abstract void Update();
        protected abstract void Add();

        protected void DisplayModalError(string error)
        {
            HasModalError = true;
            ModalErrorMessage = error;
        }

        protected void HideModalError()
        {
            HasModalError = false;
            ModalErrorMessage = "";
        }

        protected void ShowModal()
        {
            DisplayModal = true;
        }

        protected void HideModal()
        {
            DisplayModal = false;
        }

        protected void HideAddModal()
        {
            HideModalError();
            HideModal();
        }

        protected void SaveChanges()
        {
            if (EditContext.Validate())
            {
                if (ModifyModal)
                {
                    Update();
                    return;
                }

                Add();
            }

        }        
    }
}