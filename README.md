# AngularJS + Web API 2 example
Make sure to restore all nuget packages

# BackEnd
Backend is wired up with Entity Framework 6. I approached it as a Code First, Model - View Model approach, so automapper was used heavily on the controllers to generate DTOs and handle circling dependencies.

# FrontEnd
AngularJS was used for the app as a SPA, I demonstrate the use of re-usable components with the "person-list" component, this component displays an edit view depending on whether a variable is initially passed.

# Notes

 - There's multiple approachs on how to update the order of a drag and
   drop list, in this case I decided to update the entire model, due to
   the size of the project, in bigger projects with more data, maybe a
   more granular approach should be used and update the order on the
   backend without the need to make a full update on the **Person**
   Model
   
 - There's no validation on the models, other than requiring basic stuff like the name
