using OCCUWebsite.Data;
using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OCCUWebsite.Pages.StatusReports;

public class IndexModel : PageModel
{
    private readonly PersonContext _context;
    private readonly IConfiguration Configuration;

    public IndexModel(PersonContext context, IConfiguration configuration)
    {
        _context = context;
        Configuration = configuration;
    }

    public string NameSort { get; set; }
    public string DateSort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }

    public PaginatedList<StatusReport> StatusReports { get; set; }

    public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
    {
        CurrentSort = sortOrder;
        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        if (searchString != null)
        {
            pageIndex = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        CurrentFilter = searchString;

        IQueryable<StatusReport> statusReportsIQ = from s in _context.StatusReports
                                         select s;

        var pageSize = 37;// Configuration.GetValue("PageSize", 37);
        StatusReports = await PaginatedList<StatusReport>.CreateAsync(
            statusReportsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
    }
}
