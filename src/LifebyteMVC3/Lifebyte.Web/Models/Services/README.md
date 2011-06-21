Models/Services
===============
Controllers talk to services. 

The service layer acts as a buffer between the user interface and the underlying classes such as the ORM.

The goal is to allow us to change the ORM or Authentication without affecting the controllers.