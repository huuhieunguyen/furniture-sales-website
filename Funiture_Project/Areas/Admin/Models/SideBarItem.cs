using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace Funiture_Project.Areas.Admin.Models
{
    public enum SideBarItemType
    {
        Divider,
        Heading,
        NavItem
    }
    public class SideBarItem
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public SideBarItemType Type { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }

        public string AwesomeIcon { get; set; }
        public List<SideBarItem> Items { get; set; }
        public string collapseID { get; set; }
        public string Getlink(IUrlHelper urlHelper)
        {
            return urlHelper.Action(Action, Controller, new { area = Area });
        }
        public string RenderHtml(IUrlHelper urlHelper)
        {
            var html = new StringBuilder();
            if (Type == SideBarItemType.Divider)
            {
                html.Append("<hr class=\"sidebar-divider\" />");
            }
            else if (Type == SideBarItemType.Heading)
            {
                html.Append(@$"<div class=""sidebar-heading"">
                                            {Title}
                                            </div>");
            }
            else if (Type == SideBarItemType.NavItem)
            {
                if (Items == null)
                {
                    var url = Getlink(urlHelper);
                    var icon = (AwesomeIcon != null) ? $"<i class=\"{AwesomeIcon}\"></i>" : "";
                    var cssClass = "nav-item";
                    if (IsActive) cssClass += " active";
                    html.Append(@$"<li class=""{cssClass}"">
                                    <a class=""nav-link"" href=""{url}"">
                                          {icon}
                                           <span>{Title}</span>
                                     </a>
                                   </li>");
                }
                else
                {
                    var cssClass = "nav-item";
                    if (IsActive) cssClass += " active";
                    var icon = (AwesomeIcon != null) ? $"<i class=\"{AwesomeIcon}\"></i>" : "";

                    var collapseCss = "collapse";
                    if (IsActive) collapseCss += " show";
                    var itemMenu = "";
                    foreach (var item in Items)
                    {
                        var urlItem = item.Getlink(urlHelper);
                        var cssItem = "collapse-item";
                        if (item.IsActive) cssItem += " active";
                        itemMenu += $"<a class=\"{cssItem}\" href=\"{urlItem}\">{item.Title}</a>";
                    }
                    //Items != null
                    html.Append(@$"
                    <li class=""{cssClass}"">
                        <a class=""nav-link collapsed""
                           href=""#""
                           data-toggle=""collapse""
                           data-target=""#{collapseID}""
                           aria-expanded=""true""
                           aria-controls=""{collapseID}"">
                           {icon}
                            <span>{Title}</span>
                        </a>
                        <div id=""{collapseID}""
                             class=""{collapseCss}""
                             aria-labelledby=""headingTwo""
                             data-parent=""#accordionSidebar"">
                            <div class=""bg-white py-2 collapse-inner rounded"">
                                {itemMenu}
                            </div>
                        </div>
                    </li>
                    ");

                }
            }

            return html.ToString();
        }
    }
}
