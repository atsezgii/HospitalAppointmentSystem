using Serilog.Core;
using Serilog.Events;
using System.Linq;

public class CustomUserNameColumn : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        // Kullanıcı adı bilgisi varsa kullan, yoksa "Anonymous" olarak ayarla
        if (!logEvent.Properties.TryGetValue("UserName", out var userNameProperty) || userNameProperty == null)
        {
            userNameProperty = new ScalarValue("Anonymous");
        }

        var userName = propertyFactory.CreateProperty("UserName", userNameProperty.ToString());
        logEvent.AddPropertyIfAbsent(userName);
    }
}
