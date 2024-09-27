My project:

5 classes were created: Seller, Buyer, Product, Order, User. The classes Seller and Buyer inherit the User attributes. The Order class additionally uses SellerId, BuyerId and ProductId foreign keys from other classes.

Functionality: Basic functionalities have been developed that allow the user to add, delete, adjust, find by Id sellers, buyers, products and orders data. 

EntityFramework is used for data transfer to the SQL database, additionally data is also transferred to MongoDb. Formed 4 tables in the SQL database. 

Caching in Mongo Db happens every 5 minutes. The only non-cashable product category remains, as it was not mentioned as a requirement in the quest. 

You need to test the functionality by launching the Store.API. When creating new sellers, buyers, products and orders, it is not necessary to specify their Id (the system generates them automatically). Note: When enabling ordering functions, the correct date format is "yyyy-mm-dd" - this is how the data should be merged.

Logging in works as soon as the program is activated. It captures which task the user selects and returns the results to the console and the generated text file. A new text file is created once a day.
