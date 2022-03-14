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
#line 1 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using SimpleShopWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using SimpleShopWebApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.EntityFrameworkCore.Design;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    public partial class AddProduct : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\Users\tomszek\Desktop\SimpleWebApp\SimpleShopWebApp\Blazor\AddProduct.razor"
       


    public string FormSubmitMessage { get; set; } = "Dane formularza nie zostały wysłane";
    public Repository repository { get; set; }

    public void HandleInvalidSubmit() => FormSubmitMessage = "Dane w formularzu są błędne";



    public AddProductViewModel Product { get; set; } = new AddProductViewModel();

    public async void HandleValidSubmit()
    {
        repository = new Repository(factory.CreateDbContext());

        await repository.AddProduct(Product.Product);
        FormSubmitMessage = "Dane w formularzu wysłane";

    }

    //public void Dispose()
    //{

    //    repository.Dispose();
    //}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDbContextFactory<ApplicationDbContext> factory { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
    }
}
#pragma warning restore 1591
