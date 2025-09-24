namespace FileAndDirectoryOperations.ExerciseOne;

// telephely
public class Site
{
    // fields
    private string _name;
    private List<Organization> _organizations;

    // constructors
    public Site(string name)
    {
        _name = name;
        _organizations = new List<Organization>();
    }

    // methods
    public void AddOrganization(Organization organization) => _organizations.Add(organization);

    // properties
    public string Name => _name;
    public List<Organization> Organizations => _organizations;
}
