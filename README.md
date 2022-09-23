# Bookmark
The application can be clone (public);

installed packages

	1. Microsoft.EntityFrameworkCore 6.0.9  - this will install entity framework 6
	2. Microsoft.EntityFrameworkCore.InMemory - since we are not injecting into the real sql server db and not configured in appsetting.json for simulation purpose we use inmemory
	configure and injected in program.cs (builder.Services.AddDbContext<Bookmarkcontext>(opt => opt.UseInMemoryDatabase("Bookmapdb")); 'Bookmapdb this becomes the db')
	3. testing can be done when the program is runned using swagger,or postman

	the end point are as follows:-

	bookmarks

	GET /api/v1/bookmark/getall: Get all list of bookmarks
	GET /api/v1/bookmark/get/ID: uses an integer ID to return a bookmark record
	POST /api/v1/bookmark/create: new data comes from body inform of json file, on http 'conflict' it mean a duplicate entry was being entered
	PUT /api/v1/bookmark/updateboomark/ID: require an integer ID, Update a bookmark if an ID  provided return data else dispaly http error 'not found'
	DELETE /api/v1/bookmark/:id: Delete a bookmark using an ID

 folders

	 GET /api/v1/folders/GetAll: Get a list of folders
	 GET /api/v1/folders/Get/ID: Get a folders data using Integer ID
	 POST /api/v1/folders/create: Create new data but check for duplic if founf return http 'confilct' code
	 PUT /api/v1/folders/updateFolder/ID: update a  folder if searched and founded else return no content http error
	 DELETE /api/v1/folders/:id: Delete a folder  using an interger ID



