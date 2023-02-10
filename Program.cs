using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Models;
using Schemas;

string path = Directory.GetCurrentDirectory();
string XMLSchemasPath = path + "/XML";
string[] XSDfiles = Directory.GetFiles(XMLSchemasPath);
string url = "https://cbr.ru/vfs/mcirabis/BIKNew/20230206ED01OSBR.zip";
XmlReaderSettings settings = new();
ED807 ED807 = new();
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //encoding problems

//var ed807path = "cbr_ed807_v2022.4.1.xsd";
//var cbred = "cbr_ed_objects_v2022.4.1.xsd";
//var url = "https://cbr.ru/vfs/mcirabis/BIKNew/20230206ED01OSBR.zip";
LoadXSD();
DownloadAndUnzipXML();
LoadXMLdocument();
SaveToDB();

void SaveToDB()
{
    try
    {
        using var mydb = new ApplicationDbContext();
        mydb.Add(ED807);
        foreach (var B in ED807.BICDirectoryEntry)
        {
            mydb.Add(B);
        }
        _ = mydb.SaveChanges();
    }
    catch(Exception ex)
    {
        Console.WriteLine($"DB Error {ex}");
    }
}

void DownloadAndUnzipXML()
{
try
    {
        using WebClient client = new();
        client.DownloadFile(url, "20230206ED01OSBR.zip");
        System.IO.Compression.ZipFile.ExtractToDirectory($"{path}/20230206ED01OSBR.zip", $"{path}", true);
        Console.WriteLine($"XML Downloaded");
    }
    catch
    {
        Console.WriteLine($"XML Downloading Error");
    }
}

void LoadXMLdocument()
{

    try
    {
        XmlReader reader = XmlReader.Create($"{path}/20230206_ED807_full.xml", settings);
        XmlSerializer xmlSerializer = new(typeof(ED807));
        ED807 = (ED807)xmlSerializer.Deserialize(reader);
        Console.WriteLine($"XML loaded and validated");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Possible validation error {ex}");
    }
}

void LoadXSD()
{
    try
    {
        settings.ValidationType = ValidationType.Schema;
        foreach (var XSDSchema in XSDfiles)
        {
            settings.Schemas.Add(null, XSDSchema);
        }
        Console.WriteLine($"XSD Loaded");
    }
    catch
    {
        Console.WriteLine($"XSD Loading Error");
    }
}

