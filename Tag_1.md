# Dreitägiger ASP.NET MVC Workshop
Ihr Trainer: [Johannes Hoppe](http://www.haushoppe-its.de)

## Tag 1 - Agenda

1. Grundlagen, Besprechung der Fragen zur Vorbereitung
2. [Anlegen eines ASP.NET Web API Projekts (Routing, Bundling)](#projekt)
3. Anlegen von DTOs / POCOs (Geschäftsobjekte)
4. Einrichten von Entity Framework, Code First – Besprechung: Mockbarer Context (DbContext)
5. Repository (CRUD) – Tests!
6. Implementierung MVC Controllers / Web API Controllers – Tests!
7. Hello World View
8. Besprechung [AntiRequestForgeryToken]
9. Vergleich "Daily-Work"-Software mit Trainingsinhalt




<a name="projekt"></a>
## 2. Anlegen eines ASP.NET Web API Projekts

Wir verwenden folgendes Projekt-Template aus Visual Studio:
File > New > Project > Templates > Visual C# > Web > **"ASP.NET Web Application"**

![Screenshot](images/screenshot_01.png)

Dabei wählen wir ein Web API Projekt aus:

![Screenshot](images/screenshot_02.png)

Wir besprechen folgende Order:

1. Models
2. Views
3. Controllers

sowie

1. Content
2. Scripts


<a name="dto"></a>
## 3. Anlegen von DTOs / POCOs (Geschäftsobjekte)

Wir werden einfache "Data Transfer Objekte" (DTO) bzw. "Plain Old CLR Objects" (POCO) verwenden. Hiermit können wir die Daten unserer "Geschäftslogik" halten. Es gibt verschiedene Architektur-Stile, bei vielen sollten "Geschäftsobjekte" nicht nur Daten sondern auch Methoden besitzen. Für eine einfache Anwendung ist es absolut ausreichend, nicht zwischen "Entitäten" (ein Begriff des Domain Driven Designs von Eric Evans) und zwischen DTOs zu unterscheiden. Wir verwenden die DTOs direkt und hauchen Ihnen später etwas Leben ein - mithilfe des Entity Frameworks. Es ist aber wichtig zu erkennen, das wir dadurch ein "**Anemic** domain model" erstellen. Dieses gilt als Anti-Pattern im Sinne des Domain Driven Designs.

Die Verwendung des Entity Frameworks garantiert übrigens nicht, das wir nun Entitäten im Sinne von Domain Driven Design besitzen. Der Begriff ist hier doppeldeutig. 