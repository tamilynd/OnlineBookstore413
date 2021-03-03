using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineBookstore413.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This Tag Helper helps us build HTML dynamically
namespace OnlineBookstore413.Infrastructure
{
    //This will be used inside a div
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        
        //Constructor sets urlHelper class variable
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //Pull in ViewModel Class Object
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }


        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            //loop through each page that is needed for the site and create links for each
            for (int i = 1; i <= PageModel.TotalPages; i++) 
            {
                //create a tag
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["page"] = i;

                //add href of tag
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                //add innerhtml
                tag.InnerHtml.Append(i.ToString());

                //Add new tag onto html
                result.InnerHtml.AppendHtml(tag);
            }

            //send the links to the output and append it to the cshtml page
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
