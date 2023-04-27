using System.Xml;

// Creates a new XmlDocument object to load and work with the XML file
XmlDocument xmlDoc = new XmlDocument();

// Loads the XML file from path
xmlDoc.Load(@"Xml\sma_gentext.xml");

// Calls the GetTargetValueById method and pass the loaded XML document
GetTargetValueById(xmlDoc);


// Method to extract the target value with a given id
static void GetTargetValueById(XmlDocument xmlDoc)
{
    // Selects the XML node with the specified ID
    XmlNode transUnitNode = xmlDoc.SelectSingleNode("/root/file/body/trans-unit[@id= '42007']");

    // Checks if it exists
    if (transUnitNode != null)
    {

        // Extracts the value of the "target" child node
        string targetValue = transUnitNode["target"].InnerText;

        // Path to the output text file
        string filePath = "transUnitIdOutput.txt";

        // Writes the target value to the output text file
        File.WriteAllText(filePath, targetValue);

        // Output the target value to the console
        Console.WriteLine($"Target value for ID '42007': {targetValue}");
    }
    else
    {
        // If the target with the specified ID is not found, print a message to the console
        Console.WriteLine("Target with ID '42007' not found.");
    }
}
