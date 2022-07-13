--LessonCategories(LessonCateId,LessonCateName,DateCreated, DateModified, CreatedBy, ModifiedBy)

--Lessons(LessonId,LessonCateId, LessonName, DateCreated, DateModified, CreatedBy, ModifiedBy)

--LessonContents(LessonContentId,LessonContentName, ContentTypeId,Content, DateCreated,DateModified, CreatedBy, ModifiedBy)

--ContentTypes(ContentTypeId,ContentTypesName, DateCreated, DateModified, CreatedBy, ModifiedBy) 

--User(UserId, UserName, Password, Salt,RoleId, DateCreated, DateModified, CreatedBy, ModifiedBy)

--Roles(RoleId,RoleName, DateCreated, DateModified, CreatedBy, ModifiedBy)
drop database W3schoolsCss
go
create database W3schoolsCss
go
use W3schoolsCss
go
create table LessonCategories(
	LessonCateId int IDENTITY(1,1) primary key,
	LessonCateName nvarchar(100),
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)

create table Lessons(
	LessonId int Identity(1,1) primary key,
	LessonCateId int FOREIGN KEY (LessonCateId) REFERENCES LessonCategories(LessonCateId) ON DELETE CASCADE,
	LessonName nvarchar(100),
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
	)

create table ContentTypes(
	ContentTypeId int Identity(1,1) primary key,	
	ContentTypeName nvarchar(100),
	Descriptions nvarchar(200),
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)

create table LessonContents(
	LessonContentId int Identity(1,1) primary key,
	ContentTitle nvarchar(100),
	ContentTypeId int foreign key (ContentTypeId) references ContentTypes(ContentTypeId) ON DELETE CASCADE,
	LessonId int foreign key (LessonId) references Lessons(LessonId) ON DELETE CASCADE,
	Content nvarchar(max),
	ContentOrder int,
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)

create table Roles(
	RoleId int identity(1,1) primary key, 
	RoleName nvarchar(50),
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)

create table Users(
	UserId int identity(1,1) primary  key, 
	UserName nvarchar(100),
	RoleId int FOREIGN KEY (RoleId) REFERENCES Roles(RoleId) ON DELETE CASCADE,
	PassWord nvarchar(200),
	Email varchar(200),
	DateCreated DateTime default GetDate(),
	DateModified datetime default GetDate(),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)
create table Example
(	
	ExampleId int  IDENTITY(1,1) primary key ,
	Content varchar(max),
	LessonContentId int foreign key (LessonContentId) references LessonContents(LessonContentId) ON DELETE CASCADE,
	DateCreated DateTime default(GetDate()),
	DateModified DateTime default(GetDate()),
	CreatedBy nvarchar(50),
	ModifiedBy nvarchar(50)
)
INSERT [dbo].[ContentTypes] ( [ContentTypeName], [Descriptions], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'Block Code', N'write code directory', CAST(N'2021-10-25T17:16:03.150' AS DateTime), CAST(N'2021-10-25T17:16:03.150' AS DateTime), NULL, NULL)
INSERT [dbo].[ContentTypes] ( [ContentTypeName], [Descriptions], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'Plain Text', N'created by html editor', CAST(N'2021-10-26T10:40:49.330' AS DateTime), CAST(N'2021-10-26T10:40:49.330' AS DateTime), NULL, NULL)
INSERT [dbo].[ContentTypes] ( [ContentTypeName], [Descriptions], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES (N'Try it your self', N'Use live code editor', CAST(N'2021-10-27T11:45:26.463' AS DateTime), CAST(N'2021-10-27T11:45:26.463' AS DateTime), NULL, NULL)
INSERT [dbo].[LessonCategories] ( [LessonCateName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'CSS Tutorial', CAST(N'2021-10-27T20:10:06.570' AS DateTime), CAST(N'2021-11-01T22:57:18.297' AS DateTime), N'admin', N'su')
INSERT [dbo].[LessonCategories] ( [LessonCateName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'CSS Advanced', CAST(N'2021-11-01T22:57:02.143' AS DateTime), CAST(N'2021-11-01T22:57:02.143' AS DateTime), N'su', NULL)
INSERT [dbo].[Lessons] ( [LessonCateId], [LessonName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( 1, N'CSS HOME', CAST(N'2021-10-27T20:10:12.630' AS DateTime), CAST(N'2021-10-27T20:10:12.630' AS DateTime), N'admin', NULL)
INSERT [dbo].[Lessons] ( [LessonCateId], [LessonName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( 1, N'CSS Introduction', CAST(N'2021-11-02T08:34:06.883' AS DateTime), CAST(N'2021-11-02T08:34:07.000' AS DateTime), N'', NULL)
INSERT [dbo].[LessonContents] ([ContentTitle], [ContentTypeId], [Content], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy], [ContentOrder], [LessonId]) VALUES ( N'FULL ONE LESSONS', 1, N'  <div class="intro">
                    <p>CSS is the language we use to style an HTML document.</p>
                    <p>CSS is the language we use to style an HTML document.</p>
                    <p>CSS is the language we use to style an HTML document.</p>
                    <a href="" class="btn-link">Start learning CSS now »</a>
                  </div>
                  <hr />
                  <h2>Examples in Each Chapter</h2>
                  <p>This CSS tutorial contains hundreds of CSS examples.</p>
                  <p>With our online editor, you can edit the CSS, and click on a button to view the result.</p>
                  <div class="example">
                    <h3>Example</h3>
                    <div class="w3-code">
                      <!-- start css-block -->
                      <span class="css-selector-color" style="color: brown">
                        body
                        <span class="css-delimiter-color" style="color: black"> {</span>
                        <span class="css-property-color" style="color: red">
                          <br />
                             background-color:
                          <span class="css-propertyvalue-color" style="color: mediumblue">
                             lightblue
                            <span class="css-delimiter-color" style="color: black">;</span>
                            <br />
                          </span>
                          <span class="css-delimiter-color" style="color: black">}</span>
                        </span>
                      </span>
                      <br />
                      <br />
                      <!-- end css-block -->
                      <!-- start css-block -->
                      <span class="css-selector-color" style="color: brown">
                        h1
                        <span class="css-delimiter-color" style="color: black"> {</span>
                        <span class="css-property-color" style="color: red">
                          <br />
                             color:
                          <span class="css-propertyvalue-color" style="color: mediumblue">
                             white
                            <span class="css-delimiter-color" style="color: black">;</span>
                            <br />
                          </span>
                             text-align:
                          <span class="css-propertyvalue-color" style="color: mediumblue">
                             center
                            <span class="css-delimiter-color" style="color: black">;</span>
                            <br />
                          </span>
                          <span class="css-delimiter-color" style="color: black">}</span>
                        </span>
                      </span>
                      <br />
                      <br />
                      <!-- end css-block -->
                      <!-- start css-block -->
                      <span class="css-selector-color" style="color: brown">
                        p
                        <span class="css-delimiter-color" style="color: black"> {</span>
                        <span class="css-property-color" style="color: red">
                          <br />
                             font-family:
                          <span class="css-propertyvalue-color" style="color: mediumblue">
                             verdana
                            <span class="css-delimiter-color" style="color: black">;</span>
                            <br />
                          </span>
                             font-size:
                          <span class="css-propertyvalue-color" style="color: mediumblue">
                             20px
                            <span class="css-delimiter-color" style="color: black">;</span>
                            <br />
                          </span>
                          <span class="css-delimiter-color" style="color: black">}</span>
                        </span>
                      </span>
                      <br />
                      <br />
                      <!-- end css-block -->
                    </div>
                    <a class="btn-link" target="_blank" href="">Try it Yourself >></a>
                  </div>
                  <b>Click on the "Try it Yourself" button to see how it works.</b>
                  <hr />
                  <div class="text-block">
                    <h2 class="text-title">CSS Example</h2>
                    <p>
                      Learn from over 300 examples! With our editor, you can edit the CSS, and click on a button to view
                      the result.
                    </p>
                    <a class="text-link" href="">Go to CSS Examples!</a>
                  </div>
                  <hr />
                  <div class="text-block">
                    <h2 class="text-title">Use the Menu</h2>
                    <p>We recommend reading this tutorial, in the sequence listed in the menu.</p>
                    <p>If you have a large screen, the menu will always be present on the left.</p>
                    <p>If you have a small screen, open the menu by clicking the top menu sign ☰.</p>
                  </div>
                  <hr />
                  <div class="text-block">
                    <h2 class="text-title">CSS Templates</h2>
                    <p>We have created some responsive W3.CSS templates for you to use.</p>
                    <p>You are free to modify, save, share, and use them in all your projects.</p>
                    <a class="text-link" href="">Go to CSS Examples!</a>
                  </div>
                  <hr />
                  <div class="text-block">
                    <h2 class="text-title">CSS Exercises and Quiz Test</h2>
                    <p>Test your CSS skills at W3Schools!</p>
                    <a href="" class="btn-link">Start CSS Exercises! »</a>
                    <a href="" class="btn-link">Start CSS Quiz! »</a>
                  </div>
                  <hr />
                  <div class="text-block">
                    <h2 class="text-title">CSS References</h2>
                    <p>
                      At W3Schools you will find complete CSS references of all properties and selectors with syntax,
                      examples, browser support, and more.
                    </p>
                    <a class="text-link" href="">CSS Properties Reference</a>
                    <a class="text-link" href="">CSS Selectors Reference</a>
                    <a class="text-link" href="">CSS Functions Reference</a>
                    <a class="text-link" href="">CSS Animatable Reference</a>
                    <a class="text-link" href="">CSS Aural Reference</a>
                    <a class="text-link" href="">CSS Units</a>
                    <a class="text-link" href="">CSS Color Reference</a>
                    <a class="text-link" href="">CSS Default Values</a>
                    <a class="text-link" href="">CSS Browser Support</a>
                  </div>
', CAST(N'2021-11-02T09:25:52.457' AS DateTime), CAST(N'2021-11-22T10:36:35.410' AS DateTime), N'admin', N'admin', 2, 2)
INSERT [dbo].[LessonContents] ( [ContentTitle], [ContentTypeId], [Content], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy], [ContentOrder], [LessonId]) VALUES ( N'CSS Templates', 2, N'<h2 style="text-align: left;"><span style="background-color: rgb(255, 255, 255); font-size: 3.2rem; color: inherit; font-family: inherit;">CSS Templates</span></h2><p style="text-align: left;"><span style="background-color: rgb(255, 255, 255); font-family: -apple-system, BlinkMacSystemFont, &quot;Segoe UI&quot;, Roboto, &quot;Helvetica Neue&quot;, Arial, sans-serif, &quot;Apple Color Emoji&quot;, &quot;Segoe UI Emoji&quot;, &quot;Segoe UI Symbol&quot;; color: rgb(33, 37, 41); font-size: 1.5rem;">We have created some responsive W3.CSS templates for you to use.</span></p><p style="text-align: left;"><span style="background-color: rgb(255, 255, 255); font-family: -apple-system, BlinkMacSystemFont, &quot;Segoe UI&quot;, Roboto, &quot;Helvetica Neue&quot;, Arial, sans-serif, &quot;Apple Color Emoji&quot;, &quot;Segoe UI Emoji&quot;, &quot;Segoe UI Symbol&quot;; color: rgb(33, 37, 41); font-size: 1.5rem;">You are free to modify, save, share, and use them in all your projects.</span></p><p style="text-align: left;"><u style="font-family: -apple-system, BlinkMacSystemFont, &quot;Segoe UI&quot;, Roboto, &quot;Helvetica Neue&quot;, Arial, sans-serif, &quot;Apple Color Emoji&quot;, &quot;Segoe UI Emoji&quot;, &quot;Segoe UI Symbol&quot;; font-size: 1.6rem; background-color: transparent; color: var(--text-color);"><a href="https://localhost:44322/" rel="noopener noreferrer">Go to CSS Examples!</a></u></p><p><br></p>', CAST(N'2021-11-02T14:20:31.073' AS DateTime), CAST(N'2021-11-02T14:20:31.080' AS DateTime), N'admin', NULL, 1, 1)
INSERT [dbo].[LessonContents] ( [ContentTitle], [ContentTypeId], [Content], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy], [ContentOrder], [LessonId]) VALUES ( N'CSS Solved a Big Problem', 2, N'<h2><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: &quot;Segoe UI&quot;, Arial, sans-serif; font-size: 32px;">CSS Solved a Big Problem</span></h2><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">HTML was NEVER intended to contain tags for formatting a web page!</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">HTML was created to describe the content of a web page, like:</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">&lt;h1&gt;This is a heading&lt;/h1&gt;</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">&lt;p&gt;This is a paragraph.&lt;/p&gt;</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">When tags like &lt;font&gt;, and color attributes were added to the HTML 3.2 specification, it started a nightmare for web developers. Development of large websites, where fonts and color information were added to every single page, became a long and expensive process.</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">To solve this problem, the World Wide Web Consortium (W3C) created CSS.</span></p><p><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: Verdana, sans-serif; font-size: 15px;">CSS removed the style formatting from the HTML page!</span></p><h2><br></h2><p>	</p>', CAST(N'2021-11-02T14:45:55.683' AS DateTime), CAST(N'2021-11-02T14:45:55.790' AS DateTime), N'admin', NULL, 1, 1)
INSERT [dbo].[LessonContents] ( [ContentTitle], [ContentTypeId], [Content], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy], [ContentOrder], [LessonId]) VALUES ( NULL, 2, N'<h2><span style="background-color: rgb(255, 255, 255); color: rgb(0, 0, 0); font-family: &quot;Segoe UI&quot;, Arial, sans-serif; font-size: 32px;">CSS Saves a Lot of Work!</span></h2><p><span style="background-color: rgb(255, 255, 255); font-family: Verdana, sans-serif; color: rgb(0, 0, 0); font-size: 15px;">The style definitions are normally saved in external .css files.</span></p><p><span style="background-color: rgb(255, 255, 255); font-family: Verdana, sans-serif; color: rgb(0, 0, 0); font-size: 15px;">With an external stylesheet file, you can change the look of an entire website by changing just one file!</span></p><p><br></p>', CAST(N'2021-11-02T20:58:04.777' AS DateTime), CAST(N'2021-11-22T10:37:00.943' AS DateTime), N'admin', N'admin', 3, 2)
INSERT [dbo].[LessonContents] ([ContentTitle], [ContentTypeId], [Content], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy], [ContentOrder], [LessonId]) VALUES ( N'Test', 2, N'<p>test</p>', CAST(N'2021-11-22T10:39:46.190' AS DateTime), CAST(N'2021-11-22T10:40:00.783' AS DateTime), N'admin', NULL, 4, 2)

INSERT [dbo].[Roles] ( [RoleName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'Administrator', CAST(N'2021-11-16T08:56:48.583' AS DateTime), CAST(N'2021-11-16T08:56:48.727' AS DateTime), N'su', NULL)
INSERT [dbo].[Roles] ( [RoleName], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'User', CAST(N'2021-11-16T08:57:01.770' AS DateTime), CAST(N'2021-11-21T22:48:36.240' AS DateTime), N'su', N'su')
INSERT [dbo].[Users] ( [UserName], [Email], [RoleId], [PassWord], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'su', N'sucucvipcucpro@gmail.com', 1, N'$2b$10$XlwfEPhbSgO1g.KaxiZ9EetULn11O/oh6m.iJj/zLeDXEchngMHBi', CAST(N'2021-11-21T22:17:39.387' AS DateTime), CAST(N'2021-11-21T22:17:39.550' AS DateTime), N'admin', NULL)
INSERT [dbo].[Users] ( [UserName], [Email], [RoleId], [PassWord], [DateCreated], [DateModified], [CreatedBy], [ModifiedBy]) VALUES ( N'test', N'test@gmail.com', 2, N'$2b$10$Ry5a5W5I//rBAWGe0Oy58e5vuaAWRvwxdKfFt1DjtnzTlvyo9aIu.', CAST(N'2021-11-22T09:58:14.163' AS DateTime), CAST(N'2021-11-22T09:58:14.330' AS DateTime), N'admin', NULL)
