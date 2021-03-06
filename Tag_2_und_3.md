# Dreitägiger ASP.NET MVC Workshop
Ihr Trainer: [Johannes Hoppe](http://www.haushoppe-its.de) von [Grossweber](http://grossweber.com/)

## Tag 2 und 3 - Agenda

1. [JavaScript Best Practices – häufige Fehler vermeiden, bewährtes verwenden](#bestpractices)
    a. Vermeiden von globals, eval, etc. 
    b. Modularer Code
2. [Require.js  und modularer Code](#require)
    1. [Modules](#modules)
    2. [Dependencies](#dependencies)
    3. [Dependency Management](#introduction)
    4. [Loading of dependencies](#load)
    5. [Configuration](#configuration)
3. Refactoring eines bestehenden JavaScript-Codes – Ziel: ein Modul
4. [Testing des Moduls mit Jasmine](#jasmine)
5. Daten holen per Ajax
6. [Security: Besprechung Cross-Site-Scripting](#XSS)
7. Crash-Kurs Kendo UI
8. Deklarativer Ansatz (data-Attribute)
9. Refactoring von bestehendem Code
10. [Ergänzungen (Zusätzliche Infos während des Trainings)](#extra)




<a name="bestpractices"></a>
## 1. JavaScript Best Practices

[![Logo](images/best_practices_logo.png)](http://johanneshoppe.github.com/JsBestPractices)
[Link](http://johanneshoppe.github.com/JsBestPractices)
Inhalt: Best Practices, Modularer Code und Unit-Testing


<a name="require"></a>
## 2. Require.js und modularer Code

Javascript framekworks need some glue to fit together. Require.js is exactly that glue. Using a modular script loader like require.js will improve the speed and quality of your code. Lets see how.

All these technologies need some glue to fit together. Require.js is exactly that glue. Using a modular script loader like require.js will improve the speed and quality of your code, too.


<a name="modules"></a>
### 2.1. Modules

For our context a modules is structure used to encapsulate methods and attributes to avoid polluting the global namespace.

We will use the [revealing module pattern](http://addyosmani.com/resources/essentialjsdesignpatterns/book/#revealingmodulepatternjavascript) because its widely adopted and very easy to understand. JavaScript doesn’t have special syntax for namespaces or packages, but the module pattern allows us to write decoupled
pieces of code, which can be treated as black boxes. The module pattern is a combination of several patterns
* Namespaces
* Immediate functions
* Private and public members
* Declaring dependencies

During the day Johannes will explain all of these topics in detail, but for now this snipped shows a typical module. 

```js
var myModule = function () {

    var _name = "Johannes";

    function greetings() {
        console.log("Hello " + _name);
    }

    function setName(name) {
        _name = name;
    }

    return {
        setName: setName,
        greetings: greetings
    };
}();
```

<a name="dependencies"></a>
### 2.2. Dependencies

For our context a dependency is a piece of JavaScript code on which another piece of JavaScript somehow depends on. The existence of such a dependency is therefore required to get the complete system running. In most cases a method or value of such a dependency is going to be accessed. In other cases there might be no direct access to the required piece of software, but there could be a hidden dependency where the systems state is changed as required.

The above module might have a dependency to jQuery. A simple way to make this dependency visible is the following construct. 

```js
var myModule = function ($) {

    var _name = "Johannes";

    function greetings() {
        $('#output').text("Hello " + _name);
    }

    return {
        greetings: greetings
    };
}(window.jQuery);
```


<a name="management"></a>
### 2.3. Dependencies Management

We have seen a naive way to handle dependencies. But things are getting complicated in practice.
Working with dependencies means loading of JavaScript code...
* ... in the right order.
* ... at the right time.
* ... at the right speed.

These requirements can't be resolved with simple script includes like:
```<script src="myscript.js"></script>```
It is not clear which other files need to be loaded in before. It's also not clear when this file would be required. It might be totally useless, nobody knows. And last but not least, this file will slow down the applications first run. Usually an application is ready to start, when the browser fires `DOMContentLoaded`. But DOMContentLoaded waits for the full HTML and scripts, and then triggers. If the file has no interaction with the DOM, this waiting time is useless.

Require.js takes a different approach to script loading than traditional &lt;script&gt; tags. Its goal is to encourage modular code. Require.js is a JavaScript file and module loader, capable of loading modules defined in the AMD (Asynchronous Module Definition) format and their dependencies. The asynchronous design makes AMD well suited for a browser environment. Today it's embraced by projects including Dojo, MooTools, Firebug or jQuery. The format is easy to learn since it only has two keywords: `define` and `require`.

Therefore require.js is easy to introduce to a project that is already using a module pattern. Only small changes on our module are necessary:

```js
define(['jquery'], function ($) {

    var _name = "Johannes";

    function greetings() {
        $('#output').text("Hello " + _name);
    }

    return {
        greetings: greetings
    };
});
```

The file should get the file name "myModule.js".


<a name="load"></a>
### 2.4. Loading of dependencies

It is considered as best-practice to place to [the bottom of a page](http://developer.yahoo.com/performance/rules.html#js_bottom). But just JavaScript code at the bottom of the page won't make things that much better. That’s why we will should load our dependencies with require.js.

The module is defined but nobody uses it. Let's create a counterpart. The following snipped loads the module "myModule". By convention, the name of the module (the so-called **module ID**) should be equal to the file without the .js file ending.

```js
require(['myModule'], function(m) { 
    m.greetings(); 
});
```

Here we load the module "myModule" and decide to name the corresponding parameter in the anonymous function to a shorter version "m". We then call the method "greetings" of the "myModule" module. 


<a name="configuration"></a>
### 2.5. Configuration

In a perfect world wouldn't need setup files. But often we have to deal with version numbers in files, obscured paths or files that don’t implement the AMD pattern. For all these proposes require.js can be configured. It’s a good idea to put that configuration into a new file, e.g. called require.config.js:

```javascript
requirejs.config({
    baseUrl: "Scripts",
    paths: {
        'jquery': 'jquery-2.0.3',
        'knockout': 'knockout-2.3.0'
    },
    shim: {
        'knockout': { deps: ['jquery'] }
    }
});
```

Here we define paths and file names if the file does not match the convention. There is also a "shim" defined, that indicates that the module "knockout" is dependent upon "jquery". Require.js will make sure, that jQuery will be loaded before Knockout. Shims are also often used to point to a global variable that and AMD-ignorant script will create. (via [exports](http://requirejs.org/docs/api.html#config-shim))

<a name="jasmine"></a>
## 4. Testing des Moduls mit Jasmine

Wir verwenden Jasmine, das bekannteste JavaScript Unit-Test Framework. Folgende Datei bietet einen schnellen Einstieg, da keine externer Testrunner notwendig ist. (wir könnten auch den [Karma-Testrunner](http://karma-runner.github.io/0.12/index.html) oder den Resharper verwenden)

```html
<!DOCTYPE html>
<html>
<head>
    <title>Jasmine Spec Runner</title>

    <link rel="stylesheet" href="lib/jasmine-1.3.1/jasmine.css" />
    <script src="lib/jasmine-1.3.1/jasmine.js"></script>
    <script src="lib/jasmine-1.3.1/jasmine-html.js"></script>

    <!-- include source files here... -->
    <script src="src/Player.js"></script>
    <script src="src/Song.js"></script>

    <!-- include spec files here... -->
    <script src="spec/SpecHelper.js"></script>
    <script src="spec/PlayerSpec.js"></script>

    <script>

        (function () {

            var htmlReporter = new jasmine.HtmlReporter();
            var jasmineEnv = jasmine.getEnv();

            jasmineEnv.addReporter(htmlReporter);
            jasmineEnv.specFilter = function (spec) {
                return htmlReporter.specFilter(spec);
            };

            var currentWindowOnload = window.onload;

            window.onload = function () {
                if (currentWindowOnload) { currentWindowOnload(); }
                jasmineEnv.execute();
            };
        })();
    </script>

</head>

<body>
</body>
</html>
```

Die Datei und die Tests finden Sie im ["jasmine" Ordner](Dashboard/Dashboard/Scripts/jasmine/jasmine).


<a name="XSS"></a>
## 6. Security: Besprechung Cross-Site-Scripting

[![Logo](images/security_logo.png)](http://johanneshoppe.github.io/HTML5Security/)
[Link](http://johanneshoppe.github.io/HTML5Security/)
Inhalt: Ausgewählte Sicherheitslücken


<a name="extra"></a>
## 10. Ergänzungen (Zusätzliche Infos während des Trainings)


### REST
[Doku zum Webinar: REST und Hypermedia](https://github.com/JohannesHoppe/DeveloperMediaDemo/blob/master/Documentation/04.%20ASP.NET%20Web%20API%20Webinar.md#level3)



### Tools
- Resharper: Unit Test ausführen
- JsHint (Qualitätsicherung)
- [Karma Testrunner](http://karma-runner.github.io)

### JS Books


[![Book cover](https://raw.github.com/JohannesHoppe/DeveloperMediaDemo/master/Documentation/images/06_01_javascript_patterns.png)](http://www.amazon.com/dp/0596806752)
A great book is ["JavaScript Patterns"](http://www.amazon.com/dp/0596806752) from Stoyan Stefanov. It explains in detail the required patterns for a solid JavaScript-driven website! 

[![Book cover](images/book_essentialjsdesignpatterns.png)](http://addyosmani.com/resources/essentialjsdesignpatterns/book/)
Another great one is [Learning JavaScript Design Patterns](http://addyosmani.com/resources/essentialjsdesignpatterns/book/) from Addy Osmani.

### Kendo UI

How To Use Kendo UI Declarative Initialization
http://docs.telerik.com/kendo-ui/howto/declarative_initialization
http://www.telerik.com/forums/declarative-initialization-of-the-kendo-ui-grid

### Lokalisierung
Resx Lokalisierungen (sowie T4MVC Routen und alles andere) von .NET nach JavaScript bringen:
http://blog.mariusschulz.com/2013/07/07/generating-external-javascript-files-using-partial-razor-views


