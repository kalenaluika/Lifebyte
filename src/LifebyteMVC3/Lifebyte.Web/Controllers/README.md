Controllers
===========
The "C" in MVC.

Controllers should be [skinny](http://youtu.be/91C7ax0UAAc). We only want basic communication between views 
and the model done here.

The controller is a broker who does not need to make decisions. It simply receives a request from the 
view and a response from the model.

We follow the Select-View-Edit-Save and the Post-Redirect-Get pattern from Chapter 7 of 
Programming Microsoft ASP.NET MVC by  Dino Esposito.

"Have a controller for each business entity that is directly exposed to the presentation layer 
and for each operational context."

Chapter 4 - Inside Controllers 
Programming Microsoft ASP.NET MVC 
by  Dino Esposito 
