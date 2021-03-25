
using System.Collections.Generic;
using AccountBalance.Domain;
using AccountBalance.Services;
using Microsoft.AspNetCore.Components;

namespace AccountBalance.Pages
{
    public class ProviderBase: CrudBase
    {
        [Inject]
        protected ProviderService ProviderService { get; set; }

        protected ProviderView ProviderView;
        protected IEnumerable<ProviderView> Providers;
        protected int TopRows;
        protected string Name;
        protected string Country;

        protected override void OnInitialized()
        {
            TopRows = 10;
            Country = "GT";
            Name = "";

            HideAddModal();
            GetProviders();
        }

        protected void GetProviders()
        {
            HideErrorMessage();
            var result = ProviderService.GetProviders(TopRows, Name, Country);
            result.Match(right => Providers = right, ShowErrorMessage);
        }

        protected void ShowAddModal()
        {
            HideModalError();
            ShowModal();
            ModifyModal = false;
            ProviderView = new ProviderView();
        }

        protected override void Update()
        {

        }

        protected override void Add()
        {
            var result = ProviderService.Add(ProviderView);
            result.Match(right => {

                HideAddModal();
                HideModalError();
                GetProviders();
                
            }, ShowErrorMessage);
        }
    }
}