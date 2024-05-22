THIS REPOSITORY IS A HOME WORK WHICH I RECEIVED TO DO DURING AN APPLYING FOR A JOB.

# PdfApiService
 Api service project in asp.net core.
 
 An homework project to extract data from cv pdf file and to store it in mongodb  database.
 I used this source to learn and to get the solution: https://www.youtube.com/watch?v=iWTdJ1IYGtg
 and this text version: https://www.pragimtech.com/blog/mongodb-tutorial/asp-net-6-rest-api-tutorial/

 The service repositoty is located in Services folder of the solution.
 I used the injectable patern for easy maintenence of the code.
 In 'injectable patern' I mean using interface + its implementation class.

 In Models folder we have the class of the entity(the object of cv items). This entity is mapped
   to a document(a row) in the collection of the data base.
 The two other files are interface + its implementation to contain details about the connection
   to the data base.  They are paralleled to the "PdfCvItemsStoreDatabaseSettings" section in
   appsettings.json.

 I use the controller (in Pdf_Cv_ItemsController.cs) as a standard way for addressing the api
   service. It contains two ActionResult functions : Get(string id) to locate a specific row,
   and AddItiemsRow([FromBody] Pdf_Cv_Items pdf_cv_items) to insert an cv items row to the data base.
   We actually do not need the Get function, but we use it to get the content of the '201' response
   after inserting a row successfully.
 In the controller's constructor I inject the api service repository for using in the 'crud'
   functions (I mean to 'Get' and AddItiemsRow functions). As I mentioned above, the injection
   patern also makes the maintenence and changes in code easier.

 In Program.cs I make configurations to map the data base and connection details within appsetting.jason
   to the setting class (in PdfCvItemsStoreDatabaseSettings.cs). I also register the two injectables-
   setting and mongoclient to use in Service repository and the (injectable) service repository itself
   to use in the controller.
 The using of Program.cs as configuration file makes the maintenence of the code easier as it 
   centralizes the changable parts of the code in one place.
