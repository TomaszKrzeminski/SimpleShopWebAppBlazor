#pragma checksum "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c2f53d5e248e9f75a3ac5dc5a3e5bc2883dec8b"
// <auto-generated/>
#pragma warning disable 1591
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
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, "MainPage   ");
            __builder.AddContent(2, 
#nullable restore
#line 20 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
                DateTime.Now

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n\r\n\r\n\r\n");
            __builder.OpenElement(4, "h1");
            __builder.AddContent(5, 
#nullable restore
#line 24 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
     Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
            __builder.OpenElement(7, "h1");
            __builder.AddContent(8, 
#nullable restore
#line 25 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
     Check

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(10);
            __builder.AddAttribute(11, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 26 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
                  Viewmodel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
#nullable restore
#line 28 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
     foreach (var product in Viewmodel.ProductList)
    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "form-group");
                __builder2.OpenElement(15, "label");
                __builder2.AddContent(16, 
#nullable restore
#line 31 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
                    product.ProductName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 35 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
    }

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(17, "div");
                __builder2.AddAttribute(18, "class", "form-group");
                __builder2.OpenElement(19, "input");
                __builder2.AddAttribute(20, "class", "btn btn-danger");
                __builder2.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
                                                Update

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "value", "Update");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.OpenElement(24, "button");
                __builder2.AddAttribute(25, "class", "btn btn-info");
                __builder2.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\MainPage2.razor"
                                               Check2

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(27, "Check");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
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
