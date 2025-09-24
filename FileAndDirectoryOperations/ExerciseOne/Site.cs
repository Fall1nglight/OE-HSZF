namespace FileAndDirectoryOperations.ExerciseOne;

// telephely
public class Site
{
    // fields
    private string _name;
    private List<Organization> _organizations;

    // constructors
    public Site()
    {
        _organizations = new List<Organization>();
    }

    public Site(string name)
    {
        _name = name;
        _organizations = new List<Organization>();
    }

    // methods
    public void AddOrganization(Organization organization) => _organizations.Add(organization);

    public void ParseFromText(string data)
    {
        string[] parts = data.Split('>', StringSplitOptions.RemoveEmptyEntries);
        _name = parts[0];

        for (int i = 1; i < parts.Length; i++)
        {
            Organization organization = new Organization();
            organization.ParseFromText(parts[i]);
            _organizations.Add(organization);
        }
    }

    // properties
    public string Name => _name;
    public List<Organization> Organizations => _organizations;
}
