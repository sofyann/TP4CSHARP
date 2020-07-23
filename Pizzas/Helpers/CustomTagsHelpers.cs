using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pizzas.Helpers
{
    public static class CustomTagsHelpers
    {
        // this HtmlHelper htmlHelper permet de faire référence au type et à l'élément sur lequel l'Helper sera branché
        // ici il sagit de HtmlHelper (@Html)
        // Il faut retourner un MvcHtmlString pour que les strings composants le code HTML soient interprétées (retourner le StringBuilder aurait fait un affichage du code en dure)
        public static IHtmlString CustomSubmit(this HtmlHelper htmlHelper, String name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"form-group\">");
            sb.Append("<div class=\"col-md-offset-2 col-md-10\">");
            sb.Append($"<input type=\"submit\" value=\"{name}\" class=\"btn btn-default\" />");
            sb.Append("</div>");
            sb.Append("</div>");
            return new MvcHtmlString(sb.ToString());
        }
    }
} 