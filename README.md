# CachNet
A Low Level Cachet C# Library

# Usage
```cs
CachetClient Cachet = new CachetClient("", "");

ResponseData<String> response = await Cachet.PingAsync().ConfigureAwait(false);
Console.WriteLine(response.Data); //Pong!

ResponseData<Incident> incident = await Cachet.AddIncidentAsync(new PostIncident
{
  ComponentId = 1,
  ComponentStatus = ComponentStatus.Operational,
  Name = "Incident Name"
});
```
