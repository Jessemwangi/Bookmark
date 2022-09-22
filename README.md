# Bookmark
The application can be clone;
installed packages
	1. Microsoft.EntityFrameworkCore 6.0.9  - this will install entity framework 6
	2. Microsoft.EntityFrameworkCore.InMemory - since we are not injecting into the real sql server db and not configured in appsetting.json for simulation purpose we use inmemory
	configure and injected in program.cs (builder.Services.AddDbContext<Bookmarkcontext>(opt => opt.UseInMemoryDatabase("Bookmapdb")); 'Bookmapdb this becomes the db')
	3. testing can be done when the program is runned using swagger,or postman

	the end point are as follows
	bookmarks
	GET domian/api/v1/bookmark: Get a list of bookmarks
	POST /api/v1/bookmark/:id: Update/Create a bookmark if an id is provided in the json body a put will occur else a post is done
	DELETE /api/v1/bookmark/:id: Delete a bookmark

	for the folder model
	 GET /api/v1/folders: Get a list of folders
	 POST /api/v1/folders:Id Create/update a new folder if Id=0 create else update if id queried and found (put)
	 DELETE /api/v1/folders/:id: Delete a folder



