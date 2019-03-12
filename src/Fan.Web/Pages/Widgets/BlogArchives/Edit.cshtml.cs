﻿using Fan.Widgets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Fan.Web.Pages.Widgets.BlogArchives
{
    public class EditModel : PageModel
    {
        protected readonly IWidgetService widgetService;
        public EditModel(IWidgetService widgetService)
        {
            this.widgetService = widgetService;
        }

        public string WidgetJson { get; set; }

        /// <summary>
        /// Initializes model properties.
        /// </summary>
        /// <param name="widgetId"></param>
        public async Task OnGet(int widgetId)
        {
            var widget = (BlogArchivesWidget)await widgetService.GetWidgetAsync(widgetId);
            WidgetJson = JsonConvert.SerializeObject(widget);
        }

        /// <summary>
        /// Updates widget properties. 
        /// </summary>
        /// <param name="widget"></param>
        public async Task<IActionResult> OnPostAsync([FromBody]BlogArchivesWidget widget)
        {
            if (ModelState.IsValid)
            {
                await widgetService.UpdateWidgetAsync(widget.Id, widget);
                return new JsonResult(true);
            }

            return BadRequest("Invalid form values submitted.");
        }
    }
}