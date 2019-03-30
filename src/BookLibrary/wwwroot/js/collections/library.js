﻿/* global Backbone */

var app = app || {};
var baseUrl = document.location.origin;
var appPath = document.location.pathname;
var index = -1;

if (appPath.endsWith('.html')) {
    index = appPath.lastIndexOf('/');
    appPath = appPath.substr(0, index + 1);
}

if (!appPath.endsWith('/')) {
    appPath += '/';
}
    
baseUrl += appPath; 

app.Library = Backbone.Collection.extend({
    model: app.Book,
    url: baseUrl + 'api/books'
});