using System.Text;

namespace FileAndDirectoryOperations.ExerciseOne;

public class Core
{
    //A csatolt fájlban telephelyeket, szervezeti egységeket és azokon belül személyeket tárolunk.

    // Hozzon létre minden telephelynek mappákat, azokon belül a szervezeti egységeknek is mappákat.
    // Ezeken belül minden dolgozónak a nevére hozzon létre vezetéknév_keresztnév.log nevű fájlt!

    // fields
    private string _fileName;
    private List<Site> _sites;
    private StreamReader _reader;

    // constructors
    public Core(string fileName)
    {
        _fileName = fileName;
        _sites = new List<Site>();

        ProcessFileNew();
    }

    // methods

    // todo | refactor this
    private void ProcessFile()
    {
        string content = File.ReadAllText(_fileName, Encoding.UTF8);

        using (StreamReader reader = new StreamReader(_fileName, Encoding.UTF8))
        {
            Site? site = null;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine()!;

                // új telephely kezdete
                if (line.Contains('#'))
                {
                    string siteName = line.Split('#', StringSplitOptions.RemoveEmptyEntries)[0];

                    if (site != null)
                        _sites.Add(site);

                    site = new Site(siteName);
                    continue;
                }

                // új szervezeti egység kezdete
                if (line.Contains('>'))
                {
                    string organizationName = line.Split(
                        '>',
                        StringSplitOptions.RemoveEmptyEntries
                    )[1];

                    Organization organization = new Organization(organizationName);
                    site?.AddOrganization(organization);
                    continue;
                }

                // új személy kezdetei
                if (line.Contains('-'))
                {
                    string personName = line.Split('-', StringSplitOptions.RemoveEmptyEntries)[1];
                    Person person = new Person(personName);
                    site?.Organizations.Last().AddPerson(person);
                }
            }

            // ha véget ér a beolvasás az utolsó teléphelyet is hozzá kell adni
            if (site != null)
                _sites.Add(site);
        }
    }

    private void ProcessFileNew()
    {
        string[] sites = File.ReadAllText(_fileName, Encoding.UTF8)
            .Split('#', StringSplitOptions.RemoveEmptyEntries);

        foreach (string siteData in sites)
        {
            Site site = new Site();
            site.ParseFromText(siteData);
            _sites.Add(site);
        }
    }

    // properties
}
