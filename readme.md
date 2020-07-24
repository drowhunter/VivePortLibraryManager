# Description

---
This is a library to scan a viveport application folder and return a list of `ViveGame` objects.

## Class Definition

```csharp
public partial class ViveGame
{
    public string Name { get; set; }
    public string Url { get; set; }

    public string Thumbnail { get; set; }

    public string AppKey { get; set; }

    public string LaunchType { get; set; }

    public string Arguments { get; set; }

    public string ExePath { get; set; }
}
```

## Usage

```csharp
IVivePortScanner scanner = new VivePortScanner();

List<ViveGame> apps = scanner.Scan(@"F:\Viveport\ViveApps");

```

**Returns:**

```json
[
  {
    "Name": " Agent Emerson",
    "Url": "viveport.desktop://runapp/1ece1d6d-04ff-450b-9893-54924004b6e7",
    "Thumbnail": "F:\\Viveport\\ViveApps\\1ece1d6d-04ff-450b-9893-54924004b6e7\\1575272095\\Thumbnail-square.jpg",
    "AppKey": "vive.htc.1ece1d6d-04ff-450b-9893-54924004b6e7",
    "LaunchType": "url",
    "Arguments": "-compositor",
    "ExePath": "F:\\Viveport\\ViveApps\\1ece1d6d-04ff-450b-9893-54924004b6e7\\1575272095\\AgentEmerson_Viveport\\Agent Emerson VR Experience.exe"
  },
  {
    "Name": "2MD: VR Football",
    "Url": "viveport.desktop://runapp/ce3ece07-4fb2-4e2b-87a6-5b328847c6d2",
    "Thumbnail": "F:\\Viveport\\ViveApps\\ce3ece07-4fb2-4e2b-87a6-5b328847c6d2\\1591618880\\Thumbnail-square.jpg",
    "AppKey": "vive.htc.ce3ece07-4fb2-4e2b-87a6-5b328847c6d2",
    "LaunchType": "url",
    "Arguments": "-compositor",
    "ExePath": "F:\\Viveport\\ViveApps\\ce3ece07-4fb2-4e2b-87a6-5b328847c6d2\\1591618880\\2md.exe"
  }
]

```
