using OCCUWebsite.Data;
using OCCUWebsite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OCCUWebsite.Pages.Persons;

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

    public PaginatedList<Person> Persons { get; set; }

    public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
    {
        CurrentSort = sortOrder;
        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        DateSort = sortOrder == "Date" ? "date_desc" : "Date";
        if (searchString != null)
        {
            pageIndex = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        CurrentFilter = searchString;

        IQueryable<Person> PersonsIQ = from s in _context.Persons
                                         select s;
        if (!String.IsNullOrEmpty(searchString))
        {
            PersonsIQ = PersonsIQ.Where(s => s.LastName.Contains(searchString)
                                   || s.FirstName.Contains(searchString));
        }
        switch (sortOrder)
        {
            case "name_desc":
                PersonsIQ = PersonsIQ.OrderByDescending(s => s.LastName);
                break;
            case "Date":
                PersonsIQ = PersonsIQ.OrderBy(s => s.StartDate);
                break;
            case "date_desc":
                PersonsIQ = PersonsIQ.OrderByDescending(s => s.StartDate);
                break;
            default:
                PersonsIQ = PersonsIQ.OrderBy(s => s.LastName);
                break;
        }

        var pageSize = Configuration.GetValue("PageSize", 37);
        Persons = await PaginatedList<Person>.CreateAsync(
            PersonsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
    }
}
