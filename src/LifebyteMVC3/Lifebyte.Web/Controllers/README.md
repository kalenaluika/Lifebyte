Controllers
===========
The "C" in MVC.

Controllers should be [skinny](http://youtu.be/91C7ax0UAAc). We only want basic communication between views 
and the model done here.

The controller is a broker who does not need to make decisions. It simply receives a request from the 
view and a response from the model.