Models/Data
===========
We are using NHibernate as the ORM. We try to limit classes who have a dependency on NHibernate to just those 
in this folder. Other classes who need access to data will go through a DataService class located in the 
Models/Services folder.

The goal is to be able to swap out NHibernate for another ORM without affecting anything other than the classes 
contained in this folder.