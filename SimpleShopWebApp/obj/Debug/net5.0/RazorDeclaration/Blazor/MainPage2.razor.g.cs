// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SimpleShopWebApp.Blazor
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using SimpleShopWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using SimpleShopWebApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.EntityFrameworkCore.Design;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    public partial class MainPage2 : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
       

    private Repository repository;

    [Parameter]
    public string Title { get; set; } = "";

    [Parameter]
    public ShowProductsViewModel Viewmodel { get; set; } = new ShowProductsViewModel();



    public int Check { get; set; } = 1;


    async Task<ShowProductsViewModel> GetViewModel()
    {
        ApplicationDbContext context = factory.CreateDbContext();
        repository = new Repository(context);

        List<Product> list = await repository.GetProductsAsync();

        ShowProductsViewModel model = new ShowProductsViewModel();
        model.ProductList = list;
        Title = "Pobieranie";
        return model;


    }



    protected override async Task OnInitializedAsync()
    {

        ApplicationDbContext context = factory.CreateDbContext();
        repository = new Repository(context);
        List<Product> list = await repository.GetProductsAsync();

        ShowProductsViewModel model = new ShowProductsViewModel();
        model.ProductList = list;

        Viewmodel = model;
        Title = "Start";

    }



    public async Task Update()
    {

        ApplicationDbContext context = factory.CreateDbContext();
        repository = new Repository(context);
        List<Product> list = await repository.GetProductsAsync();

        ShowProductsViewModel model = new ShowProductsViewModel();
        model.ProductList = list;




        Viewmodel = model;
        Title = "Update";
    }



    public void Check2(MouseEventArgs e)
    {
        Check++;
        Title = "Check";
    }


    public void Dispose()
    {

        repository.Dispose();
    }




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDbContextFactory<ApplicationDbContext> factory { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
    }
}
#pragma warning restore 1591
