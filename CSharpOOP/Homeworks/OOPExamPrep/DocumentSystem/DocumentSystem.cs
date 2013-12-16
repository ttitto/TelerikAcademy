using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}
public interface IEditable
{
    void ChangeContent(string newContent);
}
public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public class DocumentSystem
{
    static IList<IDocument> documents = new List<IDocument>();
    static void Main()
    {

        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }


    private static void AddDocument(IDocument myDoc, string[] attributes)
    {
        foreach (var item in attributes)
        {
            string[] keyValuePair = item.Split(new char[] { '=' });
            string key = keyValuePair[0];
            string value = keyValuePair[1];
            myDoc.LoadProperty(key, value);
        }
        if (myDoc.Name == string.Empty || myDoc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            documents.Add(myDoc);
            Console.WriteLine("Document added: {0}", myDoc.Name);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {

        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var item in documents)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }

    private static void EncryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                documentFound = true;
                if (item is IEncryptable)
                {
                    ((IEncryptable)item).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", item.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", item.Name);
                }
            }
        }
        if (documentFound == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                documentFound = true;
                if (item is IEncryptable)
                {
                    ((IEncryptable)item).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", item.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", item.Name);
                }
            }
        }
        if (documentFound == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool encryptableFound = false;
        foreach (var item in documents)
        {
            if (item is IEncryptable)
            {
                ((IEncryptable)item).Encrypt();
                encryptableFound = true;
            }
        }
        if (encryptableFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool documentFound = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                documentFound = true;
                if (item is IEditable)
                {
                    ((IEditable)item).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", item.Name);

                }
                else Console.WriteLine("Document is not editable: {0}", item.Name);
            }
        }
        if (documentFound == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

}

public class TextDocument : IDocument, IEditable
{
    private string charSet;
    private string name;
    private string content;

    public TextDocument()
        : base()
    {
    }
    public string CharSet
    {
        get { return this.charSet; }
        set { this.charSet = value; }
    }
    public string Name
    {
        get { return this.name; }
    }
    public string Content
    {
        get { return this.content; }
    }

    public virtual void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "name":
                this.name = value;
                break;
            case "charset":
                this.CharSet = value;
                break;
            case "content":
                this.content = value;
                break;
            default:
                break;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
        output.Add(new KeyValuePair<string, object>("charset", this.CharSet));
    }

    #region IEditable
    public void ChangeContent(string newContent)
    {
        this.content = newContent;
    }
    #endregion
    public override string ToString()
    {
        string type = this.GetType().Name;
        IList<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();

        SaveAllProperties(keyValuePairs);

        if (this is IEncryptable && ((IEncryptable)this).IsEncrypted == true)
        {
            return type + "[encrypted]";
        }
        else
        {
            var orderedPairs = from keyValuePair in keyValuePairs
                               where !string.IsNullOrEmpty(Convert.ToString(keyValuePair.Value)) && (Convert.ToString(keyValuePair.Value)) != "0"
                               orderby keyValuePair.Key
                               select keyValuePair;
            StringBuilder sb = new StringBuilder();
            sb.Append(type);
            sb.Append("[");
            for (int ii = 0; ii < orderedPairs.Count(); ii++)
            {
                sb.Append(orderedPairs.ToList()[ii].Key);
                sb.Append("=");
                sb.Append(orderedPairs.ToList()[ii].Value);
                if (ii != orderedPairs.Count() - 1)
                {
                    sb.Append(";");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }

    }

}
public abstract class BinaryDocument : IDocument
{
    public BinaryDocument()
        : base()
    {
    }


    private long size;
    private string name;
    protected string content;

    public long Size
    {
        get { return this.size; }
        set { this.size = value; }
    }
    public string Name
    {
        get { return this.name; }
    }
    public string Content
    {
        get { return this.content; }
    }

    public virtual void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "size":
                this.Size = long.Parse(value);
                break;
            case "name":
                this.name = value;
                break;
            case "content":
                this.content = value;
                break;
            default:
                break;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }
    public override string ToString()
    {
        string type = this.GetType().Name;
        IList<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();

        SaveAllProperties(keyValuePairs);

        if (this is IEncryptable && ((IEncryptable)this).IsEncrypted == true)
        {
            return type + "[encrypted]";
        }
        else
        {
            var orderedPairs = from keyValuePair in keyValuePairs
                               where !string.IsNullOrEmpty(Convert.ToString(keyValuePair.Value)) && (Convert.ToString(keyValuePair.Value)) != "0"
                               orderby keyValuePair.Key
                               select keyValuePair;
            StringBuilder sb = new StringBuilder();
            sb.Append(type);
            sb.Append("[");
            for (int ii = 0; ii < orderedPairs.Count(); ii++)
            {
                sb.Append(orderedPairs.ToList()[ii].Key);
                sb.Append("=");
                sb.Append(orderedPairs.ToList()[ii].Value);
                if (ii != orderedPairs.Count() - 1)
                {
                    sb.Append(";");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }

    }
}
public class BinaryEncrypted : BinaryDocument, IEncryptable
{
    public BinaryEncrypted()
        : base()
    {
    }

    protected bool isEncrypted;

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }


    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }
}
public abstract class OfficeDocument : BinaryEncrypted
{
    public OfficeDocument()
        : base()
    {
    }

    private string version;


    public string Version
    {
        get { return this.version; }
        set { this.version = value; }
    }

    #region IDocument

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "version":
                this.Version = value;
                break;

            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);

        output.Add(new KeyValuePair<string, object>("version", this.Version));
    }
    #endregion

}
public class WordDocument : OfficeDocument, IEditable
{
    public WordDocument()
        : base()
    {
    }

    private long numOfCharacters;

    public long NumOfCharacters
    {
        get { return this.numOfCharacters; }
        set { this.numOfCharacters = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "chars":
                this.NumOfCharacters = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.NumOfCharacters));
        base.SaveAllProperties(output);
    }


    #region IEditable
    public void ChangeContent(string newContent)
    {
        this.content = newContent;
    }
    #endregion
}
public class ExcelDocument : OfficeDocument
{
    public ExcelDocument()
        : base()
    {
    }

    private long numOfRows;
    private long numOfCols;

    public long NumOfRows
    {
        get { return this.numOfRows; }
        set { this.numOfRows = value; }
    }
    public long NumOfCols
    {
        get { return this.numOfCols; }
        set { this.numOfCols = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "rows":
                this.NumOfRows = long.Parse(value);
                break;
            case "cols":
                this.NumOfCols = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("cols", this.NumOfCols));
        output.Add(new KeyValuePair<string, object>("rows", this.NumOfRows));
        base.SaveAllProperties(output);
    }
}
public abstract class MultimediaDocument : BinaryDocument
{
    public MultimediaDocument()
        : base()
    {
    }

    private long length;

    public long Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "length":
                this.Length = long.Parse(value);
                break;
            default: base.LoadProperty(key, value);
                break;
        }
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}
public class VideoDocument : MultimediaDocument
{
    public VideoDocument()
        : base()
    {
    }

    private double frameRate;


    public double FrameRate
    {
        get { return this.frameRate; }
        set { this.frameRate = value; }
    }


    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "framerate":
                this.FrameRate = double.Parse(value);
                break;
            default: base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }
}
public class AudioDocument : MultimediaDocument
{
    public AudioDocument()
        : base()
    {
    }

    private double sampleRate;

    public double SampleRate
    {
        get { return this.sampleRate; }
        set { this.sampleRate = value; }
    }
    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "samplerate":
                this.SampleRate = double.Parse(value);
                break;
            default: base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}
public class PDFDocument : BinaryEncrypted
{
    public PDFDocument()
        : base()
    {
    }

    private long numOfPages;

    public long NumOfPages
    {
        get { return this.numOfPages; }
        set { this.numOfPages = value; }
    }

    #region IDocument
    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "pages":
                this.NumOfPages = long.Parse(value);
                break;

            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.NumOfPages));
        base.SaveAllProperties(output);

    }
    #endregion

}

