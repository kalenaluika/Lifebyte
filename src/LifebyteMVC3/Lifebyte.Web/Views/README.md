Views
=====
The "V" in MVC.

Views should be [dumb](http://youtu.be/ku3QkWcPSEw). The goal is to keep the HTML inside a view to a 
minimum. We use HTML helpers which we will override and provide UI Hints for display.

Our UI is driven by the Model. The Model decides what elements are required, what the proper label should 
be for an element, and how data entry for a specific property should be handled.

If you want to change how a form looks, the view is the last place to look. Start in the Model, then look 
for a template override or HTML helper.