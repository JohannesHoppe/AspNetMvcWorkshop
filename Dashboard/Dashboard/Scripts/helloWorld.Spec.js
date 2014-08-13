/// <reference path="helloWorld.js" />
/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="kendo/2014.1.318/jquery.min.js" />
/// <reference path="kendoGridModule.js" />
/// <reference path="myFirstModule.js" />

describe('helloWorld', function() {

    it('should say hello', function() {
    
        expect(helloWorld()).toEqual("Hello World");
    });

});