// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let footerNode = document.getElementsByTagName('footer')[0];
let newHtml = "<p>This page was last modified on: " + document.lastModified + "</p>";
footerNode.innerHTML += newHtml; // Append the new html
