# Race Track Application
Race Track application is developed in C#, ASP.Net Core MVC, KnockoutJS, jQuery, NewtonsoftJson, Datatables.net, Sql Server, Entity Framework, Linq to Sql, xUnit Test using Moq, HTML5, CSS3

1. Proper utilization of Dependency Injection
2. Code-first Entity Framework (Microsoft SQL Server)
3. Encapsulating Business logic within models independent of the DB
implementation.
4. Composition & Inheritance : Inheritance is used. 
5. Reason: Inheritance is used because there is an "is a" relationship between a child and its parent class.
The subclass really is a more specialized version of the superclass. 
In this case, a car and truck is a type of vehicle, so the inheritance relationship makes sense.

Composition doesn't make sense here because there is not has relationship between objects, that is, one object "has" (or is part of) another object for example, Car has a Battery

6. Basic design patterns
7. Utilize AJAX to present an always up-to-date listing of vehicles on the track
8. Write unit tests to prove the following business requirements

The following set of business requirements demonstrate the items
listed above:
1. Present an always up-to-date listing of vehicles on the race track (Utilizing AJAX)
2. Present a single form to add vehicles to the race track. (Utilize a Type drop-down
to determine which fields to show/hide, see inspections below)
3. A maximum of 5 vehicles can be on the race-track at any time.
4. Vehicles must pass an inspection prior to entering the track

Truck Inspections:
1. Tow strap on the vehicle
2. Not lifted more than 5 inches

Car Inspections:
1. Tow strap on the vehicle
2. Less than 85% tire wear

This is the initial version, would need to update/ammend to include all above cases.
